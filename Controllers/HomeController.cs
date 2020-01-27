using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VWOSdk.DemoApp.Models;

namespace VWOSdk.DemoApp.Controllers
{
    public class HomeController : Controller
    {
        private static string GetRandomName()
        {
            int randomNumber = RandomGenerator.Next(0, Names.Count - 1);
            return Names[randomNumber];
        }

        private static Random RandomGenerator { get; set; } = new Random();

        private static List<string> Names
            = new List<string>() { "Ashley", "Bill", "Chris", "Dominic", "Emma", "Faizan",
                    "Gimmy", "Harry", "Ian", "John", "King", "Lisa", "Mona", "Nina",
                    "Olivia", "Pete", "Queen", "Robert", "Sarah", "Tierra", "Una",
                    "Varun", "Will", "Xin", "You", "Zeba" };

        private static Settings SettingsFile { get; set; }
        private static IVWOClient VWOClient { get; }

        static HomeController()
        {
            VWO.Configure(LogLevel.DEBUG);
            VWO.Configure(new CustomLogger());
            SettingsFile = SettingsProvider.GetSettingsFile(VWOConfig.ABCampaignSettings.AccountId, VWOConfig.ABCampaignSettings.SdkKey);
            VWOClient = VWO.CreateInstance(SettingsFile, isDevelopmentMode: true, userProfileService: new UserProfileService());
        }

        [HttpGet]
        public IActionResult Index([FromQuery] string user)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Ab([FromQuery] string user)
        {
            var userId = string.IsNullOrEmpty(user) ? GetRandomName() : user;
            var campaignTestKey = VWOConfig.ABCampaignSettings.CampaignTestKey;
            var goalIdentifier = VWOConfig.ABCampaignSettings.GoalIdentifier;
            var customVariables = VWOConfig.ABCampaignSettings.CustomVariables;
            var revenueVariables = VWOConfig.ABCampaignSettings.RevenueVariables;
            string activateResponse = null, getVariationResponse = null;
            bool trackResponse = false;
            if (VWOClient != null)
            {
                activateResponse = VWOClient.Activate(campaignTestKey, userId);
                getVariationResponse = string.IsNullOrEmpty(activateResponse) ? activateResponse : VWOClient.GetVariation(campaignTestKey, userId);
                trackResponse = string.IsNullOrEmpty(activateResponse) ? false : VWOClient.Track(campaignTestKey, userId, goalIdentifier, revenueVariables);
            }
            var json = new ViewModel(SettingsFile, userId, campaignTestKey, goalIdentifier, activateResponse, getVariationResponse, trackResponse, customVariables);
            return View(json);
        }

        
        [HttpGet]
        public IActionResult FeatureRollout([FromQuery] string user)
        {
            var userId = string.IsNullOrEmpty(user) ? GetRandomName() : user;
            var customVariables = VWOConfig.FeatureRolloutData.CustomVariables;
            string campaignTestKey = VWOConfig.FeatureRolloutData.CampaignTestKey;
            string campaignType = "Feature-rollout";
            bool activateResponse = false;
            if (VWOClient != null)
            {
                activateResponse = VWOClient.IsFeatureEnabled(campaignTestKey, userId, customVariables);
            }
            var json = new ViewModel(SettingsFile, userId, campaignTestKey, campaignType, activateResponse, customVariables);
            return View(json);
        }

        [HttpGet]
        public IActionResult FeatureTest([FromQuery] string user)
        {
            var userId = string.IsNullOrEmpty(user) ? GetRandomName() : user;
            var revenueAndCustomVariables = VWOConfig.FeatureTestData.RevenueAndCustomVariables;
            string stringVariableKey = VWOConfig.FeatureTestData.StringVariableKey;
            string integerVariableKey = VWOConfig.FeatureTestData.IntegerVariableKey;
            string booleanVariableKey = VWOConfig.FeatureTestData.BooleanVariableKey;
            string doubleVariableKey = VWOConfig.FeatureTestData.DoubleVariableKey;
            string goalIdentifier = VWOConfig.FeatureTestData.GoalIdentifier;
            string campaignTestKey = VWOConfig.FeatureTestData.CampaignTestKey;
            string campaignType = "Feature-test";
            bool activateResponse = false;
            dynamic integerVariable = null;
            dynamic booleanVariable = null;
            dynamic stringVariable = null;
            dynamic doubleVariable = null;
            if (VWOClient != null)
            {
                
                activateResponse = VWOClient.IsFeatureEnabled(campaignTestKey, userId, revenueAndCustomVariables);
                if (activateResponse) {
                  VWOClient.Track(campaignTestKey, userId, goalIdentifier, revenueAndCustomVariables);
                }
                stringVariable = VWOClient.GetFeatureVariableValue(campaignTestKey, stringVariableKey, userId, revenueAndCustomVariables);
                integerVariable = VWOClient.GetFeatureVariableValue(campaignTestKey, integerVariableKey, userId, revenueAndCustomVariables);
                booleanVariable = VWOClient.GetFeatureVariableValue(campaignTestKey, booleanVariableKey, userId, revenueAndCustomVariables);
                doubleVariable = VWOClient.GetFeatureVariableValue(campaignTestKey, doubleVariableKey, userId, revenueAndCustomVariables);
            }
            var json = new ViewModel(SettingsFile, userId, campaignTestKey, goalIdentifier, campaignType, activateResponse, revenueAndCustomVariables, stringVariable, integerVariable, booleanVariable, doubleVariable);
            return View(json);
        }                   

        [HttpGet]
        public IActionResult Push([FromQuery] string user)
        {
            var userId = string.IsNullOrEmpty(user) ? GetRandomName() : user;
            string tagKey = VWOConfig.PushData.TagKey;
            dynamic tagValue = VWOConfig.PushData.TagValue;
            bool activateResponse = false;
            if (VWOClient != null)
            {
                activateResponse = VWOClient.Push(tagKey, tagValue, userId);
            }
            var json = new ViewModel(SettingsFile, userId, activateResponse, tagKey, tagValue);
            return View(json);
        }
    }
}

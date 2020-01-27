using System.Collections.Generic;

namespace VWOSdk.DemoApp
{
    public class VWOConfig
    {
        internal static class ABCampaignSettings {
            public static long AccountId = Defaults.AccountId;          ////Assign actual value;
            public static string SdkKey = Defaults.SdkKey;          ////Assign actual value;
            public static string CampaignTestKey = Defaults.CampaignTestKey;          ////Assign actual value;
            public static string GoalIdentifier = Defaults.GoalIdentifier;          ////Assign actual value;
            public static Dictionary<string, dynamic> CustomVariables = Defaults.CustomVariables;
            public static Dictionary<string, dynamic> RevenueVariables = Defaults.RevenueVariables;
        }

        internal static class PushData {
            public static string TagKey = "test";
            public static dynamic TagValue = "value";
        }

        internal static class FeatureRolloutData {
            public static string CampaignTestKey = "php1";
            public static Dictionary<string, dynamic> CustomVariables = new Dictionary<string, dynamic>();
        }

        internal static class FeatureTestData {
            public static string CampaignTestKey = "php4";
            public static string GoalIdentifier = "custom";
            public static Dictionary<string, dynamic> RevenueAndCustomVariables = new Dictionary<string, dynamic>();
            public static string StringVariableKey = "Test";
            public static string IntegerVariableKey = "1";
            public static string DoubleVariableKey = "10.2";
            public static string BooleanVariableKey = "true";
        }
    }
}

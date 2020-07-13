using System.Collections.Generic;

namespace VWOSdk.DemoApp
{
    internal class Defaults
    {
        public readonly static long AccountId = 491256;
        public readonly static string SdkKey = "21ad8a8ba909aebceb9079fab10f11ce";
        public readonly static string CampaignKey = "TestKey";          ////Assign actual value;
        public readonly static string GoalIdentifier = "user_purchase";          ////Assign actual value;
        public readonly static Dictionary<string, dynamic> Options = new Dictionary<string, dynamic>()
        {
            {
                "revenueValue", 10
            },
            {
                "shouldTrackReturningUser", false
            },
            {
                "goalTypeToTrack", "ALL"
            },
            {
              "customVariables", new Dictionary<string, dynamic>()
              {
                  {
                    "gender", "f"
                  }
              }
            },
            {
              "variationTargettingVariable", new Dictionary<string, dynamic>()
              {
                  {
                      "abcd", 1
                  }
              }
            }
        };
    }
}

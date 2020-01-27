using System.Collections.Generic;

namespace VWOSdk.DemoApp
{
    internal class Defaults
    {
        public readonly static long AccountId = 123456;
        public readonly static string SdkKey = "sampleSdkKey";
        public readonly static string CampaignTestKey = "DEV_TEST_6";          ////Assign actual value;
        public readonly static string GoalIdentifier = "CUSTOM";          ////Assign actual value;
        public readonly static Dictionary<string, dynamic> RevenueVariables = new Dictionary<string, dynamic>
        {
            {"revenue_value", 10}
        };
        public readonly static Dictionary<string, dynamic> CustomVariables = new Dictionary<string, dynamic>{};
    }
}
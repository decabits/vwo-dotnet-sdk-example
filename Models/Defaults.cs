using System.Collections.Generic;

namespace VWOSdk.DemoApp
{
    internal class Defaults
    {
        public readonly static long AccountId = 89499;
        public readonly static string SdkKey = "7aeed7f67f5a0b0fbe476c1f086a7038";
        public readonly static string CampaignTestKey = "phpab3";          ////Assign actual value;
        public readonly static string GoalIdentifier = "custom";          ////Assign actual value;
        public readonly static Dictionary<string, dynamic> RevenueVariables = new Dictionary<string, dynamic>
        {
            {"revenue_value", 10}
        };
        public readonly static Dictionary<string, dynamic> CustomVariables = new Dictionary<string, dynamic>{};
    }
}
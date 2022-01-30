using System.ComponentModel;

namespace StockGuide.Shared.Enums
{
    public enum AverageRequestIntervalEnum
    {
        [Description("1min")]
        OneMin = 1,
        [Description("5min")]
        FiveMin = 2,
        [Description("15min")]
        FifteenMin = 3,
        [Description("30min")]
        ThirtyMin = 4,
        [Description("60min")]
        SixtyMin = 5,
        [Description("daily")]
        Daily = 6,
        [Description("weekly")]
        Weekly = 7,
        [Description("monthly")]
        Monthly = 8
    }
}

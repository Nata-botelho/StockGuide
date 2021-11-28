using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace StockGuide.Application.Model.Dtos.Base
{
    public abstract class BaseAverageDto<T>
        where T : BaseAverageOnTime
    {
        [JsonProperty(PropertyName = "Meta Data")]
        public AverageMetaData MetaData { get; set; }

        public abstract Dictionary<string, T> TechnicalAnalysis { get; set; }
    }

    public class AverageMetaData
    {
        [JsonProperty(PropertyName = "1: Symbol")]
        public string Symbol { get; set; }

        [JsonProperty(PropertyName = "2: Indicator")]
        public string Indicator { get; set; }

        [JsonProperty(PropertyName = "3: Last Refreshed")]
        public DateTime LastRefreshed { get; set; }

        [JsonProperty(PropertyName = "4: Interval")]
        public string Interval { get; set; }

        [JsonProperty(PropertyName = "5: Time Period")]
        public string TimePeriod { get; set; }

        [JsonProperty(PropertyName = "6: Series Type")]
        public string SeriesType { get; set; }

        [JsonProperty(PropertyName = "7: Time Zone")]
        public string TimeZone { get; set; }
    }

    public abstract class BaseAverageOnTime
    {
        public abstract double Value { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace StockGuide.Application.Model.Dtos
{
    public class DailyStockHistory
    {
        [JsonProperty(PropertyName = "Meta Data")]
        public MetaData MetaData { get; set; }

        [JsonProperty(PropertyName = "Time Series (Daily)")]
        public Dictionary<string, StockRecord> TimeSeries { get; set; }
    }

    public class MetaData
    {
        [JsonProperty(PropertyName = "1. Information")]
        public string Information { get; set; }

        [JsonProperty(PropertyName = "2. Symbol")]
        public string Symbol { get; set; }

        [JsonProperty(PropertyName = "3. Last Refreshed")]
        public DateTime LastRefreshed { get; set; }

        [JsonProperty(PropertyName = "4. Output Size")]
        public string OutputSize { get; set; }

        [JsonProperty(PropertyName = "5. Time Zone")]
        public string TimeZone { get; set; }
    }

    public class StockRecord
    {
        [JsonProperty(PropertyName = "1. open")]
        public double Open { get; set; }

        [JsonProperty(PropertyName = "2. high")]
        public double High { get; set; }

        [JsonProperty(PropertyName = "3. low")]
        public double Low { get; set; }

        [JsonProperty(PropertyName = "4. close")]
        public double Close { get; set; }

        [JsonProperty(PropertyName = "5. adjusted close")]
        public double Adjustedclose { get; set; }

        [JsonProperty(PropertyName = "6. volume")]
        public double Volume { get; set; }

        [JsonProperty(PropertyName = "7. dividend amount")]
        public double DividendAmount { get; set; }

        [JsonProperty(PropertyName = "8. split coefficient")]
        public double SplitCoefficient { get; set; }
    }
}
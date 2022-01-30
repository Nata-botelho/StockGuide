using Newtonsoft.Json;
using StockGuide.Application.Model.Dtos.Base;
using System.Collections.Generic;

namespace StockGuide.Application.Model.Dtos
{
    public class SMAAverageDto : BaseAverageDto<SMAAverageOnTime>
    {
        [JsonProperty(PropertyName = "Technical Analysis: SMA")]
        public override Dictionary<string, SMAAverageOnTime> TechnicalAnalysis { get; set; }
    }
    
    public class SMAAverageOnTime : BaseAverageOnTime
    {
        [JsonProperty(PropertyName = "SMA")]
        public override double Value { get; set; }
    }
}

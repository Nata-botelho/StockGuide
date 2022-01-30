using Newtonsoft.Json;
using StockGuide.Application.Model.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockGuide.Application.Model.Dtos
{
    public class EMAAverageDto : BaseAverageDto<EMAAverageOnTime>
    {
        [JsonProperty(PropertyName = "Technical Analysis: EMA")]
        public override Dictionary<string, EMAAverageOnTime> TechnicalAnalysis { get; set; }
    }

    public class EMAAverageOnTime : BaseAverageOnTime
    {
        [JsonProperty(PropertyName = "EMA")]
        public override double Value { get; set; }
    }
}

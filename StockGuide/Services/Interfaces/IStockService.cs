using RestSharp;
using StockGuide.Application.Model.Dtos;
using StockGuide.Application.Model.Dtos.Base;
using StockGuide.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockGuide.Services.Interfaces
{
    public interface IStockService
    {
        public DailyStockHistory GetDailyStockBySymbol(string symbol);
        public Dictionary<string, dynamic> SearchSymbol(string symbol);
        public T GetAvarage<T, S>(string symbol, AverageRequestIntervalEnum interval, AverageTypesEnum averageType, int timePeriod)
           where T : BaseAverageDto<S> where S : BaseAverageOnTime;
        public double[] GetReturnHistory(string symbol);

    }
}

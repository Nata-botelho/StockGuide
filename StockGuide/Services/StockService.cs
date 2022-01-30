using RestSharp;
using StockGuide.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.Json;
using StockGuide.Application.Model.Dtos;
using Newtonsoft.Json;
using StockGuide.Shared.Enums;
using StockGuide.Shared.Extensions;
using StockGuide.Application.Model.Dtos.Base;

namespace StockGuide.Services
{
    public class StockService : IStockService
    {
        private readonly string apiKey;
        private readonly StockCalculator _stockCalculator;

        public StockService(StockCalculator stockCalculator)
        {
            this.apiKey = Environment.GetEnvironmentVariable("AV_API_KEY");
            _stockCalculator = stockCalculator;
        }

        public DailyStockHistory GetDailyStockBySymbol(string symbol)
        {
            if (String.IsNullOrEmpty(apiKey))
                throw new Exception("Api Key not found");

            string queryUrl = "https://" + $@"www.alphavantage.co/query?function=TIME_SERIES_DAILY_ADJUSTED&symbol={symbol}&apikey={apiKey}";

            return JsonConvert.DeserializeObject<DailyStockHistory>(StockService.DoRequest(queryUrl));
        }

        public Dictionary<string, dynamic> SearchSymbol(string symbol)
        {
            string queryUrl = "https://" + $@"www.alphavantage.co/query?function=SYMBOL_SEARCH&keywords={symbol}&apikey=7NWO82CA6FDESJKV";

            return System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, dynamic>>(StockService.DoRequest(queryUrl));
        }

        public T GetAvarage<T, S>(string symbol, AverageRequestIntervalEnum interval, AverageTypesEnum averageType, int timePeriod)
            where T : BaseAverageDto<S> where S : BaseAverageOnTime
        {
            string queryUrl = "https://" + $@"www.alphavantage.co/query?function={averageType}&symbol={symbol}&interval={interval.ToDescriptionString()}&time_period={timePeriod}&series_type=closed&apikey={apiKey}";

            return JsonConvert.DeserializeObject<T>(DoRequest(queryUrl));
        }

        public double[] GetReturnHistory(string symbol)
        {
            var history = GetDailyStockBySymbol(symbol);

            var historicClosedValues = GetDoubleArray(history).Reverse().ToArray();

            return _stockCalculator.GetHistoricalReturnPercentage(historicClosedValues);
        }

        public double GetReturnAverage(string symbol)
        {
            double[] history = GetReturnHistory(symbol);
            return _stockCalculator.GetReturnAveragePercentage(history);
        }

        private static string DoRequest(string queryUrl)
        {
            Uri queryUri = new(queryUrl);

            using (WebClient client = new())
            {
                return client.DownloadString(queryUri);
            }
        }

        private static double[] GetDoubleArray(DailyStockHistory stockHistory)
        {
            double[] closedHistory = new double[stockHistory.TimeSeries.Count];

            closedHistory = stockHistory.TimeSeries.Values.Select(p => p.Close).ToArray();

            return closedHistory;
        }
    }
}

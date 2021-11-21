using RestSharp;
using StockGuide.Domain.Services.Interfaces;
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

namespace StockGuide.Domain.Services
{
    public class StockService : IStockService
    {
        private readonly string apiKey;

        public StockService()
        {
            this.apiKey = Environment.GetEnvironmentVariable("AV_API_KEY");
        }

        public DailyStockHistory GetStockBySymbol(string symbol)
        {
            if (String.IsNullOrEmpty(apiKey))
                throw new Exception("Api Key not found");

            string queryUrl = "https://" + $@"www.alphavantage.co/query?function=TIME_SERIES_DAILY_ADJUSTED&symbol={symbol}&apikey={apiKey}";

            return JsonConvert.DeserializeObject<DailyStockHistory>(StockService.DoRequest(queryUrl));
        }

        public Dictionary<string, dynamic> SearchSymbol(string symbol)
        {
            string queryUrl = "https://" + $@"www.alphavantage.co/query?function=SYMBOL_SEARCH&keywords={symbol}&apikey={apiKey}";

            return System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, dynamic>>(StockService.DoRequest(queryUrl));
        }

        private static string DoRequest(string queryUrl)
        {
            Uri queryUri = new(queryUrl);

            using (WebClient client = new())
            {
                return client.DownloadString(queryUri);
            }
        }
    }
}

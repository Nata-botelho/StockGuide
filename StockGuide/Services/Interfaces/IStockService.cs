using RestSharp;
using StockGuide.Application.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockGuide.Services.Interfaces
{
    public interface IStockService
    {
        public DailyStockHistory GetStockBySymbol(string symbol);
        public Dictionary<string, dynamic> SearchSymbol(string symbol);
    }
}

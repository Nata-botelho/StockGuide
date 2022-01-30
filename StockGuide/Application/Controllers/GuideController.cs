using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using StockGuide.Services.Interfaces;
using StockGuide.Application.Model.Dtos;
using StockGuide.Shared.Enums;
using StockGuide.Application.Model.Dtos.Base;

namespace StockGuide.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GuideController : ControllerBase
    {
        private readonly IStockService _stockService;

        public GuideController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet]
        [Route("GetStockByName")]
        public DailyStockHistory GetStockByName(string symbol)
        {
            return _stockService.GetDailyStockBySymbol(symbol);
        }

        [HttpGet]
        [Route("SearchStock")]
        public Dictionary<string, dynamic> SearchStock(string symbol)
        {
            return _stockService.SearchSymbol(symbol);
        }

        [HttpGet]
        [Route("GetSMAAvarage")]
        public SMAAverageDto GetSMAAvarage(string symbol, AverageRequestIntervalEnum interval, int timePeriod)
        {
            AverageTypesEnum averageType = AverageTypesEnum.SMA;
            return (SMAAverageDto)_stockService.GetAvarage<SMAAverageDto, SMAAverageOnTime>(symbol, interval, averageType, timePeriod);
        }

        [HttpGet]
        [Route("GetEMAAvarage")]
        public EMAAverageDto GetEMAAvarage(string symbol, AverageRequestIntervalEnum interval, int timePeriod)
        {
            AverageTypesEnum averageType = AverageTypesEnum.EMA;
            return (EMAAverageDto)_stockService.GetAvarage<EMAAverageDto, EMAAverageOnTime>(symbol, interval, averageType, timePeriod);
        }

        [HttpGet]
        [Route("GetHistoricReturn")]
        public double[] GetHistoricReturn(string symbol)
        {
            return _stockService.GetReturnHistory(symbol);
        }
    }
}

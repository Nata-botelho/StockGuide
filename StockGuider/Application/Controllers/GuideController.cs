﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockGuide.Domain.Services;
using StockGuide.Domain.Services.Interfaces;
using RestSharp;
using StockGuide.Application.Model.Dtos;

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
            return _stockService.GetStockBySymbol(symbol);
        }

        [HttpGet]
        [Route("SearchStock")]
        public Dictionary<string, dynamic> SearchStock(string symbol)
        {
            return _stockService.SearchSymbol(symbol);
        }


    }
}
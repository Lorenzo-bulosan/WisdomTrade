using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WisdomTradeApp.APIClients.AlphaVantageService;
using WisdomTradeApp.Controllers.Helpers;
using WisdomTradeApp.Data;
using WisdomTradeApp.Models;

namespace WisdomTradeApp.Controllers
{
    public class AlgorithmicTradingController : Controller
    {
        TimeSeriesService timeSeriesService;
        AlgorithmicTradingControllerHelper atcHelper;

        public AlgorithmicTradingController()
        {
            timeSeriesService = new TimeSeriesService();
            atcHelper = new AlgorithmicTradingControllerHelper();
        }
        // GET: AlgorithmicTradingViewModels
        public async Task<IActionResult> Index()
        {
            // get data
            await timeSeriesService.MakeRequestAsync("IBM");
            var closingPrice = timeSeriesService.Responses.Select(r => r.Close);
            var dates = timeSeriesService.Responses.Select(r => r.Date);

            // calculate sma
            var sma = atcHelper.GetSMA(closingPrice.ToArray(), dates.ToArray(), 5);

            ViewBag.Symbol = $"IBM";
            ViewBag.ClosingPrice = JsonConvert.SerializeObject(closingPrice);
            ViewBag.Dates = JsonConvert.SerializeObject(dates);
            ViewBag.SMAClosingPrice = JsonConvert.SerializeObject(sma.ClosingPrice);
            ViewBag.SMADates = JsonConvert.SerializeObject(sma.Dates);

            return View();
        }

    }
}

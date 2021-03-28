using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WisdomTradeApp.APIClients.AlphaVantageService;
using WisdomTradeApp.Data;
using WisdomTradeApp.Models;

namespace WisdomTradeApp.Controllers
{
    public class AlgorithmicTradingController : Controller
    {
        TimeSeriesService timeSeriesService;

        public AlgorithmicTradingController()
        {
            timeSeriesService = new TimeSeriesService();
        }
        // GET: AlgorithmicTradingViewModels
        public async Task<IActionResult> Index()
        {
            await timeSeriesService.MakeRequestAsync("IBM");
            var symbolOnResponse = timeSeriesService.JsonResponse["Meta Data"]["2. Symbol"].ToString();
            ViewBag.Test = $"From controller: {symbolOnResponse}";
            return View();
        }

    }
}

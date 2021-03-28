using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WisdomTradeApp.APIClients.AlphaVantageService;

namespace WisdomTradeApp.Controllers
{
    public class AlgorithmicTradingController : Controller
    {
        TimeSeriesService _timeSeriesService;

        public AlgorithmicTradingController()
        {
            _timeSeriesService = new TimeSeriesService();
        }

        // GET: AlgorithmicTrading
        public async Task<ActionResult> Index()
        {
            // get data
            await _timeSeriesService.MakeRequestAsync("IBM");
            ViewBag.Ticker = _timeSeriesService.JsonResponse["Meta Data"]["2. Symbol"].ToString();

            return View();
        }
    }
}

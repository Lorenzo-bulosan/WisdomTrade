using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using WisdomTradeApp.APIClients.AlphaVantageService;
using WisdomTradeApp.Controllers.Helpers;

namespace WisdomTradeApp.Controllers
{
    public class AlgorithmicTradingController : Controller
    {
        private TimeSeriesService timeSeriesService;
        private AlgorithmicTradingControllerHelper atcHelper;

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
            var sma1 = atcHelper.GetSMA(closingPrice.ToArray(), dates.ToArray(), 5);
            var sma2 = atcHelper.GetSMA(closingPrice.ToArray(), dates.ToArray(), 10);

            // data to pass
            ViewBag.Dates = JsonConvert.SerializeObject(dates);
            ViewBag.ClosingPrice = JsonConvert.SerializeObject(closingPrice);
            ViewBag.SMAClosingPrice1 = JsonConvert.SerializeObject(sma1.ClosingPrice);
            ViewBag.SMAClosingPrice2 = JsonConvert.SerializeObject(sma2.ClosingPrice);

            // IN-DEV: find entry points and exit point
            var keyPoints = atcHelper.GetEntryPoint(closingPrice.ToList<decimal>(), sma1.ClosingPrice, dates.ToList<string>());
            ViewBag.EntryPoint = keyPoints.EntryPoint;
            ViewBag.EntryPointDate = keyPoints.Date;

            return View();
        }
    }
}
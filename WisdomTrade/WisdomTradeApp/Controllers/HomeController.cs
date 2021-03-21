using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WisdomTradeApp.Data;
using WisdomTradeApp.Models;
using Microsoft.EntityFrameworkCore;

namespace WisdomTradeApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            var allPositions = _context.Positions;

            foreach(var p in allPositions)
            {
                Console.WriteLine(p.Date);

                var dayPositions = GetAllPositionsAtDate(p.Date).AsQueryable();

                foreach (var i in dayPositions)
                {
                    i.
                }


            }

            return View(await _context.Positions.ToListAsync());
        }

        private float GetPriceAverage(string ticker, DateTime date)
        {
            var matchingPositions = _context.Positions.Where(p => p.Ticker == ticker && p.Date == date);

            return matchingPositions.Sum(p => p.PricePrediction)/matchingPositions.Count(); 
        }

        private IQueryable GetAllPositionsAtDate(DateTime date)
        {
            return _context.Positions.Where(p => p.Date == date);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

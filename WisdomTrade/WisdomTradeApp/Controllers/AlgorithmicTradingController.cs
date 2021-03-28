using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WisdomTradeApp.Data;
using WisdomTradeApp.Models;

namespace WisdomTradeApp.Controllers
{
    public class AlgorithmicTradingController : Controller
    {
        public AlgorithmicTradingController()
        {

        }
        // GET: AlgorithmicTradingViewModels
        public IActionResult Index()
        {
            ViewBag.Test = "From controller";
            return View();
        }

    }
}

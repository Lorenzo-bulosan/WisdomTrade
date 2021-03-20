using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WisdomTradeApp.Models
{
    public class WisdomTrade
    {
        public int Id { get; set; }
        public string Ticker { get; set; }
        public int Population { get; set; }
        public DateTime Date { get; set; }
        public float FinalPricePrediction { get; set; }

    }
}

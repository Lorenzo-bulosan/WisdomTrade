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
        public float TotalCredit { get; set; }
        public float AverageUpperLimit { get; set; }
        public float AverageLowerLimit { get; set; }
        public bool FinalDirection { get; set; }
    }
}

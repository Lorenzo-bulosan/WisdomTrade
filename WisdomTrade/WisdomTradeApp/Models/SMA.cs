using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WisdomTradeApp.Models
{
    public class SMA
    {
        public List<decimal> ClosingPrice { get; set; }
        public List<string> Dates { get; set; }

        public SMA()
        {
            ClosingPrice = new List<decimal>();
            Dates = new List<string>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WisdomTradeApp.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Ticker { get; set; }
        public DateTime OpenDateTime { get; set; }
        public DateTime CloseDateTime { get; set; }
        public float Credit { get; set; }
        public float UpperLimit{ get; set; }
        public float LowerLimit { get; set; }
        public bool Direction { get; set; }
    }
}

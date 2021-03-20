using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WisdomTradeApp.Models
{
    // Junction table between TraderAccount-Position
    public class TraderAccount_Position
    {
        public int Id { get; set; }
        public int PositionId { get; set; }
        public string TraderEmail { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace WisdomTradeApp.APIClients.AlphaVantageService
{
    public class TimeSeriesResponse
    {
        public List<DailyPriceInformation> Responses { get; set; }       
    }
    public class DailyPriceInformation
    {
        public DateTime Timestamp { get; set; }
        public decimal Close { get; set; }
        public decimal Open { get; set; }
        public decimal Low { get; set; }
        public decimal High { get; set; }
        public decimal Volume { get; set; }
    }
}
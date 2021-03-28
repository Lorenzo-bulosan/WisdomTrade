using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WisdomTradeApp.Models;

namespace WisdomTradeApp.Controllers.Helpers
{
    public class AlgorithmicTradingControllerHelper
    {
        public SMA SMA { get; set; }

        public AlgorithmicTradingControllerHelper()
        {
            SMA = new SMA();
        }

        public SMA GetSMA(decimal[] dailyPrices, string[] days,int windowSize)
        {
            dailyPrices.Reverse();
            int laggingPointer = 0;
            int leadingPointer = windowSize;
            decimal currentSum = 0;
            decimal smaPoint = 0;

            for (int i = 0; i < dailyPrices.Count(); i++)
            {
                currentSum += dailyPrices[i];
                laggingPointer++;

                if(laggingPointer == leadingPointer)
                {
                    smaPoint = currentSum / windowSize;

                    SMA.ClosingPrice.Add(smaPoint);
                    SMA.Dates.Add(days[i]);

                    laggingPointer = 0;
                    currentSum = 0;
                }
            }
            return SMA;
        }
    }
}

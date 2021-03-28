using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WisdomTradeApp.Models;

namespace WisdomTradeApp.Controllers.Helpers
{
    public class AlgorithmicTradingControllerHelper
    {
        public AlgorithmicTradingControllerHelper()
        {
            
        }

        public SMA GetSMA(decimal[] dailyPrices, string[] days,int windowSize)
        {
            SMA sma = new SMA();

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

                    for (int x = 0; x < windowSize; x++)
                    {
                        sma.ClosingPrice.Add(smaPoint);
                    }
                    
                    //sma.Dates.Add(days[i]);

                    laggingPointer = 0;
                    currentSum = 0;
                }
            }
            return sma;
        }
    }
}

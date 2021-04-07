using System;
using System.Collections.Generic;
using System.Linq;
using WisdomTradeApp.Models;

namespace WisdomTradeApp.Controllers.Helpers
{
    public class AlgorithmicTradingControllerHelper
    {
        public AlgorithmicTradingControllerHelper()
        {
        }

        public SMA GetSMA(decimal[] dailyPrices, string[] days, int windowSize)
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

                if (laggingPointer == leadingPointer)
                {
                    smaPoint = currentSum / windowSize;

                    for (int x = 0; x < windowSize; x++)
                    {
                        sma.ClosingPrice.Add(smaPoint);
                    }

                    sma.Dates.Add(days[i]);

                    laggingPointer = 0;
                    currentSum = 0;
                }
            }
            return sma;
        }

        public (decimal EntryPoint, string Date) GetEntryPoint(List<decimal> data1, List<decimal> data2, List<string> dates)
        {
            decimal entryPoint = 0;
            string date = "";

            for (int i = 0; i < data1.Count(); i++)
            {
                if (data1[i] >= data2[i])
                {
                    entryPoint = data1[i];
                    date = dates[i];
                }
            }

            return (entryPoint, date);
        }
    }
}
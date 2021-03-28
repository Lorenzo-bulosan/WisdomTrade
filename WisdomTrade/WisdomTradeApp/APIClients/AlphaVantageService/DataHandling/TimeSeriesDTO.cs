using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.Data.Analysis;
using Newtonsoft.Json.Linq;
using System;

namespace WisdomTradeApp.APIClients.AlphaVantageService
{
    public class TimeSeriesDTO
    {

        public DailyPriceInformation DailyPriceInformation { get; set; }
        public List<DailyPriceInformation> ListOfDailyPrices { get; set; }

        public TimeSeriesDTO()
        {
            ListOfDailyPrices = new List<DailyPriceInformation>();
        }

        // method to make JObj into List of known objects daily price
        public List<DailyPriceInformation> DeserializeResponse(JObject jsonObj)
        {
            string currentDate;

            // loop through all days
            foreach (var day in jsonObj["Time Series (Daily)"])
            {
                currentDate = day.ToObject<JProperty>().Name;

                foreach (var dayPrices in day)
                {
                    DailyPriceInformation = GetDailyPriceInformation(currentDate, dayPrices);
                    ListOfDailyPrices.Add(DailyPriceInformation);
                }
            }            
            return ListOfDailyPrices;
        }

        // helper method that takes a part of JObject and creates objects of dailyprice
        private DailyPriceInformation GetDailyPriceInformation(string currentDay, JToken dayInformation)
        {
            DailyPriceInformation dailyPriceInformation = new DailyPriceInformation();

            // get values 
            string open = dayInformation["1. open"].ToString();
            string close = dayInformation["4. close"].ToString();
            string high = dayInformation["2. high"].ToString();
            string low = dayInformation["3. low"].ToString();
            string volume = dayInformation["5. volume"].ToString();

            // fill up to object
            dailyPriceInformation.Open = decimal.Parse(open);
            dailyPriceInformation.Close = decimal.Parse(close);
            dailyPriceInformation.High = decimal.Parse(high);
            dailyPriceInformation.Low = decimal.Parse(low);
            dailyPriceInformation.Volume = decimal.Parse(volume);
            dailyPriceInformation.Date = currentDay;

            return dailyPriceInformation;
        }
    }
}
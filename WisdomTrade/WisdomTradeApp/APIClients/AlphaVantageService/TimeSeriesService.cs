using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WisdomTradeApp.APIClients.AlphaVantageService
{
    // Endpoint being used Time_Series_Daily
    public class TimeSeriesService
    {
        public CallManager CallManager { get; set; }
        public TimeSeriesDTO TimeSeriesDTO { get; set; }

        public String TickerSelected { get; set; }
        public string Response { get; set; }
        public JObject JsonResponse { get; set; }

        public TimeSeriesService()
        {
            CallManager = new CallManager();
            TimeSeriesDTO = new TimeSeriesDTO();
        }

        public async Task MakeRequestAsync(string ticker)
        {
            TickerSelected = ticker;
            
            Response = await CallManager.RequestTimeSeriesAsync(TickerSelected);
            JsonResponse = JObject.Parse(Response);
            TimeSeriesDTO.DeserializeResponse(Response);
        }
    }
}

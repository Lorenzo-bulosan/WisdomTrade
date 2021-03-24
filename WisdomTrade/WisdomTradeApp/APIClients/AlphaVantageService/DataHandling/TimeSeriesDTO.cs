using Newtonsoft.Json;

namespace WisdomTradeApp.APIClients.AlphaVantageService
{
    public class TimeSeriesDTO
    {
        public TimeSeriesResponse TimeSeriesResponse { get; set; }

        // deserialize response into known object
        public void DeserializeResponse(string response)
        {
            TimeSeriesResponse = JsonConvert.DeserializeObject<TimeSeriesResponse>(response);
        }
    }
}
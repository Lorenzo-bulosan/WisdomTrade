using RestSharp;
using System;
using System.Threading.Tasks;

namespace WisdomTradeApp.APIClients.AlphaVantageService
{
    public class CallManager
    {

        readonly IRestClient _client;
        private readonly Uri BaseUrl = new Uri(AppConfigReader.BaseUrl);

        public CallManager()
        {
            _client = new RestClient { BaseUrl = BaseUrl };
        }
        private RestRequest InitialiseRequest()
        {
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("apikey", AppConfigReader.ApiKey);
            request.AddHeader("useQueryString", "true");

            return request;
        }

        public async Task<string> RequestTimeSeriesAsync(string tickerSelected, string outputsize = "compact")
        {
            var request = InitialiseRequest();

            request.Resource = $"query?function=TIME_SERIES_DAILY&symbol={tickerSelected}&outputsize={outputsize}";

            IRestResponse response = await _client.ExecuteAsync(request);

            return response.Content;
        }
    }
}
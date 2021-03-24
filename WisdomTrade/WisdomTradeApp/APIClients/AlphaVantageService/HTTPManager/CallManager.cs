using RestSharp;
using System;
using System.Configuration;
using System.Threading.Tasks;

namespace WisdomTradeApp.APIClients.AlphaVantageService
{
    public class CallManager
    {

        readonly IRestClient _client;
        private string _baseUrl = AppConfigReader.BaseUrl;
        private string _apikey = AppConfigReader.ApiKey;

        public CallManager()
        {
            //_client = new RestClient { BaseUrl = _baseUrl };
            _client = new RestClient { BaseUrl = new Uri(_baseUrl) };
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

            request.Resource = $"query?function=TIME_SERIES_DAILY&symbol={tickerSelected}&outputsize={outputsize}&apikey={_apikey}";

            IRestResponse response = await _client.ExecuteAsync(request);

            return response.Content;
        }
    }
}
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;
using WisdomTradeApp.APIClients.AlphaVantageService;

namespace APIClientTest.AlphaVantageTests
{
    public class TimeSeriesServiceTests
    {
        private TimeSeriesService _sut = new TimeSeriesService();

        [OneTimeSetUp]
        public async Task OneTimeSetUpAsync()
        {
            await _sut.MakeRequestAsync("IBM");
        }

        [Test]
        public void WhenResquestingIBM__AndUsingJsonResponse__ReturnsMetaDataWithCorrectSymbol()
        {
            var openPrice = _sut.JsonResponse["Meta Data"]["2. Symbol"].ToString();
            Assert.That(openPrice, Is.EqualTo("IBM"));
        }

        [Test]
        public void WhenResquestingIBMSpecificDate_AndUsingJsonResponse_ReturnCorrectString()
        {
            var closePrice = _sut.JsonResponse["Time Series (Daily)"]["2021-03-26"]["4. close"].ToString();
            Assert.That(closePrice, Is.EqualTo("136.3800"));
        }

        [Test]
        public void WhenResquestingIBMSpecificDate_UsingObjectResponse_ReturnCorrectString()
        {
            var dayPriceQuery = _sut.Responses.Where(r => r.Date == "2021-03-26").FirstOrDefault();
            Assert.That(dayPriceQuery.Close, Is.EqualTo(136.3800));
        }
    }
}
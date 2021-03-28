using NUnit.Framework;
using System.Threading.Tasks;
using WisdomTradeApp.APIClients.AlphaVantageService;

namespace APIClientTest.AlphaVantageTests
{
    public class TimeSeriesServiceTests
    {

        TimeSeriesService _sut = new TimeSeriesService();

        [OneTimeSetUp]
        public async Task OneTimeSetUpAsync()
        {
            await _sut.MakeRequestAsync("IBM");
        }

        [Test]
        public void WhenResquestingIBM_ReturnsMetaDataWithCorrectSymbol()
        {
            var openPrice = _sut.JsonResponse["Meta Data"]["2. Symbol"].ToString();
            Assert.That(openPrice, Is.EqualTo("IBM"));
        }
        [Test]
        public void WhenResquestingIBMSpecificDate_ReturnCorrectString()
        {
            var openPrice = _sut.JsonResponse["Time Series (Daily)"]["2021-03-26"]["4. close"].ToString();
            Assert.That(openPrice, Is.EqualTo("136.3800"));
        }
    }
}
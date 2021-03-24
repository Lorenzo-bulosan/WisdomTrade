using NUnit.Framework;
using System.Threading.Tasks;
using WisdomTradeApp.APIClients.AlphaVantageService;

namespace APIClientTest
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
        public void WhenResquestingApple_ReturnsMetaDataWithCorrectSymbol()
        {
            var symbolOnResponse = _sut.JsonResponse["Meta Data"]["2. Symbol"].ToString();
            Assert.That(symbolOnResponse, Is.EqualTo("IBM"));
        }
    }
}
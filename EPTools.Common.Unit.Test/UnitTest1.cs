using EPTools.Common.Interfaces;
using EPTools.Common.Services;

namespace EPTools.Common.Unit.Test
{
    public class Tests
    {
        IFetchService fetchService;
        EPDataService epDataService;
        LifepathService lifepathService;

        [SetUp]
        public void Setup()
        {
            fetchService = new FileFetchService();
            epDataService = new EPDataService(fetchService);
            lifepathService = new LifepathService(epDataService);
        }

        [Test]
        public async Task Test1()
        {
            var ego = await lifepathService.GenerateEgo();

            Assert.Pass();
        }
    }
}
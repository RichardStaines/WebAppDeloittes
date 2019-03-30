using NUnit.Framework;
using ClassLibraryRestConsumers;

namespace NUnitTestsRestConsumersLib
{
    public class WeatherTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestWeather()
        {
            OpenWeatherMap weatherRestConsumer = new OpenWeatherMap("London","GB");
            if (weatherRestConsumer.weatherForecast == null)
                Assert.Fail("Weather subscription Failed");
            Assert.Pass("Weather subscription PASS");
        }
    }
}

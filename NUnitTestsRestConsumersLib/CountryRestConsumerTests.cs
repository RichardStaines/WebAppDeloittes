using NUnit.Framework;
using ClassLibraryRestConsumers;

namespace NUnitTestsRestConsumersLib
{

    public class CountryRestConsumerTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestJPN()
        {
            CountryRestConsumer countryRestConsumer = new CountryRestConsumer("Japan");
            if (countryRestConsumer.alpha3.Equals("JPN") == false)
                Assert.Fail("Wrong 3 char code recieved for Japan");
            Assert.Pass("3 char country code PASS");
        }

        [Test]
        public void TestJP()
        {
            CountryRestConsumer countryRestConsumer = new CountryRestConsumer("Japan");
            if (countryRestConsumer.alpha2.Equals("JP") == false)
                Assert.Fail("Wrong 2 char code recieved for Japan");
            Assert.Pass("2 char country code test PASS for Japan");
        }

        [Test]
        public void TestGB()
        {
            CountryRestConsumer countryRestConsumer = new CountryRestConsumer("United Kingdom");
            if (countryRestConsumer.alpha2.Equals("GB") == false)
                Assert.Fail("Wrong 2 char code recieved for United Kingdom");
            Assert.Pass("2 char country code test PASS for United Kingdom");
        }

    }
}

namespace King.MQC.Unit.Test
{
    using NUnit.Framework;

    [TestFixture]
    public class MqcConfigurationTests
    {
        [Test]
        public void Constructor()
        {
            new MqcConfiguration();
        }

        [Test]
        public void Routes()
        {
            var config = new MqcConfiguration();
            Assert.AreEqual(RouteTable.Routes, config.Routes);
        }

        [Test]
        public void MapMqcAttributeRoutes()
        {
            var config = new MqcConfiguration();
            config.MapMqcAttributeRoutes();

            Assert.IsNotNull(config.Routes);
            Assert.AreEqual(2, config.Routes.Count);
            Assert.AreEqual(typeof(TestController), config.Routes["Test.Get"]);
            Assert.AreEqual(typeof(TestController), config.Routes["Test.Set"]);
        }
    }
}
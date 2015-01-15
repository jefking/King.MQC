namespace King.MQC.Unit.Test
{
    using NUnit.Framework;
    using System;
    using System.Reflection;

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

        [Test]
        public void GetControllers()
        {
            var assembly = Assembly.GetAssembly(this.GetType());

            var config = new MqcConfiguration();
            var routes = config.GetControllers(assembly);

            Assert.IsNotNull(routes);
            Assert.AreEqual(2, routes.Count);
            Assert.AreEqual(typeof(TestController), routes["Test.Get"]);
            Assert.AreEqual(typeof(TestController), routes["Test.Set"]);
        }
    }
}
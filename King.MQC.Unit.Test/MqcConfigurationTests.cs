namespace King.MQC.Unit.Test
{
    using King.MQC.Unit.Test.Routes;
    using NUnit.Framework;
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
            Assert.AreEqual(6, config.Routes.Count);
            Assert.AreEqual(typeof(TestController), config.Routes["Test/Get"]);
            Assert.AreEqual(typeof(TestController), config.Routes["Test/Set"]);
            Assert.AreEqual(typeof(TestNonController), config.Routes["TestNon/Get"]);
            Assert.AreEqual(typeof(TestNonController), config.Routes["TestNon/Set"]);
            Assert.AreEqual(typeof(TestBlahBlah), config.Routes["TestBlahBlah/Get"]);
            Assert.AreEqual(typeof(TestBlahBlah), config.Routes["TestBlahBlah/Set"]);
        }

        [Test]
        public void GetControllers()
        {
            var assembly = Assembly.GetAssembly(this.GetType());

            var config = new MqcConfiguration();
            var routes = config.GetControllers(assembly);

            Assert.IsNotNull(routes);
            Assert.AreEqual(4, routes.Count);
            Assert.AreEqual(typeof(TestController), routes["Test/Get"]);
            Assert.AreEqual(typeof(TestController), routes["Test/Set"]);
            Assert.AreEqual(typeof(TestBlahBlah), config.Routes["TestBlahBlah/Get"]);
            Assert.AreEqual(typeof(TestBlahBlah), config.Routes["TestBlahBlah/Set"]);
        }

        [Test]
        public void GetAttributes()
        {
            var assembly = Assembly.GetAssembly(this.GetType());

            var config = new MqcConfiguration();
            var routes = config.GetAttributes(assembly);

            Assert.IsNotNull(routes);
            Assert.AreEqual(2, routes.Count);
            Assert.AreEqual(typeof(TestNonController), routes["TestNon/Get"]);
            Assert.AreEqual(typeof(TestNonController), routes["TestNon/Set"]);
        }
    }
}
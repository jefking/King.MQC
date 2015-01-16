namespace King.MQC.Unit.Test
{
    using King.MQC.Unit.Test.Routes;
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

        [TestCase("Test/Get", typeof(TestController), "Get")]
        [TestCase("Test/Set", typeof(TestController), "Set")]
        [TestCase("TestNon/Red", typeof(TestNonController), "Get")]
        [TestCase("TestNon/Blue", typeof(TestNonController), "Set")]
        [TestCase("TestBlahBlah/Get", typeof(TestBlahBlah), "Get")]
        [TestCase("TestBlahBlah/Set", typeof(TestBlahBlah), "Set")]
        public void MapMqcAttributeRoutes(string route, Type type, string method)
        {
            var config = new MqcConfiguration();
            config.MapMqcAttributeRoutes();

            Assert.AreEqual(type, config.Routes[route].Type);
            Assert.AreEqual(method, config.Routes[route].Method);
        }

        [Test]
        public void MapMqcAttributeRoutesCount()
        {
            var config = new MqcConfiguration();
            config.MapMqcAttributeRoutes();

            Assert.IsNotNull(config.Routes);
            Assert.AreEqual(6, config.Routes.Count);
        }

        [TestCase("Test/Get", typeof(TestController), "Get")]
        [TestCase("Test/Set", typeof(TestController), "Set")]
        [TestCase("TestBlahBlah/Get", typeof(TestBlahBlah), "Get")]
        [TestCase("TestBlahBlah/Set", typeof(TestBlahBlah), "Set")]
        public void GetControllers(string route, Type type, string method)
        {
            var assembly = Assembly.GetAssembly(this.GetType());

            var config = new MqcConfiguration();
            var routes = config.GetControllers(assembly);

            Assert.AreEqual(type, config.Routes[route].Type);
            Assert.AreEqual(method, config.Routes[route].Method);
        }

        [Test]
        public void GetControllersCount()
        {
            var assembly = Assembly.GetAssembly(this.GetType());

            var config = new MqcConfiguration();
            var routes = config.GetControllers(assembly);

            Assert.IsNotNull(routes);
            Assert.AreEqual(4, routes.Count);
        }

        [TestCase("TestNon/Red", typeof(TestNonController), "Get")]
        [TestCase("TestNon/Blue", typeof(TestNonController), "Set")]
        public void GetAttributes(string route, Type type, string method)
        {
            var assembly = Assembly.GetAssembly(this.GetType());

            var config = new MqcConfiguration();
            var routes = config.GetAttributes(assembly);

            var routeType = routes[route];
            Assert.AreEqual(type, routeType.Type);
            Assert.AreEqual(method, routeType.Method);
        }

        [Test]
        public void GetAttributesCount()
        {
            var assembly = Assembly.GetAssembly(this.GetType());

            var config = new MqcConfiguration();
            var routes = config.GetAttributes(assembly);

            Assert.IsNotNull(routes);
            Assert.AreEqual(2, routes.Count);
        }
    }
}
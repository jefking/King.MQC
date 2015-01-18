namespace King.MQC.Unit.Test
{
    using King.MQC.Routing;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class RouteCollectionTests
    {
        [Test]
        public void Constructor()
        {
            new RouteCollection();
        }

        [Test]
        public void IsSortedDictionary()
        {
            Assert.IsNotNull(new RouteCollection() as SortedDictionary<string, RouteEntry>);
        }

        [Test]
        public void Add()
        {
            var className = Guid.NewGuid().ToString();
            var methodName = Guid.NewGuid().ToString();
            var type = typeof(RouteCollectionTests);

            var routes = new RouteCollection();
            routes.Add(className, methodName, type);

            var key = string.Format("{0}/{1}", className, methodName);
            Assert.IsNotNull(routes[key]);
            Assert.AreEqual(routes[key].Type, type);
            Assert.AreEqual(routes[key].Method, methodName);
        }
    }
}
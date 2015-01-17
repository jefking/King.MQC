namespace King.MQC.Unit.Test
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DirectRouteTests
    {
        [SetUp]
        public void Setup()
        {
            var config = new MqcConfiguration();
            config.MapMqcAttributeRoutes();
        }

        [Test]
        public void Constructor()
        {
            new DirectRoute();
        }

        [Test]
        public void IsIQueue()
        {
            Assert.IsNotNull(new DirectRoute() as IRouteTo);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void InvokeRouteNull()
        {
            var queue = new DirectRoute();
            queue.Invoke(null);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void InvokeRouteUnknown()
        {
            var queue = new DirectRoute();
            queue.Invoke(Guid.NewGuid().ToString());
        }

        [Test]
        public void TestRoundTrip()
        {
            var random = new Random();
            var expected = random.Next();

            var queue = new DirectRoute();
            queue.Send("Test/Blue", expected);

            var value = queue.Get<int>("Test/Get");

            Assert.AreEqual(expected, value);
        }

        [Test]
        public void TestNonRoundTrip()
        {
            var random = new Random();
            var expected = random.Next();

            var queue = new DirectRoute();
            queue.Send("TestNon/Set", expected);

            var value = queue.Get<int>("TestNon/Red");

            Assert.AreEqual(expected, value);
        }
    }
}
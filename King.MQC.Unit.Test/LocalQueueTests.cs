namespace King.MQC.Unit.Test
{
    using King.Route;
    using NSubstitute;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class LocalQueueTests
    {
        [SetUp]
        public void Setup()
        {
            var config = new RoutingConfiguration();
            config.MapMqcAttributeRoutes();
        }

        [Test]
        public void Constructor()
        {
            new LocalQueue();
        }

        [Test]
        public void IsIRouteTo()
        {
            Assert.IsNotNull(new LocalQueue() as IRouteTo);
        }

        [Test]
        public void Send()
        {
            var queue = new LocalQueue();
            queue.Send(Guid.NewGuid().ToString());
        }

        [Test]
        public void SendWithModel()
        {
            var queue = new LocalQueue();
            queue.Send(Guid.NewGuid().ToString(), new object());
        }

        [Test]
        [Category("Integration")]
        public void RoundTrip()
        {
            var random = new Random();
            var expected = random.Next();

            var queue = new LocalQueue();
            queue.Send("Test/Set", expected);

            var value = queue.Get<int>("Test/Get");

            Assert.AreEqual(expected, value);
        }

        [Test]
        public void Get()
        {
            var data = Guid.NewGuid();
            var route = Guid.NewGuid().ToString();
            var direct = Substitute.For<IRouteTo>();
            direct.Get<Guid>(route, null).Returns(data);

            var queue = new LocalQueue(direct);
            queue.Send(route, data);
            var value = queue.Get<Guid>(route);

            Assert.AreEqual(data, value);
            direct.Received().Get<Guid>(route, null);
        }

        [Test]
        public void GetWithModel()
        {
            var data = Guid.NewGuid();
            var route = Guid.NewGuid().ToString();
            var model = new object();
            var direct = Substitute.For<IRouteTo>();
            direct.Get<Guid>(route, model).Returns(data);

            var queue = new LocalQueue(direct);
            queue.Send(route, data);
            var value = queue.Get<Guid>(route, model);

            Assert.AreEqual(data, value);
            direct.Received().Get<Guid>(route, model);
        }
    }
}
namespace King.MQC.Unit.Test
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DirectQueueTests
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
            new DirectQueue();
        }

        [Test]
        public void IsIQueue()
        {
            Assert.IsNotNull(new DirectQueue() as IQueue);
        }

        [Test]
        public void TestRoundTrip()
        {
            var random = new Random();
            var expected = random.Next();

            var queue = new DirectQueue();
            queue.Send("Test/Set", expected);

            var value = queue.Get<int>("Test/Get");

            Assert.AreEqual(expected, value);
        }

        [Test]
        public void TestNonRoundTrip()
        {
            var random = new Random();
            var expected = random.Next();

            var queue = new DirectQueue();
            queue.Send("TestNon/Blue", expected);

            var value = queue.Get<int>("TestNon/Red");

            Assert.AreEqual(expected, value);
        }
    }
}
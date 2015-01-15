namespace King.MQC.Unit.Test
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DirectQueueTests
    {
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
            queue.Send("Test.Set", expected);

            var value = queue.Get<int>("Test.Get");

            Assert.AreEqual(expected, value);
        }
    }
}
namespace King.MQC.Unit.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;

    [TestFixture]
    public class LocalQueueTests
    {
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
        public void Get()
        {
            var queue = new LocalQueue();
            queue.Get<object>(Guid.NewGuid().ToString());
        }

        [Test]
        public void GetWithModel()
        {
            var queue = new LocalQueue();
            queue.Get<object>(Guid.NewGuid().ToString(), new object());
        }
    }
}
namespace King.MQC.Unit.Test
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class RouteEntryTests
    {
        [Test]
        public void Constructor()
        {
            new RouteEntry();
        }

        [Test]
        public void Type()
        {
            var expected = this.GetType();

            var re = new RouteEntry
            {
                Type = expected,
            };

            Assert.AreEqual(expected, re.Type);
        }

        [Test]
        public void Method()
        {
            var expected = Guid.NewGuid().ToString();

            var re = new RouteEntry
            {
                Method = expected,
            };

            Assert.AreEqual(expected, re.Method);
        }
    }
}
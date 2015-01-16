namespace King.MQC.Unit.Test
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class RouteAttributeTests
    {
        [Test]
        public void Constructor()
        {
            new RouteAttribute(Guid.NewGuid().ToString());
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorNameNull()
        {
            new RouteAttribute(null);
        }

        [Test]
        public void Name()
        {
            var expected = Guid.NewGuid().ToString();
            
            var ra = new RouteAttribute(expected);

            Assert.AreEqual(expected, ra.Name);
        }
    }
}
namespace King.MQC.Unit.Test
{
    using King.MQC.Routing;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class RouteAttributeTests
    {
        [Test]
        public void Constructor()
        {
            new RouteAliasAttribute(Guid.NewGuid().ToString());
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorNameNull()
        {
            new RouteAliasAttribute(null);
        }

        [Test]
        public void Name()
        {
            var expected = Guid.NewGuid().ToString();
            
            var ra = new RouteAliasAttribute(expected);

            Assert.AreEqual(expected, ra.Name);
        }
    }
}
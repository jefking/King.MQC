namespace King.MQC.Unit.Test
{
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
            Assert.IsNotNull(new RouteCollection() as SortedDictionary<string, Type>);
        }
    }
}
namespace King.MQC.Unit.Test
{
    using NUnit.Framework;
    using System;
    using System.Reflection;

    [TestFixture]
    public class MqControllerTests
    {
        [Test]
        public void Constructor()
        {
            new MqController();
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorQueueNull()
        {
            new MqController(null);
        }
    }
}
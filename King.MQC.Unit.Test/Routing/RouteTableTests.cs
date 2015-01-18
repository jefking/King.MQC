namespace King.MQC.Unit.Test
{
    using King.MQC.Routing;
    using NUnit.Framework;

    [TestFixture]
    public class RouteTableTests
    {
        [Test]
        public void Routes()
        {
            Assert.IsNotNull(RouteTable.Routes);
        }
    }
}
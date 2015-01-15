namespace King.MQC.Unit.Test
{
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
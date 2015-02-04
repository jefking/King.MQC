namespace King.MQC.Unit.Test
{
    using King.Route;
    using NUnit.Framework;

    [TestFixture]
    public class GlobalConfigurationTests
    {
        [Test]
        public void ConfigureCallBackNull()
        {
            GlobalConfiguration.Configure(null);
        }

        [Test]
        public void Configure()
        {
            GlobalConfiguration.Configure(Call);

            Assert.AreEqual(1, this.callCount);
        }

        private byte callCount = 0;
        private void Call(RoutingConfiguration config)
        {
            this.callCount++;
        }
    }
}
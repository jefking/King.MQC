namespace King.MQC.Unit.Test
{
    using NUnit.Framework;

    [TestFixture]
    public class GlobalConfigurationTests
    {
        [Test]
        public void Configure()
        {
            GlobalConfiguration.Configure(null);
        }
    }
}
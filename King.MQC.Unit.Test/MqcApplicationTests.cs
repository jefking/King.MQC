namespace King.MQC.Unit.Test
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class MqcApplicationTests
    {
        [Test]
        public void Constructor()
        {
            new MqcApplication();
        }

        [Test]
        public void IsIDisposable()
        {
            Assert.IsNotNull(new MqcApplication() as IDisposable);
        }

        [Test]
        public void Start()
        {
            using (var app = new MqcApplication())
            {
                app.Start();
            }
        }

        [Test]
        public void End()
        {
            using (var app = new MqcApplication())
            {
                app.End();
            }
        }

        [Test]
        public void Dispose()
        {
            using (var app = new MqcApplication())
            {
            }
        }
    }
}
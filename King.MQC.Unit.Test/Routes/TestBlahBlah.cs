namespace King.MQC.Unit.Test.Routes
{
    using King.MQC.Routing;

    /// <summary>
    /// Test Controller without Controller in the name
    /// </summary>
    public class TestBlahBlah : MqController
    {
        private static volatile int data = 0;

        public int Get()
        {
            return data;
        }

        [RouteAlias("Blue")]
        public void Set(int id)
        {
            data = id;
        }
    }
}
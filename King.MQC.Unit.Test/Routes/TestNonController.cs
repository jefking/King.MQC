namespace King.MQC.Unit.Test.Routes
{
    using King.MQC.Routing;

    /// <summary>
    /// Attribute based Controller
    /// </summary>
    [RouteAlias("TestNon")]
    public class TestNonController
    {
        private static volatile int data = 0;

        [RouteAlias("Red")]
        public int Get()
        {
            return data;
        }

        public void Set(int id)
        {
            data = id;
        }
    }
}
namespace King.MQC.Unit.Test.Routes
{
    using King.Route;

    /// <summary>
    /// Controller
    /// </summary>
    public class TestController : IRoutableController
    {
        private static volatile int data = 0;

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
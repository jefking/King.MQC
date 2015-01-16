namespace King.MQC.Unit.Test.Routes
{
    /// <summary>
    /// Attribute based Controller
    /// </summary>
    [Route("TestNon")]
    public class TestNonController
    {
        private static volatile int data = 0;

        [Route("Red")]
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
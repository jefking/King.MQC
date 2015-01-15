namespace King.MQC.Unit.Test
{
    [Route("TestNon")]
    public class TestNonController
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
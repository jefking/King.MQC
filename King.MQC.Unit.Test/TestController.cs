namespace King.MQC.Unit.Test
{
    public class TestController : MqController
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
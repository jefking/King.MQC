namespace King.MQC
{
    public interface IQueue
    {
        void Send(string route, object model);
        T Get<T>(string route, object model = null);
    }
}
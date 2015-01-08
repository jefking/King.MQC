namespace King.MQC
{
    using System.Collections.Generic;

    public class LocalQueue : IQueue
    {
        protected readonly Stack<object> data = new Stack<object>();

        public void Send(string route, object model)
        {
            this.data.Push(model);
        }

        public T Get<T>(string route, object model = null)
        {
            return default(T);
        }
    }
}

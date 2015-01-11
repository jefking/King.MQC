namespace King.MQC
{
    using System.Collections.Generic;

    public class LocalQueue : IQueue
    {
        protected readonly IDictionary<string, Stack<object>> data = new Dictionary<string, Stack<object>>();

        public void Send(string route, object model)
        {
            if (!data.ContainsKey(route))
            {
                this.data.Add(route, new Stack<object>());
            }

            this.data[route].Push(model);
        }

        public T Get<T>(string route, object model = null)
        {
            return default(T);
        }
    }
}
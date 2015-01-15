namespace King.MQC
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>
    /// Temporary Fake Queue, to demonstrate items entering queue, via route
    /// </summary>
    public class LocalQueue : IQueue
    {
        #region Members
        /// <summary>
        /// Key:String; Route
        /// Stack:String; data in Json
        /// </summary>
        protected readonly IDictionary<string, Stack<string>> data = new Dictionary<string, Stack<string>>();
        #endregion

        #region Methods
        public void Send(string route, object model)
        {
            if (!data.ContainsKey(route))
            {
                this.data.Add(route, new Stack<string>());
            }

            this.data[route].Push(JsonConvert.SerializeObject(model));
        }

        public T Get<T>(string route, object model = null)
        {
            return this.data.ContainsKey(route) ? JsonConvert.DeserializeObject<T>(this.data[route].Pop()) : default(T);
        }
        #endregion
    }
}
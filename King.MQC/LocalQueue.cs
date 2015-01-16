namespace King.MQC
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// In application queuing
    /// </summary>
    public class LocalQueue : IRouteTo
    {
        #region Members
        /// <summary>
        /// Key:String; Route
        /// Stack:String; data in Json
        /// </summary>
        protected readonly IDictionary<string, Stack<string>> data = new Dictionary<string, Stack<string>>();
        #endregion

        #region Methods
        /// <summary>
        /// Send
        /// </summary>
        /// <param name="route">Route</param>
        /// <param name="model">Model</param>
        public virtual void Send(string route, object model = null)
        {
            if (!data.ContainsKey(route))
            {
                this.data.Add(route, new Stack<string>());
            }

            var serialized = null == model ? (string)null : JsonConvert.SerializeObject(model);
            this.data[route].Push(serialized);
        }

        /// <summary>
        /// Get Data
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="route">Route</param>
        /// <param name="model">Model</param>
        /// <returns>Data</returns>
        public virtual T Get<T>(string route, object model = null)
        {
            if (!data.ContainsKey(route))
            {
                this.data.Add(route, new Stack<string>());
            }

            var value = default(T);
            if (this.data.ContainsKey(route) && this.data[route].Any())
            {
                var inQueue = this.data[route].Pop();
                if (!string.IsNullOrWhiteSpace(inQueue))
                {
                    value = JsonConvert.DeserializeObject<T>(inQueue);
                }
            }

            return value;
        }
        #endregion
    }
}
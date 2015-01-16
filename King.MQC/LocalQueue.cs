namespace King.MQC
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>
    /// In application queuing
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

            this.data[route].Push(JsonConvert.SerializeObject(model));
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
            return this.data.ContainsKey(route) ? JsonConvert.DeserializeObject<T>(this.data[route].Pop()) : default(T);
        }
        #endregion
    }
}
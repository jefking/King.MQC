﻿namespace King.MQC
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

        /// <summary>
        /// Direct Route to
        /// </summary>
        protected readonly IRouteTo direct = null;
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public LocalQueue()
            : this(new DirectRoute())
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="direct"></param>
        public LocalQueue(IRouteTo direct)
        {
            this.direct = direct;
        }
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
            return this.direct.Get<T>(route, model);
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void Dequeue()
        {
            foreach (var key in this.data.Keys)
            {
                var d = this.data[key].Pop();
                if (null != d)
                {
                    this.direct.Send(key, d);
                }
            }
        }
        #endregion
    }
}
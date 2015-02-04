namespace King.MQC
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using King.Route;

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
        protected readonly IDictionary<string, Stack<object>> data = new Dictionary<string, Stack<object>>();

        /// <summary>
        /// Direct Route to
        /// </summary>
        protected readonly IRouteTo direct = null;
        #endregion

        #region Constructors
        /// <summary>
        /// Default Constructor
        /// </summary>
        public LocalQueue()
            : this(new DirectRoute())
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="direct">Direct Route</param>
        public LocalQueue(IRouteTo direct)
        {
            if (null == direct)
            {
                throw new ArgumentNullException("direct");
            }

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
                this.data.Add(route, new Stack<object>());
            }

            this.data[route].Push(model);

            ThreadPool.QueueUserWorkItem(_ => Dequeue()); //Dequeue on background thread; temp.
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
        /// Dequeue
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
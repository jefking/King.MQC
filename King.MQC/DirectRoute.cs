namespace King.MQC
{
    using System;
    using System.Reflection;

    /// <summary>
    /// Direct Route, no queue (default)
    /// </summary>
    public class DirectRoute : IRouteTo
    {
        #region Members
        /// <summary>
        /// Method Binding Flags
        /// </summary>
        protected static readonly BindingFlags methodFlags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.DeclaredOnly;
        #endregion

        #region Methods
        /// <summary>
        /// Send
        /// </summary>
        /// <param name="route">Route</param>
        /// <param name="model">Model</param>
        public virtual void Send(string route, object model = null)
        {
            this.Invoke(route, model);
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
            return (T)this.Invoke(route, model);
        }

        /// <summary>
        /// Invoke Route
        /// </summary>
        /// <param name="route">Route</param>
        /// <param name="model">Model</param>
        /// <returns>Return Value</returns>
        public virtual object Invoke(string route, object model = null)
        {
            if (string.IsNullOrWhiteSpace(route))
            {
                throw new InvalidOperationException("Route is empty, ensure caller is specifying a route.");
            }
            if (!RouteTable.Routes.ContainsKey(route))
            {
                throw new InvalidOperationException(string.Format("Unknown route: '{0}.", route));
            }

            var entry = RouteTable.Routes[route];
            var paramaters = null == model ? null : new[] { model };
            var obj = Activator.CreateInstance(entry.Type);
            return entry.Type.InvokeMember(entry.Method, methodFlags, null, obj, paramaters);
        }
        #endregion
    }
}
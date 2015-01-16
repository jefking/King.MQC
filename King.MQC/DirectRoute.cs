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
        protected static BindingFlags methodFlags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.DeclaredOnly;
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
            var t = RouteTable.Routes[route];
            var obj = Activator.CreateInstance(t.Type);
            var paramaters = null == model ? null : new[] { model };
            return t.Type.InvokeMember(t.Method, methodFlags, null, obj, paramaters);
        }
        #endregion
    }
}
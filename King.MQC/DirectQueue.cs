namespace King.MQC
{
    using System;
    using System.Reflection;

    /// <summary>
    /// Deftault 'Queue'; direct binding
    /// </summary>
    public class DirectQueue : IQueue
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
            var t = RouteTable.Routes[route];
            var obj = Activator.CreateInstance(t.Type);
            t.Type.InvokeMember(t.Method, methodFlags, null, obj, new[] { model });
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
            var t = RouteTable.Routes[route];
            var methodName = route.Substring(route.LastIndexOf('/') + 1);
            var obj = Activator.CreateInstance(t.Type);
            return (T)t.Type.InvokeMember(t.Method, methodFlags, null, obj, null);
        }
        #endregion
    }
}
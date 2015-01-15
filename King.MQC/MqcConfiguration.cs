namespace King.MQC
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Linq;

    /// <summary>
    /// MQC Configuration
    /// </summary>
    /// <remarks>
    /// Configuration passed to registration event
    /// </remarks>
    public class MqcConfiguration
    {
        #region Members
        /// <summary>
        /// Queue
        /// </summary>
        protected IQueue queue;
        #endregion

        #region Properties
        /// <summary>
        /// Routes
        /// </summary>
        public RouteCollection Routes
        {
            get
            {
                return RouteTable.Routes;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Map MQC Attribute Routes
        /// </summary>
        public void MapMqcAttributeRoutes()
        {
            //Map routes dynamically

            var assembly = Assembly.GetCallingAssembly();

            // Get all MqControllers
            var controllers = from cls in assembly.GetTypes()
                              where cls.BaseType == typeof(MqController)
                              select cls;

            foreach (var type in controllers)
            {
                var classRoute = type.Name.EndsWith("Controller") ? type.Name.Replace("Controller", string.Empty) : type.Name;
                foreach (var method in type.GetMembers(BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod))
                {
                    var route = string.Format("{0}.{1}", classRoute, method.Name);

                    this.Routes.Add(route, type);
                }
            }

            // Get all Routes
        }

        /// <summary>
        /// Default Queue
        /// </summary>
        /// <param name="queue">Queue</param>
        public void DefaultQueue(IQueue queue)
        {
            this.queue = queue;
        }
        #endregion
    }
}
namespace King.MQC
{
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// MQC Configuration
    /// </summary>
    public class MqcConfiguration
    {
        #region Members
        /// <summary>
        /// Queue
        /// </summary>
        protected IQueue queue;

        /// <summary>
        /// Method Binding Flags
        /// </summary>
        protected static BindingFlags methodFlags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.DeclaredOnly;
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
        public virtual void MapMqcAttributeRoutes()
        {
            var assembly = Assembly.GetCallingAssembly();

            // Get all MqControllers
            foreach (var route in this.GetControllers(assembly))
            {
                if (!this.Routes.ContainsKey(route.Key))
                {
                    this.Routes.Add(route.Key, route.Value);
                }
            }

            // Get all Routes
        }

        /// <summary>
        /// Get Routing via Controllers
        /// </summary>
        /// <param name="assembly">Assembly</param>
        /// <returns>Route Collection</returns>
        public virtual RouteCollection GetControllers(Assembly assembly)
        {
            var routes = new RouteCollection();
            var controllers = from cls in assembly.GetTypes()
                              where cls.BaseType == typeof(MqController)
                              select cls;

            foreach (var type in controllers)
            {
                var classRoute = type.Name.EndsWith("Controller") ? type.Name.Replace("Controller", string.Empty) : type.Name;

                var methods = from meth in type.GetMembers(methodFlags)
                              where meth.MemberType != MemberTypes.Constructor
                              select meth.Name;

                foreach (var method in methods)
                {
                    var route = string.Format("{0}.{1}", classRoute, method);

                    routes.Add(route, type);
                }
            }

            return routes;
        }

        /// <summary>
        /// Default Queue
        /// </summary>
        /// <param name="queue">Queue</param>
        public virtual void DefaultQueue(IQueue queue)
        {
            this.queue = queue;
        }
        #endregion
    }
}
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

            foreach (var route in this.GetControllers(assembly).Where(r => !this.Routes.ContainsKey(r.Key)))
            {
                this.Routes.Add(route.Key, route.Value);
            }

            foreach (var route in this.GetAttributes(assembly).Where(r => !this.Routes.ContainsKey(r.Key)))
            {
                this.Routes.Add(route.Key, route.Value);
            }
        }

        /// <summary>
        /// Get Routing via Controllers
        /// </summary>
        /// <param name="assembly">Assembly</param>
        /// <returns>Route Collection</returns>
        public virtual RouteCollection GetControllers(Assembly assembly)
        {
            var routes = new RouteCollection();

            foreach (var type in assembly.GetTypes().Where(cls => cls.BaseType == typeof(MqController)))
            {
                var className = type.Name.EndsWith("Controller") ? type.Name.Replace("Controller", string.Empty) : type.Name;

                foreach (var methodName in type.GetMembers(methodFlags).Where(m => m.MemberType != MemberTypes.Constructor).Select(m => m.Name))
                {
                    routes.Add(className, methodName, type);
                }
            }

            return routes;
        }

        /// <summary>
        /// Get Attributes
        /// </summary>
        /// <param name="assembly">Assembly</param>
        /// <returns>Route Collection</returns>
        public virtual RouteCollection GetAttributes(Assembly assembly)
        {
            var routes = new RouteCollection();

            foreach (var type in assembly.GetTypes())
            {
                var attribute = type.GetCustomAttribute<RouteAttribute>(false);
                if (null != attribute)
                {
                    foreach (var methodName in type.GetMembers(methodFlags).Where(m => m.MemberType != MemberTypes.Constructor).Select(m => m.Name))
                    {
                        routes.Add(attribute.Name, methodName, type);
                    }
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
namespace King.MQC
{
    using System;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// MQC Configuration
    /// </summary>
    public class MqcConfiguration
    {
        #region Members
        /// <summary>
        /// Route To
        /// </summary>
        protected IRouteTo router;

        /// <summary>
        /// Method Binding Flags
        /// </summary>
        protected static readonly BindingFlags methodFlags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.DeclaredOnly;
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

        /// <summary>
        /// Default Router
        /// </summary>
        public IRouteTo DefaultRouter
        {
            get;
            set;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Map MQC Attribute Routes
        /// </summary>
        public virtual void MapMqcAttributeRoutes()
        {
            var assembly = Assembly.GetCallingAssembly();

            this.Routes.Merge(this.GetControllers(assembly));
            this.Routes.Merge(this.GetAttributes(assembly));
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
                routes.Merge(this.GetMethods(type, className));
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
                    routes.Merge(this.GetMethods(type, attribute.Name));
                }
            }

            return routes;
        }

        /// <summary>
        /// Get Methods
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="className">Class Name</param>
        /// <returns>Routable Methods</returns>
        public virtual RouteCollection GetMethods(Type type, string className)
        {
            var routes = new RouteCollection();

            foreach (var method in type.GetMembers(methodFlags).Where(m => m.MemberType != MemberTypes.Constructor))
            {
                var attribute = method.GetCustomAttribute<RouteAttribute>(false);
                var alias = null == attribute ? method.Name : attribute.Name;
                routes.Add(className, alias, type, method.Name);
            }

            return routes;
        }
        #endregion
    }
}
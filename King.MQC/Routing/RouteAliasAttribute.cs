namespace King.MQC.Routing
{
    using System;

    /// <summary>
    /// Attribute based routing
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class RouteAliasAttribute : Attribute
    {
        #region Members
        /// <summary>
        /// Route Name
        /// </summary>
        protected readonly string name;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Route Name</param>
        public RouteAliasAttribute(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("name");
            }

            this.name = name;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Route Name
        /// </summary>
        public virtual string Name
        {
            get
            {
                return this.name;
            }
        }
        #endregion
    }
}
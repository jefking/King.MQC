namespace King.MQC
{
    using System;

    /// <summary>
    /// Route Attribute
    /// </summary>
    /// <remarks>
    /// Attribute based routing
    /// </remarks>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
    public class RouteAttribute : Attribute
    {
        #region Members
        /// <summary>
        /// Route Name
        /// </summary>
        protected readonly string name;
        #endregion

        #region Constructors
        /// <summary>
        /// Default Constructor
        /// </summary>
        public RouteAttribute()
            :this(Guid.NewGuid().ToString()) //Set-up auto-mapping
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Route Name</param>
        public RouteAttribute(string name)
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
        public string Name
        {
            get
            {
                return this.name;
            }
        }
        #endregion
    }
}
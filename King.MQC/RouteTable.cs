namespace King.MQC
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Route Table
    /// </summary>
    /// <remarks>
    /// Developers can override routing with custom actions
    /// </remarks>
    public class RouteTable
    {
        #region Members
        /// <summary>
        /// Routes
        /// </summary>
        protected static readonly RouteCollection routes = new RouteCollection();
        #endregion

        #region Properties
        /// <summary>
        /// Routes
        /// </summary>
        public static RouteCollection Routes
        {
            get
            {
                return routes;
            }
        }
        #endregion
    }
}
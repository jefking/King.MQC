namespace King.MQC
{
    /// <summary>
    /// Route Table
    /// </summary>
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
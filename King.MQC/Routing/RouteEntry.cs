namespace King.MQC.Routing
{
    using System;

    /// <summary>
    /// Route Entry
    /// </summary>
    public class RouteEntry
    {
        #region Properties
        /// <summary>
        /// Type
        /// </summary>
        public virtual Type Type
        {
            get;
            set;
        }

        /// <summary>
        /// Method
        /// </summary>
        public virtual string Method
        {
            get;
            set;
        }
        #endregion
    }
}
namespace King.MQC
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Collection or Route Data
    /// </summary>
    public class RouteCollection : SortedDictionary<string, Type>
    {
        #region Methods
        /// <summary>
        /// Add Route
        /// </summary>
        /// <param name="className">Class Name</param>
        /// <param name="methodName">Method Name</param>
        /// <param name="type">Type</param>
        public void Add(string className, string methodName, Type type)
        {
            var route = string.Format("{0}/{1}", className, methodName);
            this.Add(route, type);
        }
        #endregion
    }
}
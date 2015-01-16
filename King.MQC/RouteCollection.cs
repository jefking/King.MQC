namespace King.MQC
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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
            this.Add(string.Format("{0}/{1}", className, methodName), type);
        }

        /// <summary>
        /// Merge Collections
        /// </summary>
        /// <param name="collection">Collection</param>
        public virtual void Merge(RouteCollection collection)
        {
            if (null != collection)
            {
                foreach (var route in collection.Where(r => !this.ContainsKey(r.Key)))
                {
                    this.Add(route.Key, route.Value);
                }
            }
        }
        #endregion
    }
}
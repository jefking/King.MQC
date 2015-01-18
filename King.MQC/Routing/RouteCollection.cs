namespace King.MQC.Routing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Collection or Route Data
    /// </summary>
    public class RouteCollection : SortedDictionary<string, RouteEntry>
    {
        #region Methods
        /// <summary>
        /// Add Route
        /// </summary>
        /// <param name="className">Class Name</param>
        /// <param name="alias"></param>
        /// <param name="type">Type</param>
        /// <param name="methodName">Method Name</param>
        public virtual void Add(string className, string alias, Type type, string methodName = null)
        {
            var route = new RouteEntry
            {
                Type = type,
                Method = methodName ?? alias,
            };

            this.Add(string.Format("{0}/{1}", className, alias), route);
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
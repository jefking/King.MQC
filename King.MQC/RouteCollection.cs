namespace King.MQC
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Collection or Route Data
    /// </summary>
    public class RouteCollection : SortedDictionary<string, Type>
    {
        public void Add(string className, string methodName, Type type)
        {
            var route = string.Format("{0}/{1}", className, methodName);
            this.Add(route, type);
        }
    }
}
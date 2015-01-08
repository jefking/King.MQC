namespace King.MQC
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    /// <summary>
    /// MQC Configuration
    /// </summary>
    /// <remarks>
    /// Configuration passed to registration event
    /// </remarks>
    public class MqcConfiguration
    {
        #region Properties
        /// <summary>
        /// Queue
        /// </summary>
        protected IQueue queue;
        #endregion

        #region Properties
        /// <summary>
        /// Routes
        /// </summary>
        public IDictionary<string, Type> Routes
        {
            get
            {
                return RouteTable.Routes;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Map MQC Attribute Routes
        /// </summary>
        public void MapMqcAttributeRoutes()
        {
            //Map routes dynamically

            var assembly = Assembly.GetExecutingAssembly();

            foreach (var type in assembly.GetTypes())
            {
                if (type.BaseType == typeof(MqController))
                {

                }
            }

            // Get all MqControllers
            // Get all Routes
        }

        /// <summary>
        /// Default Queue
        /// </summary>
        /// <param name="queue">Queue</param>
        public void DefaultQueue(IQueue queue)
        {
            this.queue = queue;
        }
        #endregion
    }
}
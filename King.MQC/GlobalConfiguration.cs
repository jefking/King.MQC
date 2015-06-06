namespace King.MQC
{
    using System;
    using King.Route;

    /// <summary>
    /// MQC Global Configuration
    /// </summary>
    /// <remarks>
    /// Enables registration of routes, and application wire up.
    /// </remarks>
    public class GlobalConfiguration
    {
        #region Methods
        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="configurationCallback">Configuration Callback</param>
        public static void Configure(Action<RoutingConfiguration> configurationCallback)
        {
            if (null != configurationCallback)
            {
                configurationCallback.Invoke(new RoutingConfiguration());
            }
        }
        #endregion
    }
}
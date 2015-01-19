namespace King.MQC
{
    using System;

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
        public static void Configure(Action<MqcConfiguration> configurationCallback)
        {
            if (null != configurationCallback)
            {
                configurationCallback.Invoke(new MqcConfiguration());
            }
        }
        #endregion
    }
}
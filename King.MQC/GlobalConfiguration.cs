namespace King.MQC
{
    using System;

    /// <summary>
    /// MQC Global Configuration
    /// </summary>
    /// <remarks>
    /// Enables registration of routes, and application wire up.
    /// </remarks>
    public virtual class GlobalConfiguration
    {
        #region Methods
        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="configurationCallback">Configuration Callback</param>
        public virtual static void Configure(Action<MqcConfiguration> configurationCallback)
        {
            //Call Registration
        }
        #endregion
    }
}
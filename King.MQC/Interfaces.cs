namespace King.MQC
{
    #region IQueue
    /// <summary>
    /// Route To Interface
    /// </summary>
    public interface IRouteTo
    {
        #region Methods
        /// <summary>
        /// Send
        /// </summary>
        /// <param name="route">Route</param>
        /// <param name="model">Model</param>
        void Send(string route, object model = null);

        /// <summary>
        /// Get Data
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="route">Route</param>
        /// <param name="model">Model</param>
        /// <returns>Data</returns>
        T Get<T>(string route, object model = null);
        #endregion
    }
    #endregion
}
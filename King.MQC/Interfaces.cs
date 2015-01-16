namespace King.MQC
{
    #region IQueue
    /// <summary>
    /// Queue Interface
    /// </summary>
    public interface IQueue
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
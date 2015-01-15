namespace King.MQC
{
    /// <summary>
    /// Deftault 'Queue'; direct binding
    /// </summary>
    public class DirectQueue : IQueue
    {
        #region Methods
        /// <summary>
        /// Send
        /// </summary>
        /// <param name="route">Route</param>
        /// <param name="model">Model</param>
        public virtual void Send(string route, object model)
        {
        }

        /// <summary>
        /// Get Data
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="route">Route</param>
        /// <param name="model">Model</param>
        /// <returns>Data</returns>
        public virtual T Get<T>(string route, object model = null)
        {
            return default(T);
        }
        #endregion
    }
}
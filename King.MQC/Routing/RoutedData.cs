namespace King.MQC.Routing
{
    /// <summary>
    /// Routed Data
    /// </summary>
    /// <typeparam name="T">Model</typeparam>
    public class RoutedData<T>
    {
        #region Properties
        /// <summary>
        /// Route
        /// </summary>
        public virtual string Route
        {
            get;
            set;
        }

        /// <summary>
        /// Model
        /// </summary>
        public virtual T Model
        {
            get;
            set;
        }
        #endregion
    }
}
namespace King.MQC
{
    using System;

    /// <summary>
    /// Model Queue Controller Application
    /// </summary>
    /// <remarks>
    /// Enables loading and running of framework
    /// </remarks>
    public class MqcApplication : IDisposable
    {
        #region Constructors
        /// <summary>
        /// Deconstructor
        /// </summary>
        ~MqcApplication()
        {
            this.Dispose(false);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Start
        /// </summary>
        public virtual void Start()
        {
        }

        /// <summary>
        /// End
        /// </summary>
        public virtual void End()
        {
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing">Disposing</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
        }
        #endregion
    }
}
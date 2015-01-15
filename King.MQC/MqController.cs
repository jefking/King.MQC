namespace King.MQC
{
    using System;

    /// <summary>
    /// Model Queue Controller
    /// </summary>
    /// <remarks>
    /// Enable users to extend a Model Queue Controller
    /// </remarks>
    public class MqController
    {
        #region Members
        /// <summary>
        /// Queue
        /// </summary>
        protected readonly IQueue queue = null;
        #endregion

        #region Constructors
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <remarks>
        /// Default 'queue', direct calling
        /// </remarks>
        public MqController()
            : this(new DirectQueue())
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="queue">Queue</param>
        public MqController(IQueue queue)
        {
            if (null == queue)
            {
                throw new ArgumentNullException("queue");
            }

            this.queue = queue;
        }
        #endregion
    }
}
namespace King.MQC
{
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
            this.queue = queue;
        }
        #endregion
    }
}
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
        /// Route To
        /// </summary>
        protected readonly IRouteTo router = null;
        #endregion

        #region Constructors
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <remarks>
        /// Default 'queue', direct calling
        /// </remarks>
        public MqController()
            : this(new DirectRoute())
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="router">Route To</param>
        public MqController(IRouteTo router)
        {
            if (null == router)
            {
                throw new ArgumentNullException("router");
            }

            this.router = router;
        }
        #endregion
    }
}
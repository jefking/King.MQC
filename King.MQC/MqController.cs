namespace King.MQC
{
    using System;
    using King.Route;

    /// <summary>
    /// Model Queue Controller
    /// </summary>
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
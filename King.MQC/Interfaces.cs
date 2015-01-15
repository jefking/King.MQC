namespace King.MQC
{
    #region IQueue
    public interface IQueue
    {
        #region Methods
        void Send(string route, object model);
        T Get<T>(string route, object model = null);
        #endregion
    }
    #endregion
}
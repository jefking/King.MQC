namespace King.MQC.Program
{
    using System.Diagnostics;

    [Route("Actions")]
    public class ActionsController : MqController
    {
        public void Do()
        {
            base.queue.Send("Actions.Done", new object());
        }
        public void Done()
        {
            Trace.TraceInformation("Actions.Done");
        }
    }
}
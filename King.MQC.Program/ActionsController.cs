﻿namespace King.MQC.Program
{
    using System.Diagnostics;

    public class ActionsController : MqController
    {
        public void Do()
        {
            base.router.Send("Actions.Done");
        }

        public void Done()
        {
            Trace.TraceInformation("Actions.Done");
        }
    }
}
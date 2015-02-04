namespace King.MQC.Program
{
    using King.Route;

    public class Startup : MqcApplication
    {
        public override void Start()
        {
            //Should these be handled seperately?
            GlobalConfiguration.Configure(MqcConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            base.Start();
        }

        public override void End()
        {
            base.End();
        }
    }
}
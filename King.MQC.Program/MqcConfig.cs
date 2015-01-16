namespace King.MQC.Program
{
    public class MqcConfig
    {
        public static void Register(MqcConfiguration config)
        {
            // MQC routes
            config.MapMqcAttributeRoutes();

            // Default Queue
            config.DefaultQueue(new DirectQueue()); //Queue types should be based on routing rules
        }
    }
}
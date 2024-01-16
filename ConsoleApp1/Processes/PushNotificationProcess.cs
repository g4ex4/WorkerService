using Microsoft.Extensions.Configuration;

namespace ConsoleApp1.Processes
{
    public class PushNotificationProcess : BaseProcess
    {
        public PushNotificationProcess(IConfiguration configuration) : base(configuration)
        {
        }
    }
}

using Microsoft.Extensions.Configuration;

namespace ConsoleApp1.Processes
{
    public class SmsNotificationProcess : BaseProcess
    {
        public SmsNotificationProcess(IConfiguration configuration) : base(configuration)
        {
        }
    }
}

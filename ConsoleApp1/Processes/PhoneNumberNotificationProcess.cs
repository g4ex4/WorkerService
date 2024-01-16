using Microsoft.Extensions.Configuration;

namespace ConsoleApp1.Processes
{
    public class PhoneNumberNotificationProcess : BaseProcess
    {
        public PhoneNumberNotificationProcess(IConfiguration configuration) : base(configuration)
        {
            
        }
    }
}

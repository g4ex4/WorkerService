using Microsoft.Extensions.Configuration;

namespace ConsoleApp1.Processes
{
    public class EmailNotificationProcess : BaseProcess
    {
        public EmailNotificationProcess(IConfiguration configuration) : base(configuration)
        {
        }
    }
}

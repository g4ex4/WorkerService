using Microsoft.Extensions.Configuration;
namespace ConsoleApp1.Processes
{
    public class PaymentNotificationProcess : BaseProcess
    {
        public PaymentNotificationProcess(IConfiguration configuration) : base(configuration)
        {
        }
    }
}

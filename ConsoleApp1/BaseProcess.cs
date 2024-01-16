using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ConsoleApp1
{
    public abstract class BaseProcess : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly int? _startTime;

        public virtual void Start()
        {
            Console.WriteLine($"{DateTimeOffset.Now} running {GetType().Name} processor");
        }
        public BaseProcess(IConfiguration configuration)
        {
            _configuration = configuration;
            _startTime = _configuration.GetSection("application").Get<List<ProcessConfiguration>>()
                .FirstOrDefault(x => x.ClassName == GetType().Name && x.IsRunning)?
                .StartTime;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromMilliseconds(_startTime.GetValueOrDefault()), stoppingToken);
                Start();
            }
        }
    }
}
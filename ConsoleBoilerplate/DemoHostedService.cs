using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
 
namespace ConsoleBoilerplate
{
    public class DemoHostedService : IHostedService
    {
        private readonly IConfiguration config;
        private readonly ILogger logger;
 
        public DemoHostedService(IConfiguration config, ILogger<DemoHostedService> logger)
        {
            this.config = config;
            this.logger = logger;
        }
 
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine(nameof(DemoHostedService) + "Starting...");
 
            Stopwatch stopwatch = Stopwatch.StartNew();

            #region business logic
                // todo
                Console.WriteLine("Hello world");
            #endregion
 
            stopwatch.Stop();
 
            logger.LogInformation("Logging - Execute Elapsed Times:{}ms", stopwatch.ElapsedMilliseconds);
 
            return Task.FromResult(0);
        }
 
        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine(nameof(DemoHostedService) + "Stoped");
            return Task.FromResult(0);
        }
 
    }
}
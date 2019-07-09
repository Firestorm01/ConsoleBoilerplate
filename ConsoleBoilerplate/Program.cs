using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.IO;
using Polly;
using System;

namespace ConsoleBoilerplate
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new HostBuilder()
                .ConfigureHostConfiguration(configHost =>
                {
                    configHost.SetBasePath(Directory.GetCurrentDirectory());
                })
                .ConfigureAppConfiguration(configApp =>
                {
                    configApp.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureServices((context, services) =>
                {
                    //DB access sample：services.AddTransient<IDbAccesser>(provider =>
                    //{
                    //    string connStr = context.Configuration.GetConnectionString("ConnDbStr");
                    //    return new SqlDapperEasyUtil(connStr);
                    //});
 
                    //HttpClient sample：services.AddHttpClient<GitHubApiClient>()
                    //.AddTransientHttpErrorPolicy(builder => builder.WaitAndRetryAsync(3, t => TimeSpan.FromMilliseconds(800)));
 
                    services.AddHostedService<DemoHostedService>();
                })
                .ConfigureLogging((context, configLogging) =>
                {
                    configLogging.ClearProviders();
                    configLogging.SetMinimumLevel(LogLevel.Trace);
                    configLogging.AddNLog(context.Configuration);
                })
                .UseConsoleLifetime()
                .Build();
 
            host.Run();
        }
    }
}

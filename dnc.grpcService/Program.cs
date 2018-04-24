using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;


namespace dnc.grpcService
{
    class Program
    {
        static void Main(string[] args)
        {
            //日志参考https://github.com/NLog/NLog.Extensions.Logging/blob/master/examples/NetCore2/ConsoleExample/Program.cs
            var logger = NLog.LogManager.LoadConfiguration("nlog.config").GetCurrentClassLogger();
            try
            {
                var servicesProvider = BuildDi();

                Console.WriteLine("Press ANY key to exit");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Stopped program because of exception");
                throw;
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }

        private static IServiceProvider BuildDi()
        {
            var services = new ServiceCollection();


            services.AddSingleton<ILoggerFactory, LoggerFactory>();
            services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
            services.AddLogging((builder) => builder.SetMinimumLevel(LogLevel.Trace));

            var serviceProvider = services.BuildServiceProvider();

            var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

            //configure NLog
            loggerFactory.AddNLog(new NLogProviderOptions { CaptureMessageTemplates = true, CaptureMessageProperties = true });
            return serviceProvider;
        }
    }
}

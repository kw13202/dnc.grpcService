using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using dnc.grpcService.protocol;
using dnc.grpcService.Repository;
using dnc.grpcService.Untils;
using Dnc.GrpcService.Protocol;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;


namespace dnc.grpcService
{
    class Program
    {

        static void Main(string[] args)
        {
            //var builder = new ConfigurationBuilder()
            //    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            //var configuration = builder.Build();

            //string connectionString = configuration.GetConnectionString("ConfigDataBase");

            ////var history = new dnc.grpcService.Model.History(){ HistoryName = "test", StartDate = DateTime.Parse("2018-5-1"), EndDate = DateTime.Parse("2018-5-2") };

            //List< Model.History > list = new List<History>();
            //using (var db = DbFactory.Create(connectionString))
            //{
            //    //db.TbHistory.Add(history);
            //    //context.SaveChanges();

            //    list = db.TbHistory.AsNoTracking().ToList();
            //}

            //foreach (var item in list)
            //{
            //    Console.WriteLine(item.ToString());
            //}

            //日志参考https://github.com/NLog/NLog.Extensions.Logging/blob/master/examples/NetCore2/ConsoleExample/Program.cs
            try
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .Build();

                ServiceCollection serviceCollection = new ServiceCollection();

                serviceCollection.AddSingleton(configuration);

                serviceCollection.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
                serviceCollection.AddSingleton<ILoggerFactory, LoggerFactory>();
                serviceCollection.AddLogging((builder) => builder.SetMinimumLevel(LogLevel.Trace));

                serviceCollection.AddDbContext<RpcDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConfigDataBase")));

                //serviceCollection.AddScoped<HistoryDAL>();
                //ConfigureServices(serviceCollection);

                // Create service provider
                IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

                var context = serviceProvider.GetRequiredService<RpcDbContext>();
                DbFactory.Init(context);
                var list = context.TbHoliday.AsNoTracking().ToList();
                foreach (var item in list)
                {
                    Console.WriteLine(item.ToString());
                }

                var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
                loggerFactory.AddNLog(new NLogProviderOptions { CaptureMessageTemplates = true, CaptureMessageProperties = true });

                Server server = new Server
                {
                    Services = { HolidayService.BindService(new HolidayServiceImpl(serviceProvider)) },
                    Ports = { new ServerPort("localhost", 15111, ServerCredentials.Insecure) }
                };
                server.Start();
                LogHelper.Debug($"rpc启动，开始监听{15111}端口");
                LogHelper.Debug("输入任何字符停止服务");

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex, "程序出错");
                throw;
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }

        //private static void ConfigureServices(IServiceCollection serviceCollection)
        //{
        //    Configuration = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.json" , optional: true, reloadOnChange: true)
        //        .Build();

        //    //log
        //    serviceCollection.AddSingleton<ILoggerFactory, LoggerFactory>();
        //    serviceCollection.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
        //    serviceCollection.AddLogging((builder) => builder.SetMinimumLevel(LogLevel.Trace));

        //    serviceCollection.AddDbContext<RpcDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConfigDataBase")));

        //    serviceCollection.AddSingleton<IConfigurationRoot>(Configuration);

        //}


    }
}

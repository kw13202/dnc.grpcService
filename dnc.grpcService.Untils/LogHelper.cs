using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NLog.Config;
using NLog.Targets;
using NLog.Targets.Wrappers;

namespace dnc.grpcService.Untils
{
    public class LogHelper
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        static LogHelper()
        {
            #region 使用代码初始化
            //// Step 1. Create configuration object 
            //var config = new LoggingConfiguration();

            //// Step 2. Create targets and add them to the configuration 
            //var consoleTarget = new ColoredConsoleTarget();
            //config.AddTarget("console", consoleTarget);

            //var fileTarget = new FileTarget();
            //config.AddTarget("file", fileTarget);

            //var asyncFile = new AsyncTargetWrapper();
            //asyncFile.WrappedTarget = fileTarget;
            //config.AddTarget("asyncFile", asyncFile);


            //// Step 3. Set target properties
            //consoleTarget.Layout = @"${date:format=HH\:mm\:ss} ${level} ${message} ${exception}";
            //fileTarget.FileName = "${basedir}/Log/log_${shortdate}.txt";
            //fileTarget.Layout = @"${date:format=HH\:mm\:ss} ${level} ${message} ${exception}";

            //// Step 4. Define rules
            //// Trace<<Debug<<Info<<Warn<<Error<<Fatal
            //var rule1 = new LoggingRule("*", LogLevel.Debug, consoleTarget);
            //config.LoggingRules.Add(rule1);

            //var rule2 = new LoggingRule("*", LogLevel.Debug, fileTarget);
            //config.LoggingRules.Add(rule2);

            //// Step 5. Activate the configuration
            //LogManager.Configuration = config;
            #endregion
        }


        public static void Trace(string message)
        {
            Logger.Trace(message);
        }

        public static void Debug(string message)
        {
            Logger.Debug(message);
        }

        public static void Info(string message)
        {
            Logger.Info(message);
        }

        public static void Warn(string message)
        {
            Logger.Warn(message);
        }

        public static void Error(string message)
        {
            Logger.Error(message);
        }

        public static void Error(Exception ex, string message)
        {
            Logger.Error(ex, message);
        }





    }
}

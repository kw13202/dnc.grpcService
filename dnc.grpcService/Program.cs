using System;


namespace dnc.grpcService
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = NLog.LogManager.LoadConfiguration("nlog.config").GetCurrentClassLogger();

            Console.WriteLine("Hello World!");
        }
    }
}

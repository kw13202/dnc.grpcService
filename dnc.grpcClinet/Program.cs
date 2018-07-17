using Grpc.Core;
using System;
using Dnc.GrpcService.Protocol;

namespace dnc.grpcClinet
{
    class Program
    {
        static void Main(string[] args)
        {
            var channel = new Channel($"127.0.0.1:15111", SslCredentials.Insecure);
            var client = new HolidayService.HolidayServiceClient(channel);
            var rsp = client.GetHolidays(new GetHolidaysReq() { });
            foreach (var item in rsp.Holidays)
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dnc.grpcService.Repository;
using dnc.grpcService.Untils;
using Dnc.GrpcService.Protocol;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace dnc.grpcService.protocol
{
    public class HolidayServiceImpl : HolidayService.HolidayServiceBase
    {
        private RpcDbContext _context;

        public HolidayServiceImpl(IServiceProvider provider)
        {
            _context = provider.GetRequiredService<RpcDbContext>();

        }

        public override Task<GetHolidaysRsp> GetHolidays(GetHolidaysReq request, ServerCallContext context)
        {
            var result = new GetHolidaysRsp();
            try
            {
                result.RetCode = 1;
                //result.Histories.AddRange(_context.TbHistory.AsNoTracking().ToList());
            }
            catch (Exception e)
            {
                LogHelper.Error(e, "GetHistories error");
                result.RetCode = -1;
                result.RetDesc = e.Message;
            }
            return base.GetHolidays(request, context);
        }
    }
}

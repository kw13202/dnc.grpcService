using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dnc.grpcService.Model;
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
        private readonly RpcDbContext _context;

        public HolidayServiceImpl(IServiceProvider provider)
        {
            _context = provider.GetRequiredService<RpcDbContext>();

        }

        public override async Task<GetHolidaysRsp> GetHolidays(GetHolidaysReq request, ServerCallContext context)
        {
            var result = new GetHolidaysRsp();
            try
            {
                result.RetCode = 1;
                Parallel.ForEach(await _context.TbHoliday.AsNoTracking().ToListAsync(), x =>
                {
                    result.Holidays.Add(new HolidayVM(){ Id = x.Id, HolidayName = x.HolidayName, StartDate = x.StartDate.ToString("yyyy-MM-dd HH:mm:ss"), EndDate = x.EndDate.ToString("yyyy-MM-dd HH:mm:ss") });
                });
                //result.Holidays.AddRange(_context.TbHoliday.AsNoTracking().ToList());
            }
            catch (Exception e)
            {
                LogHelper.Error(e, "GetHistories error");
                result.RetCode = -1;
                result.RetDesc = e.Message;
            }
            return result;
        }

        public override async Task<AddHolidaysRsp> AddHolidays(AddHolidaysReq request, ServerCallContext context)
        {
            var result = new AddHolidaysRsp();
            try
            {
                var model = new Holiday()
                {
                    HolidayName = request.HolidayName,
                    StartDate = DateTime.Parse(request.StartDate),
                    EndDate = DateTime.Parse(request.EndDate),
                };
                await _context.TbHoliday.AddAsync(model);
                result.Id = model.Id;
            }
            catch (Exception e)
            {
                LogHelper.Error(e, "AddHolidays error");
                result.RetCode = -1;
                result.RetDesc = e.Message;
            }
            return result;
        }
    }
}

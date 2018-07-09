using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dnc.grpcService.Model;
using Microsoft.EntityFrameworkCore;

namespace dnc.grpcService.Repository
{
    public class HolidayDAL
    {
        private readonly RpcDbContext _context;

        public HolidayDAL(RpcDbContext context)
        {
            _context = context;
        }

        public List<Holiday> GetList()
        {
            return _context.TbHoliday.AsNoTracking().ToList();
        }
    }
}

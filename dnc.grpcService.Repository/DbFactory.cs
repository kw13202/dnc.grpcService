using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace dnc.grpcService.Repository
{
    public static class DbFactory
    {
        public static RpcDbContext Create(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RpcDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            var context = new RpcDbContext(optionsBuilder.Options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            return context;
        }

        public static void Init(RpcDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if (context.TbHoliday.Any())
            {
                return;
            }

            var history = new dnc.grpcService.Model.Holiday() { HolidayName = "test", StartDate = DateTime.Parse("2018-5-1"), EndDate = DateTime.Parse("2018-5-2") };
            context.TbHoliday.Add(history);
            context.SaveChanges();
        }
    }
}

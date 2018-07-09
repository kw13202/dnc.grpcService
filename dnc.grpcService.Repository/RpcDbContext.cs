using System;
using System.Collections.Generic;
using System.Text;
using dnc.grpcService.Model;
using Microsoft.EntityFrameworkCore;

namespace dnc.grpcService.Repository
{
    public class RpcDbContext : DbContext
    {
        public RpcDbContext(DbContextOptions<RpcDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyDatabase;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Holiday>().ToTable("Holiday");
            modelBuilder.Entity<Holiday>().HasKey(x => x.Id);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Holiday> TbHoliday { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace dnc.grpcService.Model
{
    public class Holiday
    {
        public Holiday()
        {
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
        }

        public int Id { get; set; }
        public string HolidayName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Remark { get; set; }

        public override string ToString()
        {
            return
                $"HolidayName:{HolidayName},StartDate:{StartDate:yyyy-MM-dd},EndDate:{EndDate:yyyy-MM-dd}";
        }
    }
}

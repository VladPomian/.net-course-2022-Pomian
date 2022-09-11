using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Filters
{
    public class ClientFilter
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public int Passport { get; set; }
        public int Phone { get; set; } 
        public DateTime BirthDayRangeStart { get; set; }
        public DateTime BirthDayRangeEnd { get; set; }
    }
}

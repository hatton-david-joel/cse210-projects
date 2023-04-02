using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenHoursChecker.Dto {
    public class DayHours {
        public DayOfWeek DayOfWeek { get; set; }
        public Hours? Open { get; set; }
        public Hours? Close { get; set; }
    }
}

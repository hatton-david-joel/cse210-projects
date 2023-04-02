using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenHoursChecker.Dto {
    public class BusinessInfo {
        public string? Title { get; set; }
        public string? PlaceId { get; set; }
        public List<DayHours>? Hours { get; set; }
    }
}

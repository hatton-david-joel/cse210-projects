using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenHoursChecker.Dto {
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Close {
        public int day { get; set; }
        public string time { get; set; }
    }

    public class Open {
        public int day { get; set; }
        public string time { get; set; }
    }

    public class OpeningHours {
        public bool open_now { get; set; }
        public List<Period> periods { get; set; }
        public List<string> weekday_text { get; set; }
    }

    public class Period {
        public Close close { get; set; }
        public Open open { get; set; }
    }

    public class Result {
        public OpeningHours opening_hours { get; set; }
    }

    public class GoogleResponse {
        public List<object> html_attributions { get; set; }
        public Result result { get; set; }
        public string status { get; set; }
    }


}

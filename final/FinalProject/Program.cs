using Newtonsoft.Json;
using OpenHoursChecker.Dto;
using System.Net.Mail;
using System.Net;

var client = new HttpClient();
client.BaseAddress = new Uri("https://maps.googleapis.com/");

var defaultHourData = File.ReadAllText("default_hours.json");
var defaultHours = JsonConvert.DeserializeObject<List<BusinessInfo>>(defaultHourData);

foreach(var defaultHour in defaultHours!) {
    var response = await client.GetAsync($"/maps/api/place/details/json?key=AIzaSyDLaahJFSrEuFt-jLw5V5_LTwvL0_MMYEk&place_id={defaultHour.PlaceId}&fields=opening_hours");
    var responseData = await response.Content.ReadAsStringAsync();
    var googleResponse = JsonConvert.DeserializeObject<GoogleResponse>(responseData);

    var daysMatch = true;

    foreach (var period in googleResponse.result.opening_hours.periods) {
        var defaultDay = defaultHour.Hours.Where(x => x.DayOfWeek == (DayOfWeek)period.open.day).FirstOrDefault();

        var openHour = Convert.ToInt32(period.open.time.Substring(0, 2));
        var openMinute = Convert.ToInt32(period.open.time.Substring(2, 2));

        var closeHour = Convert.ToInt32(period.close.time.Substring(0, 2));
        var closeMinute = Convert.ToInt32(period.close.time.Substring(2, 2));

        if (openHour != defaultDay.Open.Hour || openMinute != defaultDay.Open.Minute || closeHour != defaultDay.Close.Hour || closeMinute != defaultDay.Close.Minute) {
            daysMatch = false;
        }
    }

    if (!daysMatch) {
        var fromAddress = new MailAddress("davidjoelhatton@gmail.com", "David Hatton");
        var toAddress = new MailAddress("dhatton@fivestarparks.com", "David Hatton");
        const string fromPassword = "kvchumkbuognroxo";
        string subject = $"{defaultHour.Title}'s Hours Have Changed";
        string body = @$"
        Original:
            Sunday: {defaultHour.Hours.First(x => x.DayOfWeek == DayOfWeek.Sunday).Open.Hour}{defaultHour.Hours.First(x => x.DayOfWeek == DayOfWeek.Sunday).Open.Minute.ToString("D2")} - {defaultHour.Hours.First(x => x.DayOfWeek == DayOfWeek.Sunday).Close.Hour}{defaultHour.Hours.First(x => x.DayOfWeek == DayOfWeek.Sunday).Close.Minute.ToString("D2")}
            Monday: {defaultHour.Hours.First(x => x.DayOfWeek == DayOfWeek.Monday).Open.Hour}{defaultHour.Hours.First(x => x.DayOfWeek == DayOfWeek.Monday).Open.Minute.ToString("D2")} - {defaultHour.Hours.First(x => x.DayOfWeek == DayOfWeek.Monday).Close.Hour}{defaultHour.Hours.First(x => x.DayOfWeek == DayOfWeek.Monday).Close.Minute.ToString("D2")}
            Tuesday: {defaultHour.Hours.First(x => x.DayOfWeek == DayOfWeek.Tuesday).Open.Hour}{defaultHour.Hours.First(x => x.DayOfWeek == DayOfWeek.Tuesday).Open.Minute.ToString("D2")} - {defaultHour.Hours.First(x => x.DayOfWeek == DayOfWeek.Tuesday).Close.Hour}{defaultHour.Hours.First(x => x.DayOfWeek == DayOfWeek.Tuesday).Close.Minute.ToString("D2")}
            Wednesday: {defaultHour.Hours.First(x => x.DayOfWeek == DayOfWeek.Wednesday).Open.Hour}{defaultHour.Hours.First(x => x.DayOfWeek == DayOfWeek.Wednesday).Open.Minute.ToString("D2")} - {defaultHour.Hours.First(x => x.DayOfWeek == DayOfWeek.Wednesday).Close.Hour}{defaultHour.Hours.First(x => x.DayOfWeek == DayOfWeek.Wednesday).Close.Minute.ToString("D2")}
            Thursday: {defaultHour.Hours.First(x => x.DayOfWeek == DayOfWeek.Thursday).Open.Hour}{defaultHour.Hours.First(x => x.DayOfWeek == DayOfWeek.Thursday).Open.Minute.ToString("D2")} - {defaultHour.Hours.First(x => x.DayOfWeek == DayOfWeek.Thursday).Close.Hour}{defaultHour.Hours.First(x => x.DayOfWeek == DayOfWeek.Thursday).Close.Minute.ToString("D2")}
            Friday: {defaultHour.Hours.First(x => x.DayOfWeek == DayOfWeek.Friday).Open.Hour}{defaultHour.Hours.First(x => x.DayOfWeek == DayOfWeek.Friday).Open.Minute.ToString("D2")} - {defaultHour.Hours.First(x => x.DayOfWeek == DayOfWeek.Friday).Close.Hour}{defaultHour.Hours.First(x => x.DayOfWeek == DayOfWeek.Friday).Close.Minute.ToString("D2")}
            Saturday: {defaultHour.Hours.First(x => x.DayOfWeek == DayOfWeek.Saturday).Open.Hour}{defaultHour.Hours.First(x => x.DayOfWeek == DayOfWeek.Saturday).Open.Minute.ToString("D2")} - {defaultHour.Hours.First(x => x.DayOfWeek == DayOfWeek.Saturday).Close.Hour}{defaultHour.Hours.First(x => x.DayOfWeek == DayOfWeek.Saturday).Close.Minute.ToString("D2")}
        
        Updated:";
        if (googleResponse.result.opening_hours.periods.FirstOrDefault(x => DayOfWeek.Sunday == (DayOfWeek)x.open.day) != null) {
            body += @$"
            Sunday: {googleResponse.result.opening_hours.periods.First(x => DayOfWeek.Sunday == (DayOfWeek)x.open.day).open.time} - {googleResponse.result.opening_hours.periods.First(x => DayOfWeek.Sunday == (DayOfWeek)x.close.day).close.time}";
        }

        if (googleResponse.result.opening_hours.periods.FirstOrDefault(x => DayOfWeek.Monday == (DayOfWeek)x.open.day) != null) {
            body += @$"
            Monday: {googleResponse.result.opening_hours.periods.First(x => DayOfWeek.Monday == (DayOfWeek)x.open.day).open.time} - {googleResponse.result.opening_hours.periods.First(x => DayOfWeek.Monday == (DayOfWeek)x.close.day).close.time}";
        }

        if (googleResponse.result.opening_hours.periods.FirstOrDefault(x => DayOfWeek.Tuesday == (DayOfWeek)x.open.day) != null) {
            body += $@"
            Tuesday: {googleResponse.result.opening_hours.periods.First(x => DayOfWeek.Tuesday == (DayOfWeek)x.open.day).open.time} - {googleResponse.result.opening_hours.periods.First(x => DayOfWeek.Tuesday == (DayOfWeek)x.close.day).close.time}";
        }

        if (googleResponse.result.opening_hours.periods.FirstOrDefault(x => DayOfWeek.Wednesday == (DayOfWeek)x.open.day) != null) {
            body += $@"
            Wednesday: {googleResponse.result.opening_hours.periods.First(x => DayOfWeek.Wednesday == (DayOfWeek)x.open.day).open.time} - {googleResponse.result.opening_hours.periods.First(x => DayOfWeek.Wednesday == (DayOfWeek)x.close.day).close.time}";
        }

        if (googleResponse.result.opening_hours.periods.FirstOrDefault(x => DayOfWeek.Thursday == (DayOfWeek)x.open.day) != null) {
            body += $@"
            Thursday: {googleResponse.result.opening_hours.periods.First(x => DayOfWeek.Thursday == (DayOfWeek)x.open.day).open.time} - {googleResponse.result.opening_hours.periods.First(x => DayOfWeek.Thursday == (DayOfWeek)x.close.day).close.time}";
        }

        if (googleResponse.result.opening_hours.periods.FirstOrDefault(x => DayOfWeek.Friday == (DayOfWeek)x.open.day) != null) {
            body += $@"
            Friday: {googleResponse.result.opening_hours.periods.First(x => DayOfWeek.Friday == (DayOfWeek)x.open.day).open.time} - {googleResponse.result.opening_hours.periods.First(x => DayOfWeek.Friday == (DayOfWeek)x.close.day).close.time}";
        }

        if (googleResponse.result.opening_hours.periods.FirstOrDefault(x => DayOfWeek.Saturday == (DayOfWeek)x.open.day) != null) {
            body += $@"
            Saturday: {googleResponse.result.opening_hours.periods.First(x => DayOfWeek.Saturday == (DayOfWeek)x.open.day).open.time} - {googleResponse.result.opening_hours.periods.First(x => DayOfWeek.Saturday == (DayOfWeek)x.close.day).close.time}";
        }

        var smtp = new SmtpClient {
            Host = "smtp.gmail.com",
            Port = 587,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
        };
        using (var message = new MailMessage(fromAddress, toAddress) {
            Subject = subject,
            Body = body
        }) {
            smtp.Send(message);
        }
    }
}
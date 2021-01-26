using System;

namespace WebScrapper.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime GetToday()
        {
            return DateTime.Today;
        }
    }
}

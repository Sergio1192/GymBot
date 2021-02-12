using System;

namespace GymVideosGetter.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime GetToday()
        {
            return DateTime.Today;
        }
    }
}

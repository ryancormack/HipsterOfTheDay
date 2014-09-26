using System;

namespace HispterOfTheDay.Domain.Helpers
{
    public class DateTimeHelper : IDateTimeHelper
    {
        public DateTime UtcNow { get { return DateTime.UtcNow; } }
    }
}

using System;
using System.Globalization;
using HispterOfTheDay.Domain.Helpers;
using Machine.Specifications;

namespace HipsterOfTheDay.Domain.Tests.Helpers
{
    class DateTimeHelperTests
    {
        Because of = () =>
        {
            _sut.UtcNow.ToString();
        };

        It should_return_valid_utc_date_time = () =>
        {
            var isValid = (DateTime.TryParseExact(_sut.ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None,
                                        out _dateTime));
        };

        Establish context = () =>
        {
            _sut = new DateTimeHelper();
        };
        private static DateTimeHelper _sut;
        static DateTime _dateTime;
    }
}

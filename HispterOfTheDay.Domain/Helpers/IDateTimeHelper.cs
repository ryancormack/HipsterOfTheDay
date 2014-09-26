using System;
using HispterOfTheDay.Domain.Services;

namespace HispterOfTheDay.Domain.Helpers
{
    public interface IDateTimeHelper : IService
    {
        DateTime UtcNow { get; }
    }
}

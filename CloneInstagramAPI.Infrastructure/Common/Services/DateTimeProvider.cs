using CloneInstagramAPI.Application.Common.Interfaces.Services;

namespace CloneInstagramAPI.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
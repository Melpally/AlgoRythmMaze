namespace TopiTopi.Domain.Interfaces
{
    public interface ICalendarService
    {
        Task<string> CreateEventAsync(string calendarId, string title, DateTime startTime, DateTime endTime);
    }
}

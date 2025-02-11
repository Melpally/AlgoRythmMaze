using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using TopiTopi.Domain.Interfaces;

namespace TopiTopi.Infrastructure.ExternalServices
{
    public class GoogleCalendarService : ICalendarService
    {
        private readonly CalendarService _calendarService;

        public GoogleCalendarService()
        {
            var credential = GoogleCredential.FromFile("credentials.json")
                .CreateScoped(CalendarService.Scope.Calendar);

            _calendarService = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "TopiTopi Booking System"
            });
        }
        public async Task<string> CreateEventAsync(string calendarId, string title, DateTime startTime, DateTime endTime)
        {
            var newEvent = new Event()
            {
                Summary = title,
                Start = new EventDateTime() { DateTime = startTime },
                End = new EventDateTime() { DateTime = endTime }
            };

            var createdEvent = await _calendarService.Events.Insert(newEvent, calendarId).ExecuteAsync();
            return createdEvent.Id;
        }
    }
}

namespace AlgoRythmMaze.Application.Dtos
{
    public class BookingDto
    {
        public required string ClientEmail { get; set; }
        public required string ClientName { get; set; }
        public required string CaregiverEmail { get; set; }
        public required string CaregiverName { get; set; }
        public required string Service { get; set; }
        public string? Notes { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}

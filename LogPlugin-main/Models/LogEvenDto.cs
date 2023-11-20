namespace LoggerPlugin.Models
{
    public class LogEventDto
    {
        public string? Message { get; set; }
        public string? Level { get; set; }
        public string? UserInformation { get; set; }
        public string? SystemInformation { get; set; }
        public string? ProcessInformation { get; set; }
    }
}

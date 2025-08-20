namespace Communication.Responses.Team
{
    public class TeamResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateOnly CreatedAt { get; set; }
    }
}

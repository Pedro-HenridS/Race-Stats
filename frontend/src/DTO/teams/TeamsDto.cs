namespace src.DTO.teams
{
    public class TeamsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateOnly CreatedAt { get; set; }
    }
}

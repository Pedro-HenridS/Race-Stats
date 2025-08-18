namespace Domain.Entities
{
    public class Team
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public DateOnly CreatedAt { get; set; }
        public string Color { get; set; }
        public ICollection<Pilot> Pilots { get; set; } = new List<Pilot>();
    }
}

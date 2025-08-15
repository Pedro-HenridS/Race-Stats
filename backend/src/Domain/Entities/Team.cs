using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Team
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public DateOnly CreatedAt { get; set; }
        public Guid LeaderId { get; set; } 
        public Colors Color { get; set; }

        [ForeignKey("LeaderId")]
        public Pilot Leader { get; set; }
        public ICollection<Pilot> Pilots { get; set; } = new List<Pilot>();
    }
}

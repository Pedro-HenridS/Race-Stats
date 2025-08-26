using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Pilot
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public TimeSpan Fastestlap { get; set; }
        public decimal Weight { get; set; }
        public Gender Gender { get; set; }
        public string Nationality { get; set; } = string.Empty;
        public string Circuit { get; set; } = string.Empty;
        public Guid TeamId { get; set; }
        public bool Leader { get; set; }

        // Estabelece a relação um para muitos entre Times e Pilotos
        public SingleSeaterCategory Category { get; set; }

        [ForeignKey("TeamId")]
        public Team Team { get; set; }
    }
}

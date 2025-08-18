using src.Common.Enums.Category;
using src.DTO.pilot;

namespace src.DTO.teams
{
    public class Teams
    {
        public string Team { get; set; }
        public SingleSeaterCategory Category { get; set; }
        public string Color { get; set; }
        public List<PilotItems> Pilots { get; set; }
    }
}

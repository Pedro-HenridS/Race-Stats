namespace Domain.Dto.Filter
{
    public class TeamFilterRequest
    {
        public Guid? TeamId { get; set; }
        public String? Search { get; set; }
    }
}

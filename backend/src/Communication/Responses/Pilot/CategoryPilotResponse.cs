namespace Communication.Responses.Pilot
{
    public class CategoryPilotResponse
    {
        public string Category { get; set; }
        public List<PilotResponse> pilots { get; set; }
    }
}

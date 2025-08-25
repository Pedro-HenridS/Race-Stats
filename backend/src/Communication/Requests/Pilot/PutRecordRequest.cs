using Communication.Enums;

namespace Communication.Requests.Pilot
{
    public class PutRecordRequest
    {
        public String Name { get; set; }
        public TimeSpan Fastestlap { get; set; }
        public string Circuit { get; set; } = string.Empty;
        public SingleSeaterCategoryDto Category { get; set; }
    }
}

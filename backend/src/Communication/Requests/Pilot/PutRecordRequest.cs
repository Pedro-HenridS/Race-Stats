using Communication.Enums;

namespace Communication.Requests.Pilot
{
    public class PutRecordRequest
    {
        public TimeSpan Fastestlap { get; set; }
        public string Circuit { get; set; } = string.Empty;
        public SingleSeaterCategory Category { get; set; }
    }
}

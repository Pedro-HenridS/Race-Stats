namespace Exception
{
    public class RaceException : SystemException
    {
        public List<String> Errors;
        public int StatusCode;

        public RaceException(string error, int statusCode)
        {
            Errors = [error];
            StatusCode = statusCode;
        }

        public RaceException(List<String> errors, int statusCode)
        {
            Errors = errors;
            StatusCode = statusCode;
        }
    }
}

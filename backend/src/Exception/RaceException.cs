namespace Exception
{
    public class RaceException : SystemException
    {
        public List<String> Errors;

        public RaceException(string error)
        {
            Errors = [error];
        }

        public RaceException(List<String> errors)
        {
            Errors = errors;
        }
    }
}

namespace Exception
{
    public class RaceException : System.Exception
    {
        // Lista de erros associados à exceção.
        public List<String> Errors;
        // Código de status HTTP para a exceção.
        public int StatusCode;

        // Construtor para uma única mensagem de erro.
        public RaceException(string error, int statusCode)
        {
            Errors = [error];
            StatusCode = statusCode;
        }

        // Construtor para uma lista de mensagens de erro.
        public RaceException(List<String> errors, int statusCode)
        {
            Errors = errors;
            StatusCode = statusCode;
        }
    }
}

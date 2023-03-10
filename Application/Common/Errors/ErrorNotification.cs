namespace Application.Common.Errors
{
    public class ErrorNotification
    {
        public ErrorNotification(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}

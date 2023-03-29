namespace Application.Common.Errors
{
    public class ErrorNotification
    {
        public ErrorNotification(string message, string? type = null)
        {
            Message = message;

            if (type != null)
            {
                Type = type;
            }
        }

        public string Message { get; }
        public string? Type { get; }
    }
}

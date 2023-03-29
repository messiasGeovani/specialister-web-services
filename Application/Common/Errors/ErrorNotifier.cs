using Application.Common.Interfaces;

namespace Application.Common.Errors
{
    public class ErrorNotifier : IErrorNotifier
    {
        private List<ErrorNotification> _notifications;

        public ErrorNotifier()
        {
            _notifications = new List<ErrorNotification>();
        }

        public void AddNotification(ErrorNotification notification)
        {
            _notifications.Add(notification);
        }

        public void AddNotification(string errorMessage)
        {
            var notification = new ErrorNotification(errorMessage);
            _notifications.Add(notification);
        }

        public void AddNotFoundNotification(string errorMessage)
        {
            var notification = new ErrorNotification(errorMessage, ErrorType.NotFound);
            _notifications.Add(notification);
        }

        public void AddUnauthorizedNotification(string errorMessage)
        {
            var notification = new ErrorNotification(errorMessage, ErrorType.Unauthorized);
            _notifications.Add(notification);
        }

        public List<ErrorNotification> GetNotifications()
        {
            return _notifications;
        }

        public bool HasNotFoundNotification()
        {
            return _notifications.Any(n => n.Type == ErrorType.NotFound);
        }

        public bool HasNotification()
        {
            return _notifications.Any();
        }
    }
}

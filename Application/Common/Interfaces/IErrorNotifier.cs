using Application.Common.Errors;

namespace Application.Common.Interfaces
{
    public interface IErrorNotifier
    {
        void AddNotification(ErrorNotification notification);
        void AddNotification(string errorMessage);
        List<ErrorNotification> GetNotifications();
        bool HasNotification();
    }
}

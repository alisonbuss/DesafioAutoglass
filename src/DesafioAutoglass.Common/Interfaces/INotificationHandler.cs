
using FluentValidation.Results;

namespace DesafioAutoglass.Common.Interfaces
{
    public interface INotificationHandler<TNotification> where TNotification : class
    {
        IReadOnlyCollection<TNotification> Notifications();

        void NewNotification(string key, string message);
        void NewNotification(TNotification notification);

        void NewNotifications(IReadOnlyCollection<TNotification > notifications);
        void NewNotifications(IList<TNotification> notifications);
        void NewNotifications(ICollection<TNotification> notifications);
        void NewNotifications(ValidationResult validationResult);

        void NewNotifications(INotificationHandler<TNotification> item);
        void NewNotifications(params INotificationHandler<TNotification>[] items);

        bool HasNotifications();

    }
}

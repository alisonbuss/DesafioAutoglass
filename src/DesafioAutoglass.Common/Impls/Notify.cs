
using FluentValidation.Results;

using DesafioAutoglass.Common.Interfaces;

namespace DesafioAutoglass.Common.Impls
{
    public abstract class Notify : INotificationHandler<Notification>
    {
        private readonly List<Notification> notifications;

        protected Notify()
        {
            this.notifications = new List<Notification>();
        }

        protected virtual IEnumerable<Notification>? Validations() => null;

        private IEnumerable<Notification> GetNotificationsFromValidations()
        {
            return Validations() ?? new List<Notification>();
        }

        public IReadOnlyCollection<Notification> Notifications()
        {
            return new List<Notification>(this.notifications).Concat(GetNotificationsFromValidations()).ToList();
        }

        public void NewNotification(string key, string message)
        {
            this.notifications.Add(new Notification(key, message));
        }

        public void NewNotification(Notification notification)
        {
            this.notifications.Add(notification);
        }

        public void NewNotifications(IReadOnlyCollection<Notification> notifications)
        {
            this.notifications.AddRange(notifications);
        }

        public void NewNotifications(IList<Notification> notifications)
        {
            this.notifications.AddRange(notifications);
        }

        public void NewNotifications(ICollection<Notification> notifications)
        {
            this.notifications.AddRange(notifications);
        }

        public void NewNotifications(INotificationHandler<Notification> item)
        {
            NewNotifications(item.Notifications());
        }

        public void NewNotifications(params INotificationHandler<Notification>[] items)
        {
            foreach (var item in items)
                NewNotifications(item);
        }

        public void NewNotifications(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
                NewNotification(error.ErrorCode, error.ErrorMessage);
        }

        public bool HasNotifications() 
        {
            return this.notifications.Any() || GetNotificationsFromValidations().Any();
        }

    }
}
using System;
using Dolittle.Events;

namespace Events.Notification.Outbound
{
    public class NotificationCreated : IEvent
    {
        public NotificationCreated(string textMessage, Guid notificationId, DateTime timeStamp)
        {
          
            TextMessage = textMessage;
            NotificationId = notificationId;
            TimeStamp = timeStamp;
        }
        public string TextMessage {get; }
        public DateTime TimeStamp {get;}
        public Guid NotificationId {get;}
    }
}
using System;
using Dolittle.Events;

namespace Events.Notification.Outbound
{
    public class NotificationDelivered : IEvent
    {
        public NotificationDelivered(DateTime timeStamp, Guid notificationId)
        {
          
            TimeStamp = timeStamp;
            NotificationId = notificationId;
        }
        public DateTime TimeStamp {get; }
        public Guid NotificationId {get;}
    }
}
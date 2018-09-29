using Dolittle.Events;
using System;

namespace Events.Notifcation.Outbound
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
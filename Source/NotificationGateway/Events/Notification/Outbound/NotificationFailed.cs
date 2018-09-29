using Dolittle.Events;
using System;

namespace Events.Notifcation.Outbound
{
    public class NotificationFailed : IEvent
    {
        public NotificationFailed(DateTime timeStamp, Guid notificationId, string exceptionMessage)
        {
          
            TimeStamp = timeStamp;
            NotificationId = notificationId;
            ExceptionMessage = exceptionMessage;
        }
        public DateTime TimeStamp {get; }
        public Guid NotificationId {get;}
        public string ExceptionMessage {get;}
    }
}
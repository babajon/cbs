using Dolittle.Events;
using System;

namespace Events.Notifcation.Inbound
{
    public class NotificationReceived : IEvent
    {
        public NotificationReceived(Guid notificationId, string endpointType, string address, DateTime timeStamp)
        {
            TimeStamp = timeStamp;
            EndpointType = endpointType;
            Address = address;
            NotificationId = notificationId;
       }

        public DateTime TimeStamp {get; }
        public string EndpointType {get;}
        public string Address{get;}
        public Guid NotificationId{get;}
    }
}
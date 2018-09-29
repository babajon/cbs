using System;
using Concepts;
using Dolittle.Events;

namespace Events.Notification.Inbound
{
    public class NotificationReceived : IEvent
    {
        public NotificationReceived(Guid notificationId, NotifcationEndpointType endpointType, string address, DateTime timeStamp)
        {
            TimeStamp = timeStamp;
            EndpointType = endpointType;
            Address = address;
            NotificationId = notificationId;
       }

        public DateTime TimeStamp {get; }
        public NotifcationEndpointType EndpointType {get;}
        public string Address{get;}
        public Guid NotificationId{get;}
    }
}
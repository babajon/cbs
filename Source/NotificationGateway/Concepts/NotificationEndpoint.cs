using System;
using Dolittle.Concepts;
namespace Concepts
{
    public class NotificationEndpoint : Value<NotificationEndpoint>
    {
        public Guid Id {get;}
        public NotifcationEndpointType EndpointType {get;}
        public string Address {get;}
        public  NotificationEndpoint (Guid id, NotifcationEndpointType type, string address) 
        {
          this.Id = id;
          this.EndpointType = type;
          this.Address = address;
        }
    }
}
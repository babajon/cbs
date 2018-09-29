using Dolittle;
using Dolittle.Runtime.Events;
using NotificationGateway.Concepts;

namespace Domain.Messages
{
    public class SMSSender : Dolittle.Domain.AggregateRoot
    {
        public SMSSender(EventSourceId id, ISmsGateway gateway) : base(id)
        {
            _gateway = gateway;
        }
        ISmsGateway _gateway;

        public void send(SendMessage message){
            _gateway.send(message);
        }
    }

    public interface ISmsGateway
    {
        void send(SendMessage message);
    }
    public class SendMessage
    {
        public TelephoneNumber telephoneNumber { get; set;}
        public Text text { get; set;}
        public MessageId messageId { get; set;}
    }
}
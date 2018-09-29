using Dolittle;
using Dolittle.Runtime.Events;
using Events.Messages;
using NotificationGateway.Concepts;

namespace Domain.Messages
{
    public class SMS : Dolittle.Domain.AggregateRoot
    {
        public SMS(EventSourceId id, ISmsGateway gateway) : base(id)
        {
            _gateway = gateway;
        }
        ISmsGateway _gateway;

        public void Send(string phoneNumber, string areaCode , string textMessage){
            Apply(new SMSSendt(phoneNumber, areaCode, textMessage));
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
using Dolittle.Events;

namespace Events.Messages
{
    public class SMSSendt : IEvent
    {
        public SMSSendt(string phoneNumber, string areaCode, string textMessage)
        {
            PhoneNumber = phoneNumber;
            AreaCode = areaCode;
            TextMessage = textMessage;
        }
        public string PhoneNumber {get; }
        public string AreaCode {get; }
        public string TextMessage {get; }
    }

}
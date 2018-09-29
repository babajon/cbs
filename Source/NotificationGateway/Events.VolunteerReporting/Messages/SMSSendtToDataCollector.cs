using Dolittle.Events;

namespace Events.VolunteerReporting.Messages
{
    [Artifact("398c1d76-f09b-4d0e-b517-6e83afed4a09")]
    public class SMSSendtToDataCollector : IEvent
    {
        public SMSSendtToDataCollector(string number, string textMessage)
        {
            Number = number;
            TextMessage = textMessage;
        }
        public string Number {get;}
        public string TextMessage {get;}
    }

}
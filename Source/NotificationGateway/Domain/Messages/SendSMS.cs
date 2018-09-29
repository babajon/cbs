using System;
using Dolittle.Commands;
using NotificationGateway.Concepts;
namespace Domain.Messages
{
    public class SendSMS : ICommand
    {
            public TelephoneNumber telephoneNumber {get;}
            public Text text {get;}
            public MessageId messageId{get;}
    }
}

using System;
using Dolittle.Concepts;

namespace NotificationGateway.Concepts
{
    public class MessageId : ConceptAs<Guid>
    {
        public static implicit operator MessageId (Guid value) 
        {
            return new MessageId{ Value = value };
        }
    }
}
using System;
using Dolittle.Concepts;

namespace NotificationGateway.Concepts
{
    public class Text : ConceptAs<string>
    {
        public static implicit operator Text (string value) 
        {
            return new Text{ Value = value };
        }
    }
}
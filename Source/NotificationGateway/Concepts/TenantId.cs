using System;
using Dolittle.Concepts;

namespace NotificationGateway.Concepts
{
    public class TenantId : ConceptAs<Guid>
    {
        public static implicit operator TenantId (Guid value) 
        {
            return new TenantId{ Value = value };
        }
    }
}
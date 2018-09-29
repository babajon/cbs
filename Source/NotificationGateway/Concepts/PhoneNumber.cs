using Dolittle.Concepts;
namespace NotificationGateway.Concepts
{
    
    public class PhoneNumber : ConceptAs<string>
    {
        public static implicit operator PhoneNumber(string value)
        {
            return new PhoneNumber { Value = value };
        }
    }
}

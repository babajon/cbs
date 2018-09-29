using Dolittle.Concepts;
namespace NotificationGateway.Concepts
{
    public class CountryCode : ConceptAs<string>
    {
        public static implicit operator CountryCode(string value)
        {
            return new CountryCode { Value = value };
        }
    }
}

using Dolittle.Concepts;

namespace NotificationGateway.Concepts
{
    public class TelephoneNumber : Value<TelephoneNumber>
    {
        public CountryCode countryCode{get; private set;}
        public PhoneNumber phoneNumber{get; private set;}
        public TelephoneNumber(CountryCode countryCode, PhoneNumber phoneNumber){
            this.countryCode = countryCode;
            this.phoneNumber = phoneNumber;
        }
    }
}

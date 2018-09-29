using Dolittle.Commands.Handling;
using Dolittle.Domain;
using System;

namespace Domain.Messages{

    public class SendSmsHandlers: ICanHandleCommands{
        //
        AggregateRootRepositoryFor<SMSSender> _smsSenderRepository;
        public void Handle(SendSMS command){
            var sender = _smsSenderRepository.Get(default(Guid));
            var message = new SendMessage();

            // sender.send(new SendMessage("","",""));
        }
    }
}
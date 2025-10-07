using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Domain.StoreContext.Services;
using BaltaStore.Domain.StoreContext.ValueObjects;
using BaltaStore.Shared.Commands;
using FluentValidator;

namespace BaltaStore.Domain.StoreContext.Handlers
{
    public class CustomerHandler : Notifiable, ICommandHandler<CreateCustomerCommand>, ICommandHandler<AddAddressComand>
    {
        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;
        public CustomerHandler(ICustomerRepository repository, IEmailService emailservice)
        {
            _repository = repository;
            _emailService = emailservice;
        }
        public ICommandResult Handle(CreateCustomerCommand command)
        {
            //verificar se o cpf ja existe na base
            if (_repository.CheckDocument(command.Document))
                AddNotification("Document", "Este CPF já esta em uso");

            //verificar se o email ja existe na base
            if(_repository.CheckEmail(command.Email))
              AddNotification("Document", "Este Email já esta em uso");
              
            //criar os vos
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            //criar a entidade

            var customer = new Customer(name, document, email, command.Phone);

            //validar entidades e vo
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            if (Invalid)
                return null;

            //persisitr o cliente
            _repository.Save(customer);
            //enviar email de boas vindas
            _emailService.Send(email.Address, "Hello About", "Bem vindo", "Seja bem vindo ao Balta Store!");
            //retornar o resultado para a tela
            return new CreateCustomerCommandResult(customer.Id, name.ToString(), email.Address);

        }

        public ICommandResult Handle(AddAddressComand command)
        {
            throw new NotImplementedException();
        }
    }
}

using BaltaStore.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs
{
    public class CreateCustomerCommand :Notifiable, ICommand
    {
        //FailFastValidation
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email{ get; set; }
        public string Phone { get; set; }
        public bool Valid()
        {
            AddNotifications(new ValidationContract().Requires()
                                                     .HasMinLen(FirstName, 3, "FirstName", "O nome dec conter pelo menos 3 caracteres")
                                                     .HasMaxLen(FirstName, 40, "FirstName", "O nome deve  no maximo 40 caracteres")
                                                     .HasMinLen(LastName, 3, "LastName", "O sobrenome deve conter no minimo 3 caracteres")
                                                     .HasMaxLen(LastName, 40, "LastName", "O sobrenome deve conter no maximo 40 caractres")
                                                     .IsEmail(Email, "Email", "O email é inválido")
                                                     .HasLen(Document, 11, "Document", "CPF inválido")
            );
            return IsValid;

        }
    }
}
using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Shared.Commands;
using FluentValidator;

namespace BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs
{
    public class AddAddressComand : Notifiable, ICommand
    {
        public Guid id { get; set; }
        public string StoreContext { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public EAddressType Type { get; set; }
        bool ICommand.Valid()
        {
            return IsValid;
        }
    }
}
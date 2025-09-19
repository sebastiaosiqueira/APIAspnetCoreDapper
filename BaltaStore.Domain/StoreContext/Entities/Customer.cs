using System.Dynamic;
using BaltaStore.Domain.StoreContext.ValueObjects;
using System.Linq;
using FluentValidator;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Customer: Notifiable
    {
        private readonly IList<Address> _addresses;

        public Customer(Name name, Document document, Email email, string phone)
        {
            Name = name;
            Document = document;
            Document = document;
            Email = email;
            Phone = phone;
            _addresses = new List<Address>();
        }

         public Name Name{ get; private set; }
           public Document Document { get; private set; }
       public Email Email { get; private set; }
        public string Phone { get; private set; }
        public IReadOnlyCollection<Address> Address => _addresses.ToArray();
        public void AddAdress(Address address)
        {
            //validar o endereço
            //adiconar o endereço
            _addresses.Add(address);
       }
        public override string ToString()
        {
            return Name.ToString();
        }

    }
}
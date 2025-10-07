
using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new ValidationContract().Requires()
                                                            .HasMinLen(firstName, 3, "FirstName", "Nome deve conter pelo menos tres caracter")
                                                            .HasMaxLen(FirstName,100, "FirstName","O nome não pode ser maior que 100 carcteres")
            );
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
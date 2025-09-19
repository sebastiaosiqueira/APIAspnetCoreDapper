using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaltaStore.Domain.StoreContext.ValueObjects
{
    public class Email
    {
        public Email(string address)
        {
            Address = address;
        }
        public string Address { get; private set; }

        public override string ToString()
        {
            return Address;
        }
        
    }
}
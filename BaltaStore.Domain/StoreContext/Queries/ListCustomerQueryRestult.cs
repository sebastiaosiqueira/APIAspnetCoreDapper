using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaltaStore.Domain.StoreContext.Queries
{
    public class ListCustomerQueryRestult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
    }
}
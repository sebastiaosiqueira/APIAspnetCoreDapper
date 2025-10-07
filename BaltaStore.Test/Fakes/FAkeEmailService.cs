using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaltaStore.Domain.StoreContext.Services;

namespace BaltaStore.Test.Fakes
{
    public class FAkeEmailService : IEmailService
    {
        public void Send(string to, string from, string subject, string body)
        {
           
        }
    }
}
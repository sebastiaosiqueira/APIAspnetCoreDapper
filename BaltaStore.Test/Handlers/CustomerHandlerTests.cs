using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Handlers;
using BaltaStore.Test.Fakes;

namespace BaltaStore.Test.Handlers
{
    public class CustomerHandlerTests
    {
        [TestMethod]
        public void ShoudlRegisterCustomerWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();

            command.FirstName = "Andre";
            command.LastName = "balteirer";
            command.Document = "2868789999";
            command.Email = "Andre@balt3eire.com";
            command.Phone = "96548998978";

            Assert.AreEqual(true, command.Valid());

            var handler = new CustomerHandler(new FakeCustomerRepository(), new FAkeEmailService());
            var result = handler.Handle(command);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, handler.IsValid);


        }
        
    }
}
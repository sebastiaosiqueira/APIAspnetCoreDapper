using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Test.Commands
{
    [TestClass]
    public class CreateCustomerCommandTests
    {
        [TestMethod]
        public void ShouldVAlidateWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Andre";
            command.LastName = "jose";
            command.Document = "18985654646";
            command.Email = "sebastiao@gmail.com";
            command.Phone = "65489787989";
            Assert.AreEqual(true, command.Valid());
        }
    }
}
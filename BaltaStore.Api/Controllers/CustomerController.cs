

using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Handlers;
using BaltaStore.Domain.StoreContext.Queries;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Domain.StoreContext.ValueObjects;
using BaltaStore.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace BaltaStore.Api.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;
        private readonly CustomerHandler _handler;
        public CustomerController(ICustomerRepository repository, CustomerHandler handler)
        {
            _repository = repository;
            _handler = handler;
           
        }
        [HttpGet]
        [Route("v1/Customers")]
        [ResponseCache(Duration =60)]
        public IEnumerable<ListCustomerQueryRestult> Get()
        {


            return _repository.Get(); ;
        }

        [HttpGet]
        [Route("v1/Customers/{id}")]
        public GetCustomerQueryResult GetById(Guid id)
        {
            return _repository.Get(id);
           
        }

        [HttpGet]
        [Route("v1/Customers/{id}/orders")]
        public IEnumerable<ListCustomerOrdersQueryResult> GEtOrders(Guid id)
        {

            return _repository.GeOrders(id);
         
        }

        [HttpPost]
        [Route("v1/Customers")]
        public ICommandResult Post([FromBody] CreateCustomerCommand command)
        {
            var result = (CreateCustomerCommandResult)_handler.Handle(command);
            return result;
        }

        [HttpPut]
        [Route("v1/Customers/{id}")]
        public Customer Put([FromBody] CreateCustomerCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var customer = new  Customer(name, document, email, command.Phone);
            return customer;
           
        }
        
            [HttpDelete]
        [Route("v1/Customers/{id}")]
        public object Delete()
        {
            return new { message = "Cliente removido com sucesso!" };
        }
        
        
    }
}

using System.Data;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Queries;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Infra.DataContexts;
using Dapper;

namespace BaltaStore.Infra.StoreContext.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BaltaDataContext _context;

        public CustomerRepository(BaltaDataContext context)
        {
            _context = context;
        }
        public bool CheckDocument(string document)
        {
            return _context.Connection.Query<bool>("spCheckDocument", new { Document = document }, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public bool CheckEmail(string email)
        {
            return _context.Connection.Query<bool>("spCheckEmail", new { Email = email }, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public IEnumerable<ListCustomerOrdersQueryResult> GeOrders(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ListCustomerQueryRestult> Get()
        {
            return _context.Connection.Query<ListCustomerQueryRestult>(
             "select [id] , concat([FirstName], '' , [LastName]) as [Name], [Document], [Email] from [Customer]",new{}
            );
        }

        public GetCustomerQueryResult Get(Guid id)
        {
           return _context.Connection.Query<GetCustomerQueryResult>(
             "select [id] , concat([FirstName], '' , [LastName]) as [Name], [Document], [Email] from [Customer] where [id]=@id",new{id= id}
            ).FirstOrDefault();
        }

        public CustomerOrdersCountResult GetCustomerOrdersCount(string document)
        {
            return _context.Connection.Query<CustomerOrdersCountResult>(
             "spGetCustomerOrdersCount",
             new { Document = document },
             commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public void Save(Customer customer)
        {
         
            _context.Connection.Execute("spCreateCustomer",
            new
            {
                Id = customer.Id,
                FirstName = customer.Name.FirstName,
                LastName = customer.Name.LastName,
                Document = customer.Document.Number,
                Email = customer.Email.Address,
                Phone = customer.Phone
            }, commandType: CommandType.StoredProcedure);
            foreach (var address in customer.Address)
            {
                _context.Connection.Execute("spCreateAdress",
                new
                {
                    Id = address.Id,
                    Customer = customer.Id,
                    number = address.Number,
                    Complement = address.Complement,
                    District = address.District,
                    City = address.City,
                    State = address.State,
                    Country = address.Country,
                    ZipCode = address.ZipCode,
                    Type = address.Type,

                }, commandType: CommandType.StoredProcedure);
           }
        }
    }
}
using AutoFixture;
using CqrsAndMediatR.Domain.Entities;
using CqrsAndMediatR.Infrastructure.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CqrsAndMediatR.Infrastructure.Repositories
{
    internal class CustomersRepository : ICustomersRepository
    {
        private readonly IFixture _fixture;
        private readonly IEnumerable<Customer> _customers;

        public CustomersRepository()
        {
            _fixture = new Fixture();
            _customers = _fixture.CreateMany<Customer>();
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await Task.FromResult(_customers);
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await Task.FromResult(
                _customers.FirstOrDefault(c => c.Id == id)
            );
        }

        public Task<Customer> CreateCustomer(Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateCustomer(Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteCustomer(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}

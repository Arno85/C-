using CqrsAndMediatR.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CqrsAndMediatR.Infrastructure.Abstractions
{
    public interface ICustomersRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerById(int id);
        Task<Customer> CreateCustomer(Customer customer);
        Task UpdateCustomer(Customer customer);
        Task DeleteCustomer(int id);
    }
}

using CqrsAndMediatR.Domain.Entities;
using MediatR;

namespace CqrsAndMediatR.Application.Customers.Commands
{
    public class CreateCustomerCommand : IRequest<Customer>
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}

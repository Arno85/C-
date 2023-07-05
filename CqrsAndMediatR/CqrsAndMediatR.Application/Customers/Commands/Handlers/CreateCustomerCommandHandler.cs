using CqrsAndMediatR.Domain.Entities;
using CqrsAndMediatR.Infrastructure.Abstractions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CqrsAndMediatR.Application.Customers.Commands.Handlers
{
    internal class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Customer>
    {
        private readonly ICustomersRepository _customersRepository;

        public CreateCustomerCommandHandler(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            return await _customersRepository.CreateCustomer(new Customer
            {
                Name = request.Name,
                Address = request.Address,
                EmailAddress = request.EmailAddress,
                PhoneNumber = request.PhoneNumber
            });
        }
    }
}

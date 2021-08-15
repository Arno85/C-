using CqrsAndMediatR.Domain.Entities;
using CqrsAndMediatR.Infrastructure.Abstractions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CqrsAndMediatR.Application.Customers.Queries.Handlers
{
    internal class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
    {
        private readonly ICustomersRepository _customersRepository;

        public GetCustomerByIdQueryHandler(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            return await _customersRepository.GetCustomerById(request.Id);
        }
    }
}

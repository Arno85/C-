using CqrsAndMediatR.Domain.Entities;
using CqrsAndMediatR.Infrastructure.Abstractions;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CqrsAndMediatR.Application.Customers.Queries.Handlers
{
    internal class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<Customer>>
    {
        private readonly ICustomersRepository _customersRepository;

        public GetAllCustomersQueryHandler(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public async Task<IEnumerable<Customer>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            return await _customersRepository.GetAllCustomers();
        }
    }
}

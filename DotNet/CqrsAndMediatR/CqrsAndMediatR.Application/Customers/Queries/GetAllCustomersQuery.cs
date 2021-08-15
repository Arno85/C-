using CqrsAndMediatR.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace CqrsAndMediatR.Application.Customers.Queries
{
    public class GetAllCustomersQuery : IRequest<IEnumerable<Customer>>
    {
    }
}

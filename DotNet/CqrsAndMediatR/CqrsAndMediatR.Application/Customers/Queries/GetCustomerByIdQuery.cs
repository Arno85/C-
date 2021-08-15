using CqrsAndMediatR.Domain.Entities;
using MediatR;

namespace CqrsAndMediatR.Application.Customers.Queries
{
    public class GetCustomerByIdQuery : IRequest<Customer>
    {
        public int Id { get; set; }

        public GetCustomerByIdQuery(int id)
        {
            Id = id;
        }
    }
}

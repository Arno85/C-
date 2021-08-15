using AutoMapper;
using CqrsAndMediatR.Application.Customers.Commands;

namespace CqrsAndMediatR.Api.Models.Requests
{
    public class CreateCustomerRequestMapper : Profile
    {
        public CreateCustomerRequestMapper()
        {
            CreateMap<CreateCustomerRequest, CreateCustomerCommand>();
        }
    }
}

using AutoMapper;
using CqrsAndMediatR.Domain.Entities;

namespace CqrsAndMediatR.Api.Models.Responses
{
    public class CustomerResponseMapper : Profile
    {
        public CustomerResponseMapper()
        {
            CreateMap<Customer, CustomerResponse>();
        }
    }
}

using AutoMapper;
using CqrsAndMediatR.Api.Models.Requests;
using CqrsAndMediatR.Api.Models.Responses;
using CqrsAndMediatR.Application.Customers.Commands;
using CqrsAndMediatR.Application.Customers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CqrsAndMediatR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CustomersController(
            IMediator mediator,
            IMapper mapper
        )
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _mediator.Send(new GetAllCustomersQuery());

            return Ok(_mapper.Map<IEnumerable<CustomerResponse>>(customers));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var customer = await _mediator.Send(new GetCustomerByIdQuery(id));

            return customer != null
                ? Ok(_mapper.Map<CustomerResponse>(customer))
                : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerRequest request)
        {
            var customer = await _mediator.Send(_mapper.Map<CreateCustomerCommand>(request));

            return Created(string.Empty, customer.Id);
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

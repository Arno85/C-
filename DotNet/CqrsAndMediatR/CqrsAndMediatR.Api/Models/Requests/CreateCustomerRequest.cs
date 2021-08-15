namespace CqrsAndMediatR.Api.Models.Requests
{
    public class CreateCustomerRequest
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}

namespace CustomerService.Features.Customers
{
    public class RegisterCustomerApiModel
    {        
        public int Id { get; set; }

        public int? TenantId { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Province { get; set; }

        public string PostalCode { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Mobile { get; set; }
    }
}

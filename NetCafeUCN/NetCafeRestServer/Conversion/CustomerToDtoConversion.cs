using NetCafeUCN.API.DTO;
using NetCafeUCN.DAL.Model;

namespace NetCafeUCN.API.Conversion
{
    public static class CustomerToDtoConversion
    {
        public static IEnumerable<CustomerDTO> CustomerToDtos(this IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                yield return customer.CustomerToDto();
            }
        }
        public static CustomerDTO CustomerToDto(this Customer Customer)
        {
            return Customer.CopyPropertiesTo(new CustomerDTO());
        }
        public static IEnumerable<Customer> CustomerFromDtos(this IEnumerable<CustomerDTO> customerDtos)
        {
            foreach (var customer in customerDtos)
            {
                yield return customer.CustomerFromDto();
            }
        }

        public static Customer CustomerFromDto(this CustomerDTO customerDto)
        {
            return customerDto.CopyPropertiesTo(new Customer());
        }
    }
}

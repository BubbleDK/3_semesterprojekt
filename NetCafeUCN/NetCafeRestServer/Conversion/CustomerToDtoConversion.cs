using NetCafeUCN.API.DTO;
using NetCafeUCN.DAL.Model;

namespace NetCafeUCN.API.Conversion
{
    /// <summary>
    ///  CustomerToDtoConversion klassen er statisk og bruges til at konvertere Customers
    /// </summary>
    public static class CustomerToDtoConversion
    {
        /// <summary>
        /// Statisk metode som konvertere en collection af Customer til en collection af CustomerDTO
        /// </summary>
        /// <param name="customers">Collection af Customer</param>
        /// <returns>Returnere den konverteret collection CustomerDTO</returns>
        public static IEnumerable<CustomerDTO> CustomerToDtos(this IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                yield return customer.CustomerToDto();
            }
        }
        /// <summary>
        /// Statisk metode som konvertere en Customer til CustomerDTO
        /// </summary>
        /// <param name="Customer">En Customer</param>
        /// <returns>Returnere den konverteret CustomerDTO</returns>
        public static CustomerDTO CustomerToDto(this Customer Customer)
        {
            return Customer.CopyPropertiesTo(new CustomerDTO());
        }
        /// <summary>
        /// Statisk metode som konvertere en collection af CustomerDTO til Customer
        /// </summary>
        /// <param name="customerDtos">Collection af CustomerDTO</param>
        public static IEnumerable<Customer> CustomerFromDtos(this IEnumerable<CustomerDTO> customerDtos)
        {
            foreach (var customer in customerDtos)
            {
                yield return customer.CustomerFromDto();
            }
        }
        /// <summary>
        /// Statisk metode som konvertere en CustomerDTO til Customer
        /// </summary>
        /// <param name="customerDto">En CustomerDTO</param>
        /// <returns>Returnere den konverteret Customer</returns>
        public static Customer CustomerFromDto(this CustomerDTO customerDto)
        {
            return customerDto.CopyPropertiesTo(new Customer());
        }
    }
}

namespace NetCafeUCN.MVC.Models.DTO
{
    /// <summary>
    /// CustomerEmployeeViewModel model klasse
    /// </summary>
    public class CustomerEmployeeViewModel
    {
        public IEnumerable<EmployeeDto> employees { get; set;} = Enumerable.Empty<EmployeeDto>();
        public IEnumerable<CustomerDto> customers { get; set;} = Enumerable.Empty<CustomerDto>();
    }
}

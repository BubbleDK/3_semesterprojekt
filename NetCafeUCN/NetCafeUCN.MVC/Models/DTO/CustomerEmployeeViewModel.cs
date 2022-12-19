namespace NetCafeUCN.MVC.Models.DTO
{
    /// <summary>
    /// CustomerEmployeeViewModel model klasse
    /// </summary>
    public class CustomerEmployeeViewModel
    {
        public IEnumerable<EmployeeDto> employees { get; set;}
        public IEnumerable<CustomerDto> customers { get; set;}
    }
}

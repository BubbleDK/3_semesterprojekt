namespace NetCafeUCN.MVC.Models.DTO
{
    /// <summary>
    /// CustomerEmployeeViewModel model klasse
    /// </summary>
    public class CustomerEmployeeViewModel
    {
        public IEnumerable<EmployeeDTO> employees { get; set;} = Enumerable.Empty<EmployeeDTO>();
        public IEnumerable<CustomerDTO> customers { get; set;} = Enumerable.Empty<CustomerDTO>();
    }
}

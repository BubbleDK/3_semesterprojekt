namespace NetCafeUCN.MVC.Models.DTO
{
    public class CustomerEmployeeViewModel
    {
        public IEnumerable<EmployeeDto> employees { get; set;}
        public IEnumerable<CustomerDto> customers { get; set;}
    }
}

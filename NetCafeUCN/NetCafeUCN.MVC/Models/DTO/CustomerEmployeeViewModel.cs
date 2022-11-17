namespace NetCafeUCN.MVC.Models.DTO
{
    public class CustomerEmployeeViewModel
    {
        public IEnumerable<Employee> employees { get; set;}
        public IEnumerable<Customer> customers { get; set;}
    }
}

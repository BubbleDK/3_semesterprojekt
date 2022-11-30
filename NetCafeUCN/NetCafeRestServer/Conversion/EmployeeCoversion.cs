using NetCafeUCN.API.DTO;
using NetCafeUCN.DAL.Model;

namespace NetCafeUCN.API.Conversion
{
    public static class EmployeeCoversion
    {
        public static IEnumerable<EmployeeDTO> EmployeeToDtos(this IEnumerable<Employee> employees)
        {
            foreach (var employee in employees)
            {
                yield return employee.EmployeeToDto();
            }
        }
        public static EmployeeDTO EmployeeToDto(this Employee employee)
        {
            return employee.CopyPropertiesTo(new EmployeeDTO());
        }
        public static IEnumerable<Employee> EmployeeFromDtos(this IEnumerable<EmployeeDTO> employeeDTOs)
        {
            foreach (var employee in employeeDTOs)
            {
                yield return employee.EmployeeFromDto();
            }
        }

        public static Employee EmployeeFromDto(this EmployeeDTO employeeDTO)
        {
            return employeeDTO.CopyPropertiesTo(new Employee());
        }
    }
}

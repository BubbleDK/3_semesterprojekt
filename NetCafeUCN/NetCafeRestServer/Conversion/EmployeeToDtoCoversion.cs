using NetCafeUCN.API.DTO;
using NetCafeUCN.DAL.Model;

namespace NetCafeUCN.API.Conversion
{
    /// <summary>
    ///  EmployeeToDtoCoversion klassen er statisk og bruges til at konvertere Employees
    /// </summary>
    public static class EmployeeToDtoCoversion
    {
        /// <summary>
        /// Statisk metode som konvertere en collection af Employee til en collection af EmployeeDTO
        /// </summary>
        /// <param name="employees">Collection af Employee</param>
        /// <returns>Returnere den konverteret collection EmployeeDTO</returns>
        public static IEnumerable<EmployeeDTO> EmployeeToDtos(this IEnumerable<Employee> employees)
        {
            foreach (var employee in employees)
            {
                yield return employee.EmployeeToDto();
            }
        }
        /// <summary>
        /// Statisk metode som konvertere en Employee til EmployeeDTO
        /// </summary>
        /// <param name="employee">En Employee</param>
        /// <returns>Returnere den konverteret EmployeeDTO</returns>
        public static EmployeeDTO EmployeeToDto(this Employee employee)
        {
            return employee.CopyPropertiesTo(new EmployeeDTO());
        }
        /// <summary>
        /// Statisk metode som konvertere en collection af EmployeeDTO til en collection af Employee
        /// </summary>
        /// <param name="employeeDTOs">Collection af EmployeeDTO</param>
        /// <returns>Returnere den konverteret collection Employee</returns>
        public static IEnumerable<Employee> EmployeeFromDtos(this IEnumerable<EmployeeDTO> employeeDTOs)
        {
            foreach (var employee in employeeDTOs)
            {
                yield return employee.EmployeeFromDto();
            }
        }
        /// <summary>
        /// Statisk metode som konvertere en EmployeeDTO til Employee
        /// </summary>
        /// <param name="employeeDTO">En EmployeeDTO</param>
        /// <returns>Returnere den konverteret Employee</returns>
        public static Employee EmployeeFromDto(this EmployeeDTO employeeDTO)
        {
            return employeeDTO.CopyPropertiesTo(new Employee());
        }
    }
}

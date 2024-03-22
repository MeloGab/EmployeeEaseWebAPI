using EmployeeEaseWebAPI.Models;
using EmployeesEaseWebAPI.Models;

namespace EmployeeEaseWebAPI.Services.EmployeesService
{
    public interface IEmployeeInterface
    {
        Task<ServiceResponse<List<EmployeesModel>>> GetEmployees();
        Task<ServiceResponse<List<EmployeesModel>>> CreateEmployees(EmployeesModel newEmplyee);
        Task<ServiceResponse<EmployeesModel>> GetEmployeeById(int id);
        Task<ServiceResponse<List<EmployeesModel>>> UpdateEmployees(EmployeesModel updateEmployee);
        Task<ServiceResponse<List<EmployeesModel>>> DeleteEmployee(int id);
        Task<ServiceResponse<List<EmployeesModel>>> InactiveEmployee(int id);
    }
}

using EmployeeEaseWebAPI.DataContext;
using EmployeeEaseWebAPI.Models;
using EmployeesEaseWebAPI.Models;

namespace EmployeeEaseWebAPI.Services.EmployeesService
{
    public class EmployeesService : IEmployeeInterface
    {
        private readonly ApplicationDbContext _context;
        public EmployeesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<ServiceResponse<List<EmployeesModel>>> CreateEmployees(EmployeesModel newEmplyee)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<EmployeesModel>>> DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<EmployeesModel>> GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<EmployeesModel>>> GetEmployees()
        {
             ServiceResponse<List<EmployeesModel>> serviceResponse = new ServiceResponse<List<EmployeesModel>>();

            try
            {
                serviceResponse.Status = _context.Employees.ToList();
                
                if(serviceResponse.Status.Count == 0)
                {
                    serviceResponse.Message = "Nenhum dado encontrado.";
                }

            }catch(Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public Task<ServiceResponse<List<EmployeesModel>>> InactiveEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<EmployeesModel>>> UpdateEmployees(EmployeesModel updateEmployee)
        {
            throw new NotImplementedException();
        }
    }
}

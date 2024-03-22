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

        public async Task<ServiceResponse<List<EmployeesModel>>> CreateEmployees(EmployeesModel newEmployee)
        {
            ServiceResponse<List<EmployeesModel>> serviceResponse = new ServiceResponse<List<EmployeesModel>>();

            try
            {
                if (newEmployee == null)
                {
                    serviceResponse.Status = null;
                    serviceResponse.Message = "Informar dados";
                    serviceResponse.Success = false;

                    return serviceResponse;
                }
                _context.Add(newEmployee);
                await _context.SaveChangesAsync();
                serviceResponse.Status = _context.Employees.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
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

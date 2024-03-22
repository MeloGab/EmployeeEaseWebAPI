using EmployeeEaseWebAPI.DataContext;
using EmployeeEaseWebAPI.Models;
using EmployeesEaseWebAPI.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<ServiceResponse<List<EmployeesModel>>> DeleteEmployee(int id)
        {
            ServiceResponse<List<EmployeesModel>> serviceResponse = new ServiceResponse<List<EmployeesModel>>();

            try
            {
                EmployeesModel employee = _context.Employees.FirstOrDefault(x => x.id == id);

                if (employee == null)
                {
                    serviceResponse.Status = null;
                    serviceResponse.Message = "Usuario não encontrado";
                    serviceResponse.Success = false;
                }

                _context.Employees.Remove(employee);
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

        public async Task<ServiceResponse<EmployeesModel>> GetEmployeeById(int id)
        {
            ServiceResponse<EmployeesModel> serviceResponse = new ServiceResponse<EmployeesModel>();

            try
            {
                EmployeesModel employee = _context.Employees.FirstOrDefault(x => x.id == id);

                if(employee == null)
                {
                    serviceResponse.Status = null;
                    serviceResponse.Message = "Usuario não encontrado";
                    serviceResponse.Success = false;
                }

                serviceResponse.Status = employee;

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;

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

        public async Task<ServiceResponse<List<EmployeesModel>>> InactiveEmployee(int id)
        {
            ServiceResponse<List<EmployeesModel>> serviceResponse = new ServiceResponse<List<EmployeesModel>>();

            try
            {
                EmployeesModel employee = _context.Employees.FirstOrDefault(x => x.id == id);

                if (employee == null)
                {
                    serviceResponse.Status = null;
                    serviceResponse.Message = "Usuario não encontrado";
                    serviceResponse.Success = false;
                }

                employee.Actived = false;
                employee.UpdateDate = DateTime.Now.ToLocalTime();

                _context.Employees.Update(employee);
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

        public async Task<ServiceResponse<List<EmployeesModel>>> UpdateEmployees(EmployeesModel updateEmployee)
        {
            ServiceResponse<List<EmployeesModel>> serviceResponse = new ServiceResponse<List<EmployeesModel>>();

            try
            {
                EmployeesModel employee = _context.Employees.AsNoTracking().FirstOrDefault(x => x.id == updateEmployee.id);

                if (employee == null)
                {
                    serviceResponse.Status = null;
                    serviceResponse.Message = "Usuario não encontrado";
                    serviceResponse.Success = false;
                }

                employee.UpdateDate = DateTime.Now.ToLocalTime();

                _context.Employees.Update(updateEmployee);
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
    }
}

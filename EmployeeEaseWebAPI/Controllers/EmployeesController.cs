using EmployeeEaseWebAPI.Models;
using EmployeeEaseWebAPI.Services.EmployeesService;
using EmployeesEaseWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeEaseWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeInterface _employeeInterface;
        public EmployeesController(IEmployeeInterface employeeInterface)
        {
            _employeeInterface = employeeInterface;
        }


        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<EmployeesModel>>>> GetEmployees()
        {
            return Ok(await _employeeInterface.GetEmployees());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<EmployeesModel>>> GetEmployeeById(int id)
        {

            ServiceResponse<EmployeesModel> serviceResponse = await _employeeInterface.GetEmployeeById(id);

            return Ok(serviceResponse);

        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<EmployeesModel>>>> CreateEmployees(EmployeesModel newEmployee)
        {
            return Ok(await _employeeInterface.CreateEmployees(newEmployee));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<EmployeesModel>>>> UpdateEmployees(EmployeesModel updateEmployee)
        {
            ServiceResponse<List<EmployeesModel>> serviceResponse = await _employeeInterface.UpdateEmployees(updateEmployee);

            return Ok(serviceResponse);
        }



        [HttpPut("InativaFuncionario")]
        public async Task<ActionResult<ServiceResponse<List<EmployeesModel>>>> InactiveEmployee(int id)
        {
            ServiceResponse<List<EmployeesModel>> serviceResponse = await _employeeInterface.InactiveEmployee(id);

            return Ok(serviceResponse);
        }

    }
}

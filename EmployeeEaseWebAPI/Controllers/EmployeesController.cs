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

        #region Fields

        private readonly IEmployeeInterface _employeeInterface;

        #endregion


        #region Contructor

        public EmployeesController(IEmployeeInterface employeeInterface)
        {
            _employeeInterface = employeeInterface;
        }

        #endregion


        #region EndPoints

        [HttpGet("BuscaFuncionarios")]
        public async Task<ActionResult<ServiceResponse<List<EmployeesModel>>>> GetEmployees()
        {
            return Ok(await _employeeInterface.GetEmployees());
        }

        [HttpGet("BuscaFuncionario{id}")]
        public async Task<ActionResult<ServiceResponse<EmployeesModel>>> GetEmployeeById(int id)
        {

            ServiceResponse<EmployeesModel> serviceResponse = await _employeeInterface.GetEmployeeById(id);

            return Ok(serviceResponse);

        }

        [HttpPost("CriaFuncionario")]
        public async Task<ActionResult<ServiceResponse<List<EmployeesModel>>>> CreateEmployees(EmployeesModel newEmployee)
        {
            return Ok(await _employeeInterface.CreateEmployees(newEmployee));
        }

        [HttpPut("AlteraFuncionario")]
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

        [HttpDelete("DeletaFuncionario")]
        public async Task<ActionResult<ServiceResponse<List<EmployeesModel>>>> DeleteEmployee(int id)
        {
            ServiceResponse<List<EmployeesModel>> serviceResponse = await _employeeInterface.DeleteEmployee(id);

            return Ok(serviceResponse);
        }

        #endregion

    }
}

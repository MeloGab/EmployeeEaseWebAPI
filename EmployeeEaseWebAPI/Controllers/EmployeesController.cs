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

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<EmployeesModel>>>> CreateEmployees(EmployeesModel newEmployee)
        {
            return Ok(await _employeeInterface.CreateEmployees(newEmployee));
        }

    }
}

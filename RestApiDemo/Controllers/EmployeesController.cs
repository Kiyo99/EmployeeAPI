using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiDemo.EmployeeData;
using RestApiDemo.Models;
using System;

namespace RestApiDemo.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeData _employeeData;

        public EmployeesController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }

        [HttpGet("")]
        [Route("api/[controller]")]
        public IActionResult GetEmployees()
        {
            return Ok(_employeeData.getEmployees());
        }

        [HttpGet("")]
        [Route("api/[controller]/{id}")]
        public IActionResult GetEmployee(Guid id)
        {

            var employee = _employeeData.getEmployee(id);

            if (employee != null) 

            {
                return Ok(employee);
            }

            return NotFound($"Employee with ID: {id} was not found");

        }

        [HttpPost("")]
        [Route("api/[controller]/add")]
        public IActionResult AddEmployee(Employee employee)
        {

             _employeeData.AddEmployee(employee);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host +
                HttpContext.Request.Path + "/" + employee.Id, employee);

        }

        [HttpDelete("")]
        [Route("api/[controller]/delete/{id}")]
        public IActionResult DeleteEmployee(Guid id)
        {

            var employee = _employeeData.getEmployee(id);
           

            if (employee != null)

            {
                _employeeData.DeleteEmployee(employee);
                return Ok($"Employee with ID: {id} was deleted");
            }

            return NotFound($"Employee with ID: {id} was not found");

        }

        [HttpPatch("")]
        [Route("api/[controller]/edit/{id}")]
        public IActionResult EditEmployee(Guid id, Employee employee)
        {
            var ExistingEmployee = _employeeData.getEmployee(id);

            if (ExistingEmployee != null)
            {

                employee.Id = ExistingEmployee.Id;
                _employeeData.EditEmployee(employee);
                return Ok(employee);
            }

            return NotFound($"Employee with ID: {id} was not found");

        }

    }
}

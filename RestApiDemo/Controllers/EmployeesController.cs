using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiDemo.EmployeeRepo;
using RestApiDemo.Models;

namespace RestApiDemo.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeRepo _employeeRepo;

        public EmployeesController(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        [HttpGet("")]
        [Route("api/[controller]")]
        public IActionResult GetEmployees()
        {
            return Ok(_employeeRepo.getEmployees());
        }

        [HttpGet("")]
        [Route("api/[controller]/{id}")]
        public IActionResult GetEmployee(Guid id)
        {

            var employee = _employeeRepo.getEmployee(id);

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

             _employeeRepo.AddEmployee(employee);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host +
                HttpContext.Request.Path + "/" + employee.Id, employee);

        }

        [HttpDelete("")]
        [Route("api/[controller]/delete/{id}")]
        public IActionResult DeleteEmployee(Guid id)
        {

            var employee = _employeeRepo.getEmployee(id);
           

            if (employee != null)

            {
                _employeeRepo.DeleteEmployee(employee);
                return Ok($"Employee with ID: {id} was deleted");
            }

            return NotFound($"Employee with ID: {id} was not found");

        }

        [HttpPatch("")]
        [Route("api/[controller]/edit/{id}")]
        public IActionResult EditEmployee(Guid id, Employee employee)
        {
            var ExistingEmployee = _employeeRepo.getEmployee(id);

            if (ExistingEmployee != null)
            {

                employee.Id = ExistingEmployee.Id;
                _employeeRepo.EditEmployee(employee);
                return Ok(employee);
            }

            return NotFound($"Employee with ID: {id} was not found");

        }

        [HttpPost("")]
        [Route("api/[controller]/requestLeave/{id}")]
        public IActionResult requestLeave(Guid id)
        {
            var existingEmployee = _employeeRepo.getEmployee(id);

            if (existingEmployee != null)
            {
                var updatedEmployee = _employeeRepo.requestLeave(id);
                return Ok($"Your status has been approved, {updatedEmployee.Name}. Your new status is: {updatedEmployee.leaveStatus}");
            }

            return NotFound($"Employee with ID: {id} was not found");
            
        }

    }
}

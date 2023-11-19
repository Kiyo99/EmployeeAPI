using System;
using System.Collections.Generic;
using RestApiDemo.Models;

namespace RestApiDemo.EmployeeRepo
{
    public interface IEmployeeRepo
    {

        List<Employee> getEmployees();

        Employee getEmployee(Guid id);

        Employee AddEmployee(Employee employee); 

        void DeleteEmployee(Employee employee);

        Employee EditEmployee(Employee employee);

        Employee requestLeave(Guid id);
    }
}

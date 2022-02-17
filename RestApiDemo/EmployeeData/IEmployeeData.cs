using RestApiDemo.Models;
using System;
using System.Collections.Generic;

namespace RestApiDemo.EmployeeData
{
    public interface IEmployeeData
    {

        List<Employee> getEmployees();

        Employee getEmployee(Guid id);

        Employee AddEmployee(Employee employee); 

        void DeleteEmployee(Employee employee);

        Employee EditEmployee(Employee employee);       
    }
}

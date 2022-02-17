using RestApiDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestApiDemo.EmployeeData
{
    public class MockEmployeeData : IEmployeeData

    {

        private List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
                Id = Guid.NewGuid(),
                Name = "Mr Arthur"
            },
           new Employee()
           {
                Id = Guid.NewGuid(),
                Name = "Mr Kio"
           },
        };

        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            employees.Add(employee);
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            employees.Remove(employee);
        }

        public Employee EditEmployee(Employee employee)
        {
            var ExistingEmployee = getEmployee(employee.Id);
            ExistingEmployee.Name = employee.Name;
            return ExistingEmployee;
        }

        public Employee getEmployee(Guid id)
        {
            return employees.SingleOrDefault(x => x.Id == id);
        }

        public List<Employee> getEmployees()
        {
           return employees;
        }
    }
}

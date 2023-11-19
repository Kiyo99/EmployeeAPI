using RestApiDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestApiDemo.EmployeeRepo
{
    public class MockEmployeeData : IEmployeeRepo

    {

        private List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
                Id = Guid.NewGuid(),
                Name = "Mr Arthur",
                age = 40,
                leaveStatus = "notOnLeave"
            },
           new Employee()
           {
                Id = Guid.NewGuid(),
                Name = "Mr Kio",
                age = 30,
                leaveStatus = "notOnLeave"

           },
           new Employee()
           {
                Id = Guid.NewGuid(),
                Name = "Emefa",
                age = 30,
                leaveStatus = "notOnLeave"
           }
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
            ExistingEmployee.age = employee.age;
            ExistingEmployee.leaveStatus = employee.leaveStatus;
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

        public Employee requestLeave(Guid id)
        {
            var exisitingEmployee = getEmployee(id);
            exisitingEmployee.leaveStatus = "onLeave";
            return exisitingEmployee;

        }
    }
}

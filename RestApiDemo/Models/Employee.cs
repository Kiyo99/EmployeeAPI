using System;

namespace RestApiDemo.Models
{
    public class Employee
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int age { get; set; }

        public string leaveStatus { get; set; }
    }
}

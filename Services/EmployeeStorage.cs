using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Services
{
    public class EmployeeStorage
    {
        public readonly List<Employee> employeeStorage = new List<Employee>();

        public void AddEmployee(Employee person)
        {
            employeeStorage.Add(person);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Exceptions;
using Services.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class EmployeeService
    {
        private EmployeeStorage _employeeStorage = new EmployeeStorage();

        public EmployeeService(EmployeeStorage employee)
        {
            _employeeStorage = employee;
        }

        public void AddEmployees(Employee person)
        {
            if (person.BirthDate > DateTime.Parse("01.01.2004"))
            {
                throw new AgeLimitException("Клиент несовершеннолетний");
            }
            if (person.Passport == 0)
            {
                throw new Doesn_tHaveAPassport("У клиента нет паспортных данных");
            }
            _employeeStorage.AddEmployee(person);
        }

        public List<Employee> GetEmployees(EmployeeFilter employeeFilter)
        {
            if (employeeFilter.FirstName != null && employeeFilter.LastName != null && employeeFilter.Patronymic != null)
            {
                return _employeeStorage.employeeStorage.Where(p => p.FirstName == employeeFilter.FirstName)
                                                   .Where(p => p.LastName == employeeFilter.LastName)
                                                   .Where(p => p.Patronymic == employeeFilter.Patronymic)
                                                   .ToList();
            }

            if (employeeFilter.Passport != 0)
            {
                return _employeeStorage.employeeStorage.Where(p => p.Passport == employeeFilter.Passport).ToList();
            }

            if (employeeFilter.Phone != 0)
            {
                return _employeeStorage.employeeStorage.Where(p => p.Phone == employeeFilter.Phone).ToList();
            }

            if (employeeFilter.BirthDateRange != null)
            {
                return _employeeStorage.employeeStorage.Where(p => p.BirthDate >= employeeFilter.BirthDateRange[0] && p.BirthDate <= employeeFilter.BirthDateRange[1])
                                                   .ToList();
            }

            return _employeeStorage.employeeStorage.Where(p => p.FirstName == employeeFilter.FirstName)
                                               .Where(p => p.LastName == employeeFilter.LastName)
                                               .Where(p => p.Patronymic == employeeFilter.Patronymic)
                                               .Where(p => p.Passport == employeeFilter.Passport)
                                               .Where(p => p.Phone == employeeFilter.Phone)
                                               .Where(p => p.BirthDate >= employeeFilter.BirthDateRange[0] && p.BirthDate <= employeeFilter.BirthDateRange[1])
                                               .Where(p => p.Contract == employeeFilter.Contract)
                                               .Where(p => p.Salary == employeeFilter.Salary)
                                               .ToList();
        }
    }
}

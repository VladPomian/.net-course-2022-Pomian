using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Exceptions;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class EmployeeService
    {
        List<Employee> persons = new List<Employee>();

        public void AddEmployee(Employee person)
        {
            if (person.BirthDate > DateTime.Parse("01.01.2004"))
            {
                throw new AgeLimitException("Клиент несовершеннолетний");
            }
            if (person.Passport == 0)
            {
                throw new Doesn_tHaveAPassport("У клиента нет паспортных данных");
            }
            persons.Add(person);
        }
    }
}

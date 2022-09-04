using System;
using Models;

namespace Services
{
    public class BankService
    {
        public decimal Wage(decimal profit, decimal expenses, params Employee[] owners)
        {
            var result = (profit - expenses) / owners.Length;
            return result;
        }

        public Employee ConvertClientToEmployee(Client client)
        {
            var employee = new Employee()
            {
                FirstName = client.FirstName,
                LastName = client.LastName,
                Passport = client.Passport,
                BirthDate = client.BirthDate,
                Patronymic = client.Patronymic
            };
            return employee;
        }
    }
}

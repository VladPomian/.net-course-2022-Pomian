using System;
using Models;
using Services;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ServicesTests
{
    public class EquivalenceTests
    {
        [Fact]
        public void GetHashCodeNecessityPositivTest()
        {
            //Arange
            var dataGenerator = new TestDataGenerator();
            var dictionary = dataGenerator.GenerateDictionaryClientAccount();

            //Act
            var client = dictionary.FirstOrDefault(p => p.Key.Phone == 77500001);

            var clientNew = new Client()
            {
                Phone = 77500001,
                BirthDate = client.Key.BirthDate,
                FirstName = client.Key.FirstName,
                LastName = client.Key.LastName,
                Passport = client.Key.Passport,
                Patronymic = client.Key.Patronymic
            };

            var account = dictionary[clientNew];

            //Assert
            Assert.Equal(account, client.Value);
        }

        [Fact]
        public void EmployeeGetHashCodeNecessityPositivTest()
        {
            //Arange
            var dataGenerator = new TestDataGenerator();

            var employeeList = dataGenerator.GenerateListEmployee();
            employeeList.Add(new Employee() { Phone = 77800001 });

            //Act
            var employee = new Employee() { Phone = 77800001 };
            var searchEmployee = employeeList.Find(p => p == employee);

            //Assert
            Assert.NotNull(searchEmployee);
        }
    }
}

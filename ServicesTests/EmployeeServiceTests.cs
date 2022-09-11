using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Services;
using Services.Filters;
using Models;
using Exceptions;
using Xunit;

namespace ServicesTests
{
    public class EmployeeServiceTests
    {
        [Fact]
        public void AddEmployee_AgeLimitException()
        {
            //Arrange
            var addEmployee = new EmployeeService(new EmployeeStorage());

            var person = new Employee()
            {
                BirthDate = DateTime.Parse("04.02.1976"),
                Passport = 7
            };

            //Act//Assert
            Assert.Throws<AgeLimitException>(() => addEmployee.AddEmployees(person));
        }

        [Fact]
        public void AddEmployee_NoPassportExceptionTest()
        {
            //Arrange
            var addEmployee = new EmployeeService(new EmployeeStorage());

            var person = new Employee()
            {
                BirthDate = DateTime.Parse("07.03.2002"),
                Passport = 0
            };

            //Act//Assert
            Assert.Throws<NoPassportException>(() => addEmployee.AddEmployees(person));
        }

        [Fact]
        public void GetEmployeeTest()
        {
            //Arrange
            var addEmployee = new EmployeeService(new EmployeeStorage());

            var employeeFirst = new Employee()
            {
                FirstName = "Артем",
                LastName = "Виноградов",
                Patronymic = "Андреевич",
                Passport = 1,
                Phone = 77700001,
                BirthDate = DateTime.Parse("05.04.2002")
            };

            var employeeSecond = new Employee()
            {
                FirstName = "Иван",
                LastName = "Виноградов",
                Patronymic = "Андреевич",
                Passport = 2,
                Phone = 77700002,
                BirthDate = DateTime.Parse("08.12.1977")
            };

            var employeeThird = new Employee()
            {
                FirstName = "Мария",
                LastName = "Виноградова",
                Patronymic = "Елисеевна",
                Passport = 3,
                Phone = 77700003,
                BirthDate = DateTime.Parse("14.01.1989")
            };

            //Act
            addEmployee.AddEmployees(employeeFirst);
            addEmployee.AddEmployees(employeeSecond);
            addEmployee.AddEmployees(employeeThird);

            var setTheRange = addEmployee.GetEmployees(new EmployeeFilter()
            {
                BirthDayRangeStart = DateTime.Parse("01.01.1950"),
                BirthDayRangeEnd = DateTime.Parse("31.12.2004")
            });

            var youth = setTheRange.Max(p => p.BirthDate);

            var older = setTheRange.Min(p => p.BirthDate);

            var averageAge = new DateTime((long)setTheRange.Average(p => p.BirthDate.Ticks));

            //Assert
            Assert.Equal(youth, employeeFirst.BirthDate);
            Assert.Equal(older, employeeSecond.BirthDate);
            Assert.Equal(1989, averageAge.Year);
        }
    }
}

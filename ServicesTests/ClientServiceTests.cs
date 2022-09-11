using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Services;
using Models;
using Exceptions;
using Services.Filters;
using Xunit;

namespace ServicesTests
{
    public class ClientServiceTests
    {
        [Fact]
        public void AddClient_AgeLimitExceptionTest()
        {
            //Arrange
            var addClient = new ClientService(new ClientStorage());

            var person = new Client()
            {
                BirthDate = DateTime.Parse("31.04.2009"),
                Passport = 5
            };

            //Act//Assert
            Assert.Throws<AgeLimitException>(() => addClient.AddClients(person));
        }

        [Fact]
        public void AddClient_NoPassportExceptionTest()
        {
            //Arrange
            var addClient = new ClientService(new ClientStorage());

            var person = new Client()
            {
                BirthDate = DateTime.Parse("07.03.2002"),
                Passport = 0
            };

            //Act//Assert
            Assert.Throws<NoPassportException>(() => addClient.AddClients(person));
        }

        [Fact]
        public void GetClientsTest()
        {
            //Arrange
            var addClient = new ClientService(new ClientStorage());

            var clientFirst = new Client()
            {
                FirstName = "Артем",
                LastName = "Виноградов",
                Patronymic = "Андреевич",
                Passport = 1,
                Phone = 77700001,
                BirthDate = DateTime.Parse("05.04.2002")
            };

            var clientSecond = new Client()
            {
                FirstName = "Иван",
                LastName = "Виноградов",
                Patronymic = "Андреевич",
                Passport = 2,
                Phone = 77700002,
                BirthDate = DateTime.Parse("08.12.1977")
            };

            var clientThird = new Client()
            {
                FirstName = "Мария",
                LastName = "Виноградова",
                Patronymic = "Елисеевна",
                Passport = 3,
                Phone = 77700003,
                BirthDate = DateTime.Parse("14.01.1989")
            };

            //Act
            addClient.AddClients(clientFirst);
            addClient.AddClients(clientSecond);
            addClient.AddClients(clientThird);

            var setTheRange = addClient.GetClients(new ClientFilter()
            {
                BirthDayRangeStart = DateTime.Parse("01.01.1950"),
                BirthDayRangeEnd = DateTime.Parse("31.12.2004")
            });

            var youth = setTheRange.Max(p => p.Key.BirthDate);

            var older = setTheRange.Min(p => p.Key.BirthDate);

            var averageAge = new DateTime((long)setTheRange.Average(p => p.Key.BirthDate.Ticks));

            //Assert
            Assert.Equal(youth, clientFirst.BirthDate);
            Assert.Equal(older, clientSecond.BirthDate);
            Assert.Equal(1989, averageAge.Year);
        }

        [Fact]
        public void AddClient_EqualNamesExceptionTest()
        {
            //Arrange
            var addClient = new ClientService(new ClientStorage());

            var person = new Client()
            {
                FirstName = "firstname",
                LastName = "lastname",
                Patronymic = "patronymic",
                Passport = 1,
                Phone = 77700001,
                BirthDate = DateTime.Parse("07.03.2002")
            };

            //Act
            addClient.AddClients(person);

            //Assert
            Assert.Throws<ArgumentException>(() => addClient.AddClients(person));
        }
    }
}

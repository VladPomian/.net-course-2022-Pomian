using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Services;
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
            var addEmployee = new EmployeeService();
            var maria = new Employee
            {
                BirthDate = new DateTime(30),
                Passport = 5437
            };

            try
            {
                addEmployee.AddEmployee(maria);
            }
            catch (AgeLimitException e)
            {
                Assert.Equal("Сотрудник несовершеннолетний", e.Message);
                Assert.Equal(typeof(AgeLimitException), e.GetType());
            }
            catch (Doesn_tHaveAPassport e)
            {
                Assert.Equal("У сотрудника нет паспортных данных", e.Message);
                Assert.Equal(typeof(Doesn_tHaveAPassport), e.GetType());
            }
            catch (Exception e)
            {
                Assert.True(false);
            }
        }
    }
}

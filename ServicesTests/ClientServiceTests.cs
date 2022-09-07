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
    public class ClientServiceTests
    {
        [Fact]
        public void AddClient_AgeLimitException()
        {
            var addClient = new ClientService();
            var eric = new Client
            {
                BirthDate = new DateTime(14),
                Passport = 0
            };

            try
            {
                addClient.AddClients(eric);
            }
            catch (AgeLimitException e)
            {
                Assert.Equal("Клиент несовершеннолетний", e.Message);
                Assert.Equal(typeof(AgeLimitException), e.GetType());
            }
            catch (Doesn_tHaveAPassport e)
            {
                Assert.Equal("У клиента нет паспортных данных", e.Message);
                Assert.Equal(typeof(Doesn_tHaveAPassport), e.GetType());
            }
            catch (Exception e)
            {
                Assert.True(false);
            }
        }
    }
}

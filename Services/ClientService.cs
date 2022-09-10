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
    public class ClientService
    {
        private ClientStorage _clientStorage = new ClientStorage();

        public ClientService(ClientStorage client)
        {
            _clientStorage = client;
        }

        public void AddClients(Client person)
        {
            if (person.BirthDate > DateTime.Parse("01.01.2004"))
            {
                throw new AgeLimitException("Клиент несовершеннолетний");
            }

            if (person.Passport == 0)
            {
                throw new Doesn_tHaveAPassport("У клиента нет паспортных данных");
            }

            _clientStorage.AddClient(person);
        }

        public Dictionary<Client, List<Account>> GetClients(ClientFilter clientFilter)
        {
            if (clientFilter.FirstName != null && clientFilter.LastName != null && clientFilter.Patronymic != null)
            {
                return _clientStorage.clientStorage.Where(p => p.Key.FirstName == clientFilter.FirstName)
                                                   .Where(p => p.Key.LastName == clientFilter.LastName)
                                                   .Where(p => p.Key.Patronymic == clientFilter.Patronymic)
                                                   .ToDictionary(d => d.Key, d => d.Value);
            }

            if (clientFilter.Passport != 0)
            {
                return _clientStorage.clientStorage.Where(p => p.Key.Passport == clientFilter.Passport).ToDictionary(d => d.Key, d => d.Value);
            }

            if (clientFilter.Phone != 0)
            {
                return _clientStorage.clientStorage.Where(p => p.Key.Phone == clientFilter.Phone).ToDictionary(d => d.Key, d => d.Value);
            }

            if (clientFilter.BirthDateRange != null)
            {
                return _clientStorage.clientStorage.Where(p => p.Key.BirthDate >= clientFilter.BirthDateRange[0] && p.Key.BirthDate <= clientFilter.BirthDateRange[1])
                                                   .ToDictionary(d => d.Key, d => d.Value);
            }

            return _clientStorage.clientStorage.Where(p => p.Key.FirstName == clientFilter.FirstName)
                                               .Where(p => p.Key.LastName == clientFilter.LastName)
                                               .Where(p => p.Key.Patronymic == clientFilter.Patronymic)
                                               .Where(p => p.Key.Passport == clientFilter.Passport)
                                               .Where(p => p.Key.Phone == clientFilter.Phone)
                                               .Where(p => p.Key.BirthDate >= clientFilter.BirthDateRange[0] && p.Key.BirthDate <= clientFilter.BirthDateRange[1])
                                               .ToDictionary(d => d.Key, d => d.Value);
        }
    }
}

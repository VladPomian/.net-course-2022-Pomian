using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Bogus;
using Bogus.DataSets;
using Currency = Models.Currency;

namespace Services
{
    public class TestDataGenerator
    {
        public List<Client> GenerateListClient()
        {
            int client_sNum = 0;

            List<Client> clients = new List<Client>();

            var generator = new Faker<Client>("ru").StrictMode(true)
                            .RuleFor(x => x.FirstName, f => f.Name.FirstName())
                            .RuleFor(x => x.LastName, f => f.Name.LastName())
                            .RuleFor(x => x.Patronymic, f => "")
                            .RuleFor(x => x.Passport, f => f.Random.Int(1, 500))
                            .RuleFor(x => x.Phone, f => 77500000 + client_sNum)
                            .RuleFor(x => x.BirthDate, f => f.Date.Between(DateTime.Parse("01.01.1990"), DateTime.Now));

            for (client_sNum = 0; client_sNum <= 999; client_sNum++)
            {
                clients.Add(generator.Generate());
            }
            return clients;
        }

        public List<Employee> GenerateListEmployee()
        {
            int employee_sNum = 0;

            List<Employee> employees = new List<Employee>();

            var generator = new Faker<Employee>("ru").StrictMode(true)
                            .RuleFor(x => x.FirstName, f => f.Name.FirstName())
                            .RuleFor(x => x.LastName, f => f.Name.LastName())
                            .RuleFor(x => x.Patronymic, f => "")
                            .RuleFor(x => x.Passport, f => f.Random.Int(1, 500))
                            .RuleFor(x => x.Phone, f => 77500000 + employee_sNum)
                            .RuleFor(x => x.Salary, f => f.Random.Decimal(1_000, 100_000))
                            .RuleFor(x => x.Contract, f => "")
                            .RuleFor(x => x.BirthDate, f => f.Date.Between(DateTime.Parse("01.01.1990"), DateTime.Now));

            for (employee_sNum = 0; employee_sNum <= 999; employee_sNum++)
            {
                employees.Add(generator.Generate());
            }

            return employees;
        }

        public Dictionary<int, Client> GenerateDictionaryClient()
        {
            int client_sNum = 0;

            Dictionary<int, Client> clients = new Dictionary<int, Client>();

            var generator = new Faker<Client>().StrictMode(true)
                            .RuleFor(x => x.FirstName, f => f.Name.FirstName())
                            .RuleFor(x => x.LastName, f => f.Name.LastName())
                            .RuleFor(x => x.Patronymic, f => "")
                            .RuleFor(x => x.Passport, f => f.Random.Int(1, 1000))
                            .RuleFor(x => x.Phone, f => 77500000 + client_sNum)
                            .RuleFor(x => x.BirthDate, f => f.Date.Between(DateTime.Parse("01.01.1990"), DateTime.Now));

            for (client_sNum = 0; client_sNum <= 999; client_sNum++)
            {
                var fakeClient = generator.Generate();
                clients.Add(fakeClient.Phone, fakeClient);
            }

            return clients;
        }

        public Dictionary<Client, List<Account>> GenerateDictionaryClientAccount()
        {
            Dictionary<Client, List<Account>> clients = new Dictionary<Client, List<Account>>();

            var fakeClients = GenerateListClient();

            string[] fakeCurrencyName = { "Rub", "Lei", "Eu", "Ua" };

            var currency = new Currency()
            {
                Name = fakeCurrencyName[new Random().Next(fakeCurrencyName.Length)],
                Code = new Random().Next(1000)
            };

            Faker<Account> generatorAccount = new Faker<Account>().StrictMode(true)
                                                .RuleFor(x => x.Amount, c => c.Random.Int(1, 1000))
                                                .RuleFor(x => x.Currency, c => currency);

            for (int client_sNum = 0; client_sNum <= 999; client_sNum++)
            {
                List<Account> fakeAccountList = new List<Account>();

                for (int client_sAcc = 0; client_sAcc < 2; client_sAcc++)
                {
                    currency = new Currency()
                    {
                        Name = fakeCurrencyName[new Random().Next(fakeCurrencyName.Length)],
                        Code = new Random().Next(1000)
                    };

                    fakeAccountList.Add(generatorAccount.Generate());
                }

                clients.Add(fakeClients[client_sNum], fakeAccountList);
            }

            return clients;
        }
    }
}

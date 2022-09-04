﻿using System;
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
            int i = 0;
            List<Client> clients = new List<Client>();
            var generator = new Faker<Client>("ru").StrictMode(true)
    .RuleFor(x => x.FirstName, f => f.Name.FirstName())
    .RuleFor(x => x.LastName, f => f.Name.LastName())
    .RuleFor(x => x.Patronymic, f => "")
    .RuleFor(x => x.Passport, f => f.Random.Int(1, 500))
    .RuleFor(x => x.Phone, f => 77500000 + i)
    .RuleFor(x => x.BirthDate, f => f.Date.Between(DateTime.Parse("01.01.1990"), DateTime.Now));
            for (i=0; i <= 999; i++)
            {
                clients.Add(generator.Generate());
            }
            return clients;
        }

        public List<Employee> GenerateListEmployee()
        {
            int i = 0;
            List<Employee> employees = new List<Employee>();
            var generator = new Faker<Employee>("ru").StrictMode(true)
    .RuleFor(x => x.FirstName, f => f.Name.FirstName())
    .RuleFor(x => x.LastName, f => f.Name.LastName())
    .RuleFor(x => x.Patronymic, f => "")
    .RuleFor(x => x.Passport, f => f.Random.Int(1, 500))
    .RuleFor(x => x.Phone, f => 77500000 + i)
    .RuleFor(x => x.Salary, f => f.Random.Decimal(1_000, 100_000))
    .RuleFor(x => x.Contract, f => "")
    .RuleFor(x => x.BirthDate, f => f.Date.Between(DateTime.Parse("01.01.1990"), DateTime.Now));

            for (i = 0; i <= 999; i++)
            {
                employees.Add(generator.Generate());
            }

            return employees;
        }

        public Dictionary<int, Client> GenerateDictionaryClient()
        {
            int i = 0;
            Dictionary<int, Client> clients = new Dictionary<int, Client>();
            var generator = new Faker<Client>().StrictMode(true)
    .RuleFor(x => x.FirstName, f => f.Name.FirstName())
    .RuleFor(x => x.LastName, f => f.Name.LastName())
    .RuleFor(x => x.Patronymic, f => "")
    .RuleFor(x => x.Passport, f => f.Random.Int(1, 1000))
    .RuleFor(x => x.Phone, f => 77500000 + i)
    .RuleFor(x => x.BirthDate, f => f.Date.Between(DateTime.Parse("01.01.1990"), DateTime.Now));

            for (i = 0; i <= 999; i++)
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

            Faker<Account> generatorAccount = new Faker<Account>()
            .StrictMode(true)
            .RuleFor(x => x.Amount, c => c.Random.Int(1, 1000))
            .RuleFor(x => x.Currency, c => currency);

            for (int i = 0; i <= 999; i++)
            {
                List<Account> fakeAccountList = new List<Account>();

                for (int j = 0; j < 2; j++)
                {
                    currency = new Currency()
                    {
                        Name = fakeCurrencyName[new Random().Next(fakeCurrencyName.Length)],
                        Code = new Random().Next(1000)
                    };

                    fakeAccountList.Add(generatorAccount.Generate());
                }

                clients.Add(fakeClients[i], fakeAccountList);
            }

            return clients;
        }
    }
}

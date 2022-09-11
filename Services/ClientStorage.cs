using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Exceptions;

namespace Services
{
    public class ClientStorage
    {
        public readonly Dictionary<Client, List<Account>> clientStorage = new Dictionary<Client, List<Account>>();

        public void AddClient(Client person)
        {
            var listAcc = new List<Account>
            { 
                new Account()
                {
                    Currency = new Currency()
                    {
                        Name = "RUB",
                        Code = 1
                    }
                }
            };

            clientStorage.Add(person, listAcc);
        }
    }
}

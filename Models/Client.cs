using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem.Models
{
    public class Client : Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Passport { get; set; }
    }
}

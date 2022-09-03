using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Models
{
    public interface Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Passport { get; set; }

        public int GetHashCode();
        public bool Equals(object obj);
    }
}

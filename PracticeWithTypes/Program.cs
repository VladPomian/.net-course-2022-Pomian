using System;
using Models;

namespace PracticeWithTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee Bill = new Employee { Name = "Bill" };
            Bill.Contract = 3;
            Console.WriteLine(Bill.Contract);

            Employee Tom = new Employee { Name = "Tom", Age = 23, Contract = 4 };
            Console.WriteLine(Tom.Contract);

            Currency Dollars = new Currency { Price = 32 };
            Console.WriteLine(Dollars.Price);
        }
    }
}

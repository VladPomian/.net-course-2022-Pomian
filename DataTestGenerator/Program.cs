using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using Models1;

namespace DataTestGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var EmployeeList = GetEmployeeList();
            var ClientList = GetClientList();
            var EmployeeDictionary = GetEmployeeDictionary();

            foreach (var i in EmployeeList)
            {
                Console.Write(i.Name + " ");
            }
            Console.WriteLine();

            foreach (var i in ClientList)
            {
                Console.Write(i.Name + " ");
            }
            Console.WriteLine();

            foreach (var i in EmployeeDictionary)
            {
                Console.Write(i.Key + " " + i.Value.Name);
                Console.WriteLine();
            }

            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            var ClientName = EmployeeDictionary.FirstOrDefault(p => p.Key == 77773335);
            Console.Write(ClientName.Value.Name);
            Console.WriteLine();
            sw.Stop();
            var res = sw.ElapsedTicks;
            Console.Write(res);
        }
        public static List<Employee> GetEmployeeList()
        {
            var employee = new List<Employee>();

            for (int i = 0; i < 10; i++)
            {
                employee.Add(new Employee
                {
                    Name = "NameEmployee_" + i,
                    Number = i
                });
            }
            return employee;
        }

        public static List<Client> GetClientList()
        {
            var client = new List<Client>();

            for (int i = 0; i < 10; i++)
            {
                client.Add(new Client
                {
                    Name = "NameClient_" + i,
                    Number = i
                });
            }
            return client;
        }
        public static Dictionary<int, Employee> GetEmployeeDictionary()
        {
            int PhoneNumber;
            var employee = new Dictionary<int, Employee>();

            for (int i = 0; i < 10; i++)
            {
                employee.Add(
                    PhoneNumber = 77773330 + i,
                    new Employee
                    {
                        Name = "Name_" + i,
                        Number = i
                    });
            }
            return employee;
        }
    }
}

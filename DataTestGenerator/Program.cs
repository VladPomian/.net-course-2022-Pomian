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
            var ClientDictionary = GetClientDictionary();

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
                Console.Write(i.Key.PhoneNumber + " " + i.Value.Name);
                Console.WriteLine();
            }
            foreach (var i in ClientDictionary)
            {
                Console.Write(i.Key.Age + " " + i.Value.Name);
                Console.WriteLine();
            }


            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            var EmployeeName = EmployeeDictionary.FirstOrDefault(p => p.Key.PhoneNumber == 77773335);
            sw.Stop();
            Console.WriteLine();
            var res = sw.ElapsedTicks;
            Console.Write(res + " Ticks per phone number");

            var sw1 = new System.Diagnostics.Stopwatch();
            sw1.Start();
            var ClientName = ClientDictionary.FirstOrDefault(p => p.Key.Age < 13);
            sw1.Stop();
            Console.WriteLine();
            var res1 = sw1.ElapsedTicks;
            Console.Write(res1 + " Ticks per age client");
            Console.WriteLine();
            foreach (var i in ClientName.Value.Name)
            {
                Console.Write(i);
            }
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
        public static Dictionary<Employee, Employee> GetEmployeeDictionary()
        {
            var employee = new Dictionary<Employee, Employee>();

            for (int i = 0; i < 10; i++)
            {
                employee.Add(
                    new Employee
                    {
                        PhoneNumber = 77773330 + i
                    },
                    new Employee
                    {
                        Name = "Name_" + i,
                        Number = i,
                        Wage = (i+1) * 1000
                    });
            }
            return employee;
        }
        public static Dictionary<Client, Client> GetClientDictionary()
        {
            var client = new Dictionary<Client, Client>();

            for (int i = 0; i < 10; i++)
            {
                client.Add(
                    new Client
                    { 
                        Age = i+10
                    },
                    new Client
                    {
                        Name = "Name_" + i,
                        Number = i
                    });
            }
            return client;
        }
    }
}

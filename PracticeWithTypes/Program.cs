using System;
using Services;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace PracticeWithTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataGenerator = new TestDataGenerator();

            //поиск клиента по его номеру телефона в коллекции
            var clientsList = new List<Client>();
            clientsList = dataGenerator.GenerateListClient();

            var testClient = clientsList[20];

            var sw = new Stopwatch();
            sw.Start();

            var resultClientList = clientsList.FirstOrDefault(p => p.Phone == testClient.Phone);
            sw.Stop();

            Console.WriteLine(resultClientList.FirstName);
            Console.WriteLine($"Поиск в коллекции: {sw.ElapsedTicks} \n");

            //поиск клиента по его номеру телефона в словаре
            var clientsDictionary = new Dictionary<int, Client>();
            clientsDictionary = dataGenerator.GenerateDictionaryClient();

            testClient = clientsDictionary[20];

            sw.Restart();

            var resultClientDictionary = clientsDictionary.FirstOrDefault(p => p.Key == testClient.Phone);
            sw.Stop();

            Console.WriteLine(resultClientDictionary.Value.FirstName);
            Console.WriteLine($"Поиск в словаре: {sw.ElapsedTicks} \n");

            //поиск клиента чей возраст меньше 18 лет
            var babyClient = clientsList.Where(p => p.BirthDate >= DateTime.Parse("01.01.2004")).ToList();

            foreach (var i in babyClient)
            {
                Console.WriteLine($"Несовершеннолетний:{i.FirstName}");
            }

            //поиск сотрудника с наименьшей зарплатой
            List<Employee> employees = new List<Employee>();
            employees = dataGenerator.GenerateListEmployee();

            var minEmployeeSalary = employees.Min(e => e.Salary);

            var resultEmployeeList = employees.Where(e => e.Salary == minEmployeeSalary).ToList();

            Console.WriteLine("\nСотрудники с минимальной зарплатой:");
            foreach (var item in resultEmployeeList)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }

            Console.WriteLine($"Минимальная зарплата составляет: {minEmployeeSalary}\n");

            //поиск последнего клиента
            sw.Reset();
            sw.Start();

            var firstOrDefount = clientsDictionary.FirstOrDefault(c => c.Key == clientsDictionary.Count - 1);

            sw.Stop();

            Console.WriteLine("Имя последнего клиента коллекции = " + firstOrDefount.Value.FirstName
                            + "а время его поиска заняло " + sw.ElapsedTicks);

            sw.Reset();
            sw.Start();

            var lastClient = clientsDictionary[clientsDictionary.Count - 1];

            sw.Stop();

            Console.WriteLine($"Поиск последнего элемента коллекции по ключу занял: {sw.ElapsedTicks}");
        }

        public static void UpdateContactWrongApproach(Employee employee) 
        {
            employee.Contract = $"{employee.FirstName} {employee.LastName} {employee.Patronymic}," +
                                $" родившийся {employee.BirthDate}, имеющий паспорт: {employee.Passport} принят на работу!";
        }

        public static string UpdateContactRightApproach(string firstName, string lastName, string patronymic, DateTime dataTime, int passport) 
        {
            return $"{firstName} {lastName} {patronymic}, родившийся {dataTime}, имеющий паспорт: {passport} принят на работу!";
        }

        public static Currency UpdateCurrency(string name, int code)
        {
            return new Currency() { Name = name, Code = code };
        }
    }
}

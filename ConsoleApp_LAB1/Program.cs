using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_LAB1
{
    class Program
    {
        /// <summary>
        /// Class Main.
        /// </summary>
        private static void Main(string[] args)
        {
            // Создание двух списков
            var olds = new PersonList();
            var youth = new PersonList();

            // Создание 6-ти персон для заполнения списков
            var ivanov = new Person
                ("Ivan", "Ivanov", 50, Gender.Male);
            var petrov = new Person
                ("Petr", "Petrov", 45, Gender.Male);
            var sidorov = new Person
                ("Sidor", "Sidorov", 40, Gender.Male);

            var ush1 = new Person
                ("Alexander", "Ushakov", 23, Gender.Male);
            var ush2 = new Person
                ("Victor", "Ushakov", 28, Gender.Male);
            var ush3 = new Person
                ("Vladimir", "Ushakov", 35, Gender.Male);

            // Добавление персон в списки
            olds.AddPerson(ivanov);
            olds.AddPerson(petrov);
            olds.AddPerson(sidorov);

            youth.AddPerson(ush1);
            youth.AddPerson(ush2);
            youth.AddPerson(ush3);

            // Вывод списков в консоль
            _ = Console.ReadKey();
            Console.WriteLine("List of olds:");
            PrintList(olds);

            Console.WriteLine("List of youth:");
            PrintList(youth);

            // Добавление новой персоны в список
            _ = Console.ReadKey();
            var kharitonov = new Person
                ("Khariton", "Kharitonov", 35, Gender.Male);
            olds.AddPerson(kharitonov);
            Console.WriteLine("New person has been added to the 1st list");

            // Копирование второй персоны из первого листа
            // во второй
            _ = Console.ReadKey();
            youth.AddPerson(olds.SearchPerson(1));
            Console.WriteLine("Second person from the 1st list has been" +
                " added to the 2nd list");

            // Печать откорректированных листов
            _ = Console.ReadKey();
            Console.WriteLine("List of olds:");
            PrintList(olds);

            Console.WriteLine("List of youth:");
            PrintList(youth);

            // Удаление второй персоны из первого списка
            _ = Console.ReadKey();
            olds.DeletePersonByIndex(1);
            Console.WriteLine("Second person from the 1st list has been" +
                " removed");

            // Печать откорректированных листов
            _ = Console.ReadKey();
            Console.WriteLine("List of olds:");
            PrintList(olds);

            Console.WriteLine("List of youth:");
            PrintList(youth);

            // Очистко второго листа
            _ = Console.ReadKey();
            youth.ClearList();
            Console.WriteLine("2nd list (youth) has been cleared");

            // Печать откорректированных листов
            Console.WriteLine("List of youth:");
            PrintList(youth);
            Console.WriteLine();
        }
        /// <summary>
        /// Функция, позволяющая распечатать список людей.
        /// </summary>
        /// <param name="personList">Экземпляр класса PersonList.</param>
        private static void PrintList(PersonList personList)
        {
            if (personList == null)
            {
                throw new NullReferenceException("Null reference list.");
            }

            if (personList.NumberOfPersons() != 0)
            {
                for (int i = 0; i < personList.NumberOfPersons(); i++)
                {
                    var tmpPerson = personList.SearchPerson(i);
                    Console.WriteLine(tmpPerson.ValuesOfPerson());
                }
            }
            else
            {
                Console.WriteLine("List is empty.");
            }
        }
    }
}

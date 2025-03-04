using Model;
using System;
using System.Collections.Generic;

namespace ConsoleApp_LAB1
{
    /// <summary>
    /// Выполняемая часть программы
    /// </summary>
    public class Program
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
            Console.WriteLine("Для продолжения нажмите клавишу ENTER");
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

            // Проверка ввода персоны
            _ = Console.ReadKey();

            var inputPerson = InputPersonByConsole();
            Console.WriteLine(inputPerson.GetInformation());

            // Проверка случайной персоны
            _ = Console.ReadKey();

            Console.Write("Random person is: ");
            var randomPerson = Person.GetRandomPerson();
            Console.WriteLine(randomPerson.GetInformation());
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
                    Console.WriteLine(tmpPerson.GetInformation());
                }
            }
            else
            {
                Console.WriteLine("List is empty.");
            }
        }

        /// <summary>
        /// Метод, позволяющий вводить информацию с помощью консоли.
        /// </summary>
        /// <returns>Экземпляр класса Person.</returns>
        /// <exception cref="ArgumentException">Только числа.</exception>
        public static Person InputPersonByConsole()
        {
            var person = new Person();

            var actionList = new List<(Action<string>, string)>
            {
                (
                new Action<string>((string property) =>
                {
                    Console.Write($"Enter student {property}: ");
                    person.Name = Console.ReadLine();
                    if (person.Name=="")
                    {
                        throw new IndexOutOfRangeException("");
                    }
                }), "name"),

                (new Action<string>((string property) =>
                {
                    Console.Write($"Enter student {property}: ");
                    person.Surname = Console.ReadLine();
                  if (person.Surname=="")
                    {
                        throw new IndexOutOfRangeException("");
                    }
                }), "surname"),

                (new Action<string>((string property) =>
                {
                    Console.Write($"Enter student {property}: ");
                    if (!int.TryParse(Console.ReadLine(), out int tmpAge))
                    {                       
                        throw new FormatException
                           ($"Возраст - это число " +
                           $"от {Person.MinAge} до {Person.MaxAge}");
                    }
                    person.Age = tmpAge;
                }), "age"),

                (new Action<string>((string property) =>
                {
                    Console.Write
                        ($"Enter student {property} (1 - Male or 2 - Female): ");
                    _ = int.TryParse(Console.ReadLine(), out int tmpGender);
                    if (tmpGender < 1 || tmpGender > 2)
                    {
                        throw new IndexOutOfRangeException
                            ("Чиcло должно быть в диапазоне [1; 2].");
                    }

                    var realGender = tmpGender == 1
                        ? Gender.Male
                        : Gender.Female;
                    person.Gender = realGender;
                }), "gender")
            };

            foreach (var action in actionList)
            {
                ActionHandler(action.Item1, action.Item2);
            }

            return person;
        }

        /// <summary>
        /// Метод, который используется для выполнения действий со списком.
        /// </summary>
        /// <param name="action">Определенное действие.</param>
        /// <param name="propertyName">Дополнительный параметр
        /// для исключения.</param>
        private static void ActionHandler(Action<string> action, string propertyName)
        {
            while (true)
            {
                try
                {
                    action.Invoke(propertyName);
                    break;
                }
                catch (Exception exception)
                {
                    if (exception.GetType() == typeof(IndexOutOfRangeException)
                        || exception.GetType() == typeof(FormatException)
                        || exception.GetType() == typeof(ArgumentException))
                    {
                        Console.WriteLine($"Incorrect {propertyName}." +
                        $" Ошибка: {exception.Message}" +
                        $" Пожалуйста, введите {propertyName} снова.");
                    }
                    else
                    {
                        throw exception;
                    }
                }
            }
        }
    }    
}
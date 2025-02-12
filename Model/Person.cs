using System.Xml.Linq;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Model
{
    /// <summary>
    /// Класс описывающий персону.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Имя персоны.
        /// </summary>
        private string _name;

        /// <summary>
        /// Фамилия персоны.
        /// </summary>
        private string _surname;

        /// <summary>
        /// Возраст персоны.
        /// </summary>
        private int _age;

        /// <summary>
        /// Пол персоны.
        /// </summary>
        private Gender _gender;

        /// <summary>
        /// Минимальное значение возраста.
        /// </summary>
        private const int MinAge = 0;

        /// <summary>
        /// Максимальное значение возраста.
        /// </summary>
        private const int MaxAge = 150;

        /// <summary>
        /// Констректор класса Person.
        /// </summary>
        /// <param name="name">Имя персоны.</param>
        /// <param name="surname">Фамилия персоны.</param>
        /// <param name="age">Возраст персоны.</param>
        /// <param name="gender">Пол персоны.</param>
         
        /// <summary>
        /// Ввод имени персоны.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _ = CheckStringLanguage(value);
                _name = EditRegister(value);

                if (_surname != null)
                {
                    CheckNameSurname();
                }
            }
        }

        /// <summary>
        /// Ввод фамилии персоны.
        /// </summary>
        public string Surname
        {
            get
            {
                return _surname;
            }

            set
            {
                _ = CheckStringLanguage(value);
                _surname = EditRegister(value);

                if (_name != null)
                {
                    CheckNameSurname();
                }
            }
        }

        /// <summary>
        /// Ввод возраств персоны.
        /// </summary>
        public int Age
        {
            get
            {
                return _age;
            }

            set
            {
                if (value > MinAge && value < MaxAge)
                {
                    _age = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Age value must" +
                          $" be in range [{MinAge}:{MaxAge}].");
                }
            }
        }

        /// <summary>
        /// Ввод пола персоны.
        /// </summary>
        public Gender Gender
        {
            get
            {
                return _gender;
            }

            set
            {
                _gender = value;
            }
        }
        public Person
            (string name, string surname, int age, Gender gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;

        }
        /// <summary>
        /// Проверка языка строки.
        /// </summary>
        /// <param name="name">Строка.</param>
        private static Language CheckStringLanguage(string name)
        {
            var latinSymbols = new Regex
                (@"^[A-z]+(-[A-z])?[A-z]*$");
            var cyrillicSymbols = new Regex
                (@"^[А-я]+(-[А-я])?[А-я]*$");

            if (string.IsNullOrEmpty(name) == false)
            {
                if (latinSymbols.IsMatch(name))
                {
                    return Language.EN;
                }
                else if (cyrillicSymbols.IsMatch(name))
                {
                    return Language.RU;
                }
                else
                {
                    throw new ArgumentException("Incorrect input." +
                        " Please, try again!");
                }
            }

            return Language.Unknown;
        }

        /// <summary>
        /// Срвнение языков имени и фамилии.
        /// </summary>
        /// <exception cref="FormatException">Только один
        /// язык.</exception>
        private void CheckNameSurname()
        {
            if ((string.IsNullOrEmpty(Name) == false)
                && (string.IsNullOrEmpty(Surname) == false))
            {
                var nameLanguage = CheckStringLanguage(Name);
                var surnameLanguage = CheckStringLanguage(Surname);

                if (nameLanguage != surnameLanguage)
                {
                    throw new FormatException("Name and Surname must" +
                            " be only in one language.");
                }
            }
        }

        /// <summary>
        /// Создает набор значений для вывода в консоль.
        /// </summary>
        public string ValuesOfPerson()
        {
            return ""+Name+" "+Surname+" "+Age+" "+Gender;
        }

        /// <summary>
        /// Преобразование регистра: первая заглавная, остальные строчные.
        /// </summary>
        /// <param name="word">Имя или фамилия персоны.</param>
        /// <returns>Отредактированные имя или фамилия персоны.</returns>
        private static string EditRegister(string word)
        {
            return CultureInfo.CurrentCulture.TextInfo.
                ToTitleCase(word.ToLower());
        }

    }

}

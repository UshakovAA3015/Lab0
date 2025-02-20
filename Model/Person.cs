using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml.Linq;

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
        /// Ввод возраста персоны.
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
                    throw new IndexOutOfRangeException("Введите в " +
                          $" пределах [{MinAge}:{MaxAge}].");
                }
            }
        }

        /// <summary>
        /// Ввод пола персоны.
        /// </summary>
        public  Gender Gender { get; set; }

        //TODO: XML
        /// <summary>
        /// Конструктор класса Person.
        /// </summary>
        public Person(string name, string surname, int age, Gender gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
        }

        /// <summary>
        /// Метод, позволяющий ввести случайную персону.
        /// </summary>
        /// <returns>Random person.</returns>
        public static Person GetRandomPerson()
        {
            string[] maleNames =
            {
                "Alex", "Tom", "John", "Vlad", "Eugene",
                "Viktor", "Ivan", "Petr", "Khariton"
            };

            string[] femaleNames =
            {
                "Darya", "Valentina", "Varvara", "Julia", "Alyona",
                "Elena", "Katerine", "Olga", "Sofia"
            };

            string[] surnames =
            {
                "Abramson", "Alford", "Anderson", "Bates", "Bethel",
                "Becker", "Richards", "Pearcy", "Peterson", "Philips"
            };

            var random = new Random();
            var tmpNumber = random.Next(1, 3);

            Gender tmpGender = tmpNumber == 1
                ? Gender.Male
                : Gender.Female;

            string tmpName = tmpGender == Gender.Male
                ? maleNames[random.Next(maleNames.Length)]
                : femaleNames[random.Next(femaleNames.Length)];

            var tmpSurname = surnames[random.Next(surnames.Length)];
            var tmpAge = random.Next(MinAge, MaxAge);

            return new Person(tmpName, tmpSurname, tmpAge, tmpGender);
        }

        /// <summary>
        /// Проверка языка ввода.
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
                    throw new FormatException("Имя и фамилия" +
                            " должны быть на одном языке.");
                }
            }
        }

        //TODO: rename
        /// <summary>
        /// Создает набор значений для вывода в консоль.
        /// </summary>
        public string PersonInformation()
        {
            return $"{Name} {Surname}; Возраст - {Age}; Пол - {Gender}";
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

        //TODO: rewrite
        /// <summary>
        /// Инициализация нового экземпляра класаа <see cref="Person"/> .
        /// </summary>
        public Person()
        {
            //TODO: duplication
            Name = "";
            Surname = "";
            Age = Convert.ToInt32("18");
            Gender = (Gender)Convert.ToInt32("1");

        }       
    }
}

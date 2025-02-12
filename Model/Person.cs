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
        private string Name;

        /// <summary>
        /// Фамилия персоны.
        /// </summary>
        private string Surname;

        /// <summary>
        /// Возраст персоны.
        /// </summary>
        private int Age;

        /// <summary>
        /// Пол персоны.
        /// </summary>
        private Gender Gender;

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
        public Person
            (string name, string surname, int age, Gender gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;

        }

    }

}

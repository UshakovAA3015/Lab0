using System;

namespace Model
{
    /// <summary>
    /// Класс, который описывает список персон (в виде массива).
    /// </summary>
    public class PersonList
    {
        //TODO: RSDN
        /// <summary>
        /// Массив персон.
        /// </summary>
        private Person[] ArrayOfPersons = new Person[0];

        /// <summary>
        /// Функция добавления персоны в конец массива.
        /// </summary>
        /// <param name="person">Персона была добавлена.</param>
        public void AddPerson(Person person)
        {
            var indexOfNewPerson = ArrayOfPersons.Length;
            Array.Resize(ref ArrayOfPersons, indexOfNewPerson + 1);
            ArrayOfPersons[indexOfNewPerson] = person;
        }

        /// <summary>
        /// Метод, проверяющий правильность входного индекса.
        /// </summary>
        /// <param name="index">Входной индекс.</param>
        /// <exception cref="IndexOutOfRangeException">Индекс выходит
        /// за рамки допустимых значений.</exception>
        private void IsIndexInArray(int index)
        {
            if (index < 0 || index >= ArrayOfPersons.Length)
            {
                throw new IndexOutOfRangeException
                    ("Index is out of the bounds.");
            }
        }

        /// <summary>
        /// Метод удаляющий персону по вводимому индексу.
        /// </summary>
        /// <param name="index">Входной индекс.</param>
        public void DeletePersonByIndex(int index)
        {
            IsIndexInArray(index);

            for (int i = index; i < ArrayOfPersons.Length - 1; i++)
            {
                ArrayOfPersons[i] = ArrayOfPersons[i + 1];
            }

            Array.Resize(ref ArrayOfPersons, ArrayOfPersons.Length - 1);
        }

        /// <summary>
        /// Метод удаляющий персону.
        /// </summary>
        /// <param name="person">Персона была удалена.</param>
        public void DeletePerson(Person person)
        {
            int index = Array.IndexOf(ArrayOfPersons, person);
            DeletePersonByIndex(index);
        }

        /// <summary>
        /// Метод находящий персноу в массиве по индексу.
        /// </summary>
        /// <param name="index">Индекс персоны в массиве.</param>
        /// <returns>Персона из массива.</returns>
        public Person SearchPerson(int index)
        {
            IsIndexInArray(index);
            return ArrayOfPersons[index];
        }

        /// <summary>
        /// Метод находящий индекс персоны в массиве.
        /// </summary>
        /// <param name="person">Персона в массиве.</param>
        /// <returns>Индекс персоны вмассиве.
        /// При возврате -1 персоны не существует.</returns>
        public int SearchIndexOfPerson(Person person)
        {
            int index = -1;
            for (int i = 0; i < ArrayOfPersons.Length; i++)
            {
                if (ArrayOfPersons[i] == person)
                {
                    index = i;
                }
            }

            return index;
        }

        /// <summary>
        /// Метод позволяющий очитсить лист(в массиве).
        /// </summary>
        public void ClearList()
        {
            Array.Resize(ref ArrayOfPersons, 0);
        }

        /// <summary>
        /// Метод показывающий количество персон в массиве.
        /// </summary>
        /// <returns>Количество персон в массиве.</returns>
        public int NumberOfPersons() => ArrayOfPersons.Length;

    }
}
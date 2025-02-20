using System;

namespace Model
{
    /// <summary>
    /// Класс, который описывает список персон (в виде массива).
    /// </summary>
    public class PersonList
    {
        //TODO: RSDN+
        /// <summary>
        /// Массив персон.
        /// </summary>
        private Person[] _arrayOfPersons = new Person[0];

        /// <summary>
        /// Функция добавления персоны в конец массива.
        /// </summary>
        /// <param name="person">Персона была добавлена.</param>
        public void AddPerson(Person person)
        {
            var indexOfNewPerson = _arrayOfPersons.Length;
            Array.Resize(ref _arrayOfPersons, indexOfNewPerson + 1);
            _arrayOfPersons[indexOfNewPerson] = person;
        }

        /// <summary>
        /// Метод, проверяющий правильность входного индекса.
        /// </summary>
        /// <param name="index">Входной индекс.</param>
        /// <exception cref="IndexOutOfRangeException">Индекс выходит
        /// за рамки допустимых значений.</exception>
        private void IsIndexInArray(int index)
        {
            if (index < 0 || index >= _arrayOfPersons.Length)
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

            for (int i = index; i < _arrayOfPersons.Length - 1; i++)
            {
                _arrayOfPersons[i] = _arrayOfPersons[i + 1];
            }

            Array.Resize(ref _arrayOfPersons, _arrayOfPersons.Length - 1);
        }

        /// <summary>
        /// Метод удаляющий персону.
        /// </summary>
        /// <param name="person">Персона была удалена.</param>
        public void DeletePerson(Person person)
        {
            int index = Array.IndexOf(_arrayOfPersons, person);
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
            return _arrayOfPersons[index];
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
            for (int i = 0; i < _arrayOfPersons.Length; i++)
            {
                if (_arrayOfPersons[i] == person)
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
            Array.Resize(ref _arrayOfPersons, 0);
        }

        /// <summary>
        /// Метод показывающий количество персон в массиве.
        /// </summary>
        /// <returns>Количество персон в массиве.</returns>
        public int NumberOfPersons() => _arrayOfPersons.Length;

    }
}
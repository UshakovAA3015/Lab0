
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1
{
    internal class Program
    {
        static void Main(string[] args)
        {            //Сортировка массива чисел методом  "пуырька"
            int element = 10;
            int[] arr;
            arr = new int[element];
            Random r = new Random();
            for (int j = 0; j < element; j++)  // Цикл задания случайных переменны в  массив
            {
                arr[j] = r.Next(1, 200);
                Console.WriteLine(arr[j]);
            }
            int temp = 0;
            for (int write = 0; write < arr.Length; write++)
            {
                for (int sort = 0; sort < arr.Length - 1; sort++)
                {
                    if (arr[sort] > arr[sort + 1])
                    {
                        temp = arr[sort + 1];
                        arr[sort + 1] = arr[sort];
                        arr[sort] = temp;
                    }
                }
            }
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.ReadKey();
        }
    }
}

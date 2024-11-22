
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1
{
    internal class Program
    {
        static void Main()
        {
            // 9.9 Составить программу, которая число, заданное в десятичной системе счисления, переведет в: а) двоичную систему счисления; б) восьмеричную;   
            Console.WriteLine("Выберите в какую систему производить перевод:");
            Console.WriteLine("1 - Преревод в двоичную систему");
            Console.WriteLine("2 - Перевод в восмиричную систему");
            int a = Convert.ToInt32(Console.ReadLine());
            if (a == 1)
            {
                Two();
            }
            if (a == 2)
            {
                Eight();
            }
            Console.ReadLine();
        }
        static void Two() //Создание функции для первода значений из десятичной в двоичную систему
        {
            Console.WriteLine("Введите число в десятичной системе исчисления");
            int a = Convert.ToInt32(Console.ReadLine());
            int[] ch = new int[5];
            int b = 2;
            for (int i = 0; i < 5; i++)
            {
                ch[i] = ((int)(a % b));
                a = (int)(a / b);
            }
            Console.WriteLine($"Двоичное числло ");
            for (int j = ch.Length - 1; j >= 0; j--)
            {
                Console.Write(ch[j] + "");
            }

        }
        static void Eight() //Создание функции для первода значений из восмиричной в двоичную систему
        {
            Console.WriteLine("Введите число в десятичной cистеме исчисления");
            int a = Convert.ToInt32(Console.ReadLine());
            int[] ch = new int[5];
            int b = 8;
            for (int i = 0; i < 5; i++)
            {
                ch[i] = ((int)(a % b));
                a = (int)(a / b);
            }
            Console.WriteLine($"Число в восмиричной системе исчисления ");
            for (int j = ch.Length - 1; j >= 0; j--)
            {
                Console.Write(ch[j] + "");
            }
        }
    }
}

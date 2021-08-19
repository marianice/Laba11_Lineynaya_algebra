using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
 11.  Дана последовательность натуральных чисел {a0…an–1}. Создать
многопоточное приложение для вычисления выражения a0-а1+a2-а3+a4-а5+... 
*/
namespace ConsoleApp1
{
    class Program
    {
        static int sum = 0; // cумма чисел
        static int n = 9; // количество элементов последовательности
        static int a = 0; // хранит значение а[n]
        static int b = 2; // a+b=a[n+1] т.е. на какое число увеличивается или уменьшается последовательность
        static void Main(string[] args)
        {
            // создаем новый поток
            Thread myThread = new Thread(new ThreadStart(Count));
            myThread.Start(); // запускаем поток
            // создать новый поток в котором добавить условие

            for (int i = 0; i < n; i++)
            {
                if (i % 2 == 0) {
                    Console.WriteLine("Главный поток:");
                    Console.WriteLine(sum + a);
                    Thread.Sleep(300);
                }
                else
                {
                    Console.WriteLine("Главный поток:");
                    Console.WriteLine(sum - a);
                    Thread.Sleep(300);
                }
                a += b;
            }

            Console.ReadLine();
        }

        public static void Count()
        {
            for (int i = 0; i < n; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine("Второй поток:");
                    Console.WriteLine(sum + a);
                    Thread.Sleep(400); 
                }
                else {
                    Console.WriteLine("Второй поток:");
                    Console.WriteLine(sum - a);
                    Thread.Sleep(400);
                }
                a += b;
            }
        }
    }
}

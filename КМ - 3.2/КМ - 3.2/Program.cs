using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КМ___3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите число:");
                int n = int.Parse(Console.ReadLine());
                if (n < 0)
                {
                    Console.WriteLine("Введите неотрицательное число!");
                }
                else
                {
                    Console.WriteLine("Факториал введенного числа: ");
                    Cycle(n);
                    Console.WriteLine("Факториал введенного числа с помощью рекурсивной функции: ");
                    Console.WriteLine(Fact(n));
                }
            }
            catch(FormatException)
            {
                Console.WriteLine("Введите целое число!");
            }
            Console.ReadKey();

        }
        static void Cycle (int num)
        {
            if(num == 0)
                num = 1;
            else
            {
                for (int i = num - 1; i >= 1; i--)
                    num *= i;
            }
            Console.WriteLine(num);
        }
        static int Fact (int num)
        {
            if (num == 1 || num == 0)
                return 1;
            return num * Fact(num - 1);
        }
    }
}

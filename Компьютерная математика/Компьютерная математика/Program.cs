using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Компьютерная_математика
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = 0;
            int[] numbers = new int[length];
            Array.Resize(ref numbers,7);
            length = numbers.Length;
            for(int n=0; n<length; n++)
            {
                int el = n * n + 1;
                numbers[n] = el; 
            }
            System.Console.WriteLine("Размерность массива:  {0}", length);
            System.Console.WriteLine("Числовое множество X:");
            foreach (int element in numbers)
            {
                System.Console.WriteLine(element);
            }
            //System.Console.WriteLine("Мощность множества:" + Math.Pow(2,7));
            System.Console.WriteLine("Мощность множества:" + length);
            Console.Write("Собственные подмножества множества X:");
            Console.WriteLine();
            // 0<128(-1)-->00000001<128(10000000)
            for (int mask = 0; mask < (1 << length) - 1; mask++) 
            {
                //перебор индексов массива
                for (int j=0; j < length; j++)
                {    
                    if ((mask & (1 << j)) != 0)
                    {  
                       Console.Write(numbers[j]);
                       Console.Write(" ");
                    } 
                }
                Console.WriteLine();
            }
           // Console.Write(1 << 0);
            Console.ReadLine();
        }

    }
}

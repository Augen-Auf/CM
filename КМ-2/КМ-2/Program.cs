using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace КМ_2
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> character = new HashSet<int>();
            Console.Write("Мощность множества= ");
            int length = int.Parse(Console.ReadLine());
            int[] massive = new int[length];
            for (int i = 0; i < massive.Length; i++)
            { 
                Console.Write("Элемент множества[{0}]= ", i);
                massive[i] = int.Parse(Console.ReadLine());
                character.Add(massive[i]);
            }

            List<int> list = character.ToList();
            Console.WriteLine("Числовое множество X:");
            foreach (int element in list)
            {
               System.Console.WriteLine(element);
            }
            Console.Write("Собственные подмножества множества X:");
            Console.WriteLine();
            for (int mask = 0; mask < (1 << list.Count)-1; mask++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    if ((mask & (1 << j)) != 0)
                    {

                        Console.Write(list[j]);
                        Console.Write(" ");

                    }
                }

                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}

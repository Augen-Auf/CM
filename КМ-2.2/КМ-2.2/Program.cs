using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КМ_2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> nA = new HashSet<string>();
            HashSet<string> nB = new HashSet<string>();
            Console.Write("Декартово произведение множеств A и B: ");
            string[] strAB = Console.ReadLine().Split(new char[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            string[] A, B;
            for (int j = 0; j < strAB.Length; j++)
            {
                string[] smallAB = strAB[j].Split(new char[] { ' ', ',' });
                for (int i = 0; i < smallAB.Length-1; ++i)
                {
                    A = smallAB.Take(smallAB.Length / 2).ToArray();
                    nA.Add(A[i]);
                    B = smallAB.Skip(smallAB.Length / 2).ToArray();
                    nB.Add(B[i]);
                }
            }
            Console.WriteLine("Элементы множества А:");
            foreach (string el in nA)
            {
                Console.WriteLine(el);
            }
            Console.WriteLine("Элементы множества B:");
            foreach (string el in nB)
            {
                Console.WriteLine(el);
            }
            Console.ReadKey();
        }
    }
}

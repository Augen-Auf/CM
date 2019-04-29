using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КМ_2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> A = new HashSet<string>();
            Console.Write("Элементы множества A: ");
            string[] strA = Console.ReadLine().Split(new char[] { ' ', '\n', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int k = 0; k < strA.Length; k++)
            {
                A.Add(strA[k]);
            }
            Console.Write("Элементы множества A без дубликатов: ");
            foreach(string el in A)
            {
                Console.Write(el + " ");
            }
            Console.WriteLine();
            Console.Write("Элементы множества B: ");
            HashSet<string> B = new HashSet<string>();
            string[] strB = Console.ReadLine().Split(new char[] { ' ', '\n', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < strB.Length; i++)
            {
                B.Add(strB[i]);
            }
            Console.Write("Элементы множества B без дубликатов: ");
            foreach (string el in B)
            {
                Console.Write(el + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Декартово произведение множеств А и B:");
            for (int z = 0; z < A.Count; z++)
            {
                for (int j = 0; j < B.Count; j++)
                {
                    Console.Write("{" + A.ElementAt(z) + "," + B.ElementAt(j) + "}");
                }
            }
            Console.ReadKey();
        }
    }
    
}

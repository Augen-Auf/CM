using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КМ_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Заданное слово: ");
            string word = Console.ReadLine();
            HashSet<char> characters = new HashSet<char>();
            foreach(char el in word)
            {
                characters.Add(el);
            }
            foreach( char el in characters)
            {
                Console.WriteLine(el);
            }
            Console.ReadKey();
        }
        
    }
}

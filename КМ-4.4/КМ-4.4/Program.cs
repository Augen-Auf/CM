using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КМ_4._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int,string[]> graph = new Dictionary<int, string []>();
            Console.Write("Введите число вершин: ");
            string n = Console.ReadLine();
            int num = int.Parse(n);
            Console.WriteLine("Список смежности: ");
            for (int i = 1; i <= num; i++)
            {
                Console.Write("V {0}: ",i);
                graph[i] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
            bool[] used = new bool[1000];
            Console.Write("С какой вершины начать обход графа: ");
            string k = Console.ReadLine();
            int v = int.Parse(k);
            DFS(used, graph, v);
            
            Console.ReadKey();
        }
        static void DFS(bool[] used, Dictionary<int, string[]> graph,int v)
        {
            used[v] = true;
            Console.Write("V"+ v + " ");
            foreach(string el in graph[v])
            {
                int elem = int.Parse(el);
                if(!used[elem])
                {
                    DFS(used, graph, elem);
                }
            }
        }
    }
}

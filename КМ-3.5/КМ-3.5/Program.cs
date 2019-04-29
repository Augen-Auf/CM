using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КМ_3._5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Сколько чисел сортировать?");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите эти числа:");
            int[] massive = new int[n];
            string[] array = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (massive.Length < array.Length)
                Console.Write("Ошибка!Количество заданных чисел не соотвествует количеству введеных!");
            else
            {
                HashSet<int> forCheck = new HashSet<int>();//
                int[] newMassive = new int[0]; //
                for (int i = 0; i < massive.Length; i++)
                {
                    massive[i] = int.Parse(array[i]);
                    forCheck.Add(massive[i]);//
                }
                Array.Resize(ref newMassive, forCheck.Count);//
                for(int j = 0;j < forCheck.Count;j++)//
                    newMassive[j] = forCheck.ElementAt(j);//
                Console.WriteLine("Без повторяющихся чисел:");//
                foreach (int el in forCheck) //
                    Console.Write(el + " "); //
                Console.WriteLine();
                BubbleSort(newMassive); // or massive
                Console.WriteLine("После сортировки:");
                foreach (int el in newMassive) // or massive 
                {
                    Console.Write(el + " ");
                }
            }
            Console.ReadKey();
        }
        static int[] BubbleSort(int[] massive)
        {
            int t;
            for (int i = 0; i < massive.Length; i++)
            {
                for (int j = i + 1 ; j < massive.Length; j++)
                {
                    if (massive[i] > massive[j])//5 vs 3
                    {
                        t = massive[i];//5
                        massive[i] = massive[j];//3
                        massive[j] = t;//5
                    }
                }
            }
            return massive;
        }
        
    }
    
}

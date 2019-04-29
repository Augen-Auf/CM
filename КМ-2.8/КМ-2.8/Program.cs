using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КМ_2._8
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите множество X:");
            string[] mnojesX = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            HashSet<string> newMnojes = new HashSet<string>();
            Hash(mnojesX, newMnojes);
            Console.WriteLine("Множество X без дубликатов:");
            string[] X = new string[0];
            Array.Resize(ref X, newMnojes.Count);
            for (int i = 0; i < newMnojes.Count; i++)
            {
                Console.Write(newMnojes.ElementAt(i) + " ");
                X[i] = newMnojes.ElementAt(i);
            }
            Console.WriteLine();
            Console.WriteLine("Все возможные пары элементов множества Х:");
            string pairOfEl = "";
            HashSet<string> allPairs = new HashSet<string>();
            HashSet<string> forCheck = new HashSet<string>(); //для будущей проверки 
            for (int i = 0; i < newMnojes.Count; i++)
            {
                for (int j = 0; j < newMnojes.Count; j++)
                {
                    pairOfEl = mnojesX[i] + "," + mnojesX[j];
                    allPairs.Add(pairOfEl);
                    forCheck.Add(pairOfEl);
                }
            }
            foreach (string el in allPairs)
            {
                Console.Write(el + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Введите отношение R:");
            string[] R = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            HashSet<string> hashR = new HashSet<string>();
            Hash(R, hashR);
            Console.WriteLine("Отношение R без дубликатов:");
            for (int b = 0; b < hashR.Count; b++)
            {
                Console.Write(hashR.ElementAt(b) + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Отношение R, удовлетворяющее заданному множеству X: ");
            Intersect(forCheck, ref hashR);
            Console.WriteLine();
            HashSet<string> forMatrix = allPairs;
            bool[] matrix = new bool[forMatrix.Count];
            Array.Resize(ref R, forMatrix.Count);
            for (int z = 0; z < forMatrix.Count; z++)
            {
                if (R.Contains(forMatrix.ElementAt(z)))
                    matrix[z] = true;
                else
                    matrix[z] = false;
            }
            int index = 0;
            bool[,] matrixA = new bool[X.Length, X.Length];
            bool[,] matrixT = new bool[X.Length, X.Length];
            for (int i = 0; i < X.Length; i++)
            {
                for (int j = 0; j < X.Length; j++)
                {
                    matrixA[i, j] = matrix[index];
                    index++;
                    if (j % X.Length == 0 && j > 0)
                        i++;
                }
            }
            Console.WriteLine("Булевая матрица:");
            Write(ref matrixA, ref X);
            Console.WriteLine("Транзитивное замыкание в виде булевой матрицы:");
            for (int i = 0; i < X.Length; i++)
            {
                for (int j = 0; j < X.Length; j++)
                {
                    if (matrixA[i, j] == true)
                    {
                        matrixT[i, j] = true;
                    }
                    else
                        matrixT[i, j] = false;
                }
            }
            for (int i = 0; i < X.Length; i++)
            {
                for (int j = 0; j < X.Length; j++)
                {
                    for (int k = 0; k < X.Length; k++)
                    {
                        matrixT[i, j] = matrixT[i, j] || (matrixT[i, k] && matrixT[k, j]);
                    }
                }
            }
            Write(ref matrixT, ref X);
            Console.WriteLine("Транзитивное замыкание в виде множества пар элементов:");
            for (int i = 0; i < X.Length; i++)
                for (int j = 0; j < X.Length; j++)
                {
                    if (matrixT[i, j] == true)
                    {
                        string a = Convert.ToString(matrixT[i, j]);
                        a = X[i] + "," + X[j];
                        Console.Write(a + " ");
                    }
                }
            Console.ReadKey();
        }

        public static void Hash(string[] mnojes, HashSet<string> newMnojes)
        {
            for (int x = 0; x < mnojes.Length; x++)
            {
                newMnojes.Add(mnojes[x]);
            }
        }
        static void Write(ref bool[,] matrixA, ref string[] X)
        {
            for (int i = 0; i < X.Length; i++)
            {
                for (int j = 0; j < X.Length; j++)
                {
                    Console.Write((matrixA[i, j] ? 1 : 0) + " ");
                }
                Console.WriteLine();
            }
        }
        static void Intersect(HashSet<string> X, ref HashSet<string> R)
        {
            X.IntersectWith(R);
            foreach (string el in X)
            {
                Console.Write(el + " ");
            }
        }
    }
}

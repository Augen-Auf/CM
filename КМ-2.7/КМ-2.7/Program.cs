using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КМ_2._7
{
    class Program
    {
        static void Main(string[] args)
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
                    pairOfEl = "(" + mnojesX[i] + "," + mnojesX[j] + ")";
                    allPairs.Add(pairOfEl);
                    forCheck.Add(pairOfEl);
                }
            }
            foreach (string el in allPairs)
            {
                Console.Write(el + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Выберите форму ввода отношения R (1-множество пар элементов множества/2-булевая матрица):");
            int a = int.Parse((Console.ReadLine()));
            if (a == 1)
            {
                Console.WriteLine("Введите отношение R, заданное множеством пар элементов:");
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
                for (int i = 0; i < X.Length; i++)
                {
                    for (int j = 0; j < X.Length; j++)
                    {
                        matrixA[i, j] = matrix[index];
                        index++;
                        if (j > 0 & j % X.Length == 0)
                            i++;
                    }
                }
                Console.WriteLine("Булевая матрица:");
                Write(ref matrixA, ref X);
                Console.Write("Отношение R обладает свойством рефлексивности: ");
                Console.WriteLine(Reflex(X, matrixA) ? "да" : "нет");
                Console.Write("Отношение R обладает свойством антирефлексивности: ");
                Console.WriteLine(AntiReflex(X, matrixA) ? "да" : "нет");
                Console.Write("Отношение R обладает свойством симметричности: ");
                Console.WriteLine(Sym(X, matrixA) ? "да" : "нет");
                Console.Write("Отношение R обладает свойством антисимметричности: ");
                Console.WriteLine(AntiSym(X, matrixA) ? "да" : "нет");
                Console.Write("Отношение R обладает свойством транзитивности: ");
                Console.WriteLine(Transit(X, matrixA) ? "да" : "нет");
                Console.Write("Отношение R обладает свойством полноты: ");
                Console.WriteLine(Completeness(X, matrixA) ? "да" : "нет");
                if (Reflex(X, matrixA) & Sym(X, matrixA) & Transit(X, matrixA) == true)
                    Console.WriteLine("Отношение R обладает свойством эквивалентности: да");
                else
                    Console.WriteLine("Отношение R обладает свойством эквивалентности: нет");
                if (AntiSym(X, matrixA) & Transit(X, matrixA) & Completeness(X, matrixA) == true)
                    Console.WriteLine("Отношение R относится к классу полного порядка: да");
                else
                    Console.WriteLine("Отношение R относится к классу полного порядка: нет");
                if (AntiSym(X, matrixA) & Transit(X, matrixA) == true & Completeness(X, matrixA) == false)
                    Console.WriteLine("Отношение R относится к классу частичного порядка: да");
                else
                    Console.WriteLine("Отношение R относится к классу частичного порядка: нет");

            }
            else
            {
                Console.WriteLine("Введите отношение R в виде булевой матрицы:");
                bool[,] boolMatrix = new bool[X.Length, X.Length];
                string[] n = new string[X.Length];
                try
                {
                    for (int i = 0; i < n.Length; i++)
                    {
                        n[i] = Console.ReadLine();
                        string[] nc = n[i].Split(new char[] { ' ' });
                        int[] nn = new int[X.Length];
                        int count = 0;

                        foreach (string el in nc)
                        {
                            nn[count] = Convert.ToInt32(el);
                            count++;
                        }
                        for (int j = 0; j < X.Length; j++)
                        {
                            if (nn[j] > 1 || nn[j] < 0)
                            {
                                Console.WriteLine("Булевая матрица может состоять только из 0 и/или 1!");
                                break;
                            }
                            boolMatrix[i, j] = Convert.ToBoolean(nn[j]);
                        }
                    }
                    Console.Write("Отношение R обладает свойством рефлексивности: ");
                    Console.WriteLine(Reflex(X, boolMatrix) ? "да" : "нет");
                    Console.Write("Отношение R обладает свойством антирефлексивности: ");
                    Console.WriteLine(AntiReflex(X, boolMatrix) ? "да" : "нет");
                    Console.Write("Отношение R обладает свойством симметричности: ");
                    Console.WriteLine(Sym(X, boolMatrix) ? "да" : "нет");
                    Console.Write("Отношение R обладает свойством антисимметричности: ");
                    Console.WriteLine(AntiSym(X, boolMatrix) ? "да" : "нет");
                    Console.Write("Отношение R обладает свойством транзитивности: ");
                    Console.WriteLine(Transit(X, boolMatrix) ? "да" : "нет");
                    Console.Write("Отношение R обладает свойством полноты: ");
                    Console.WriteLine(Completeness(X, boolMatrix) ? "да" : "нет");
                    if (Reflex(X, boolMatrix) & Sym(X, boolMatrix) & Transit(X, boolMatrix) == true)
                        Console.WriteLine("Отношение R обладает свойством эквивалентности: да");
                    else
                        Console.WriteLine("Отношение R обладает свойством эквивалентности: нет");
                    if (AntiSym(X, boolMatrix) & Transit(X, boolMatrix) & Completeness(X, boolMatrix) == true)
                        Console.WriteLine("Отношение R относится к классу полного порядка: да");
                    else
                        Console.WriteLine("Отношение R относится к классу полного порядка: нет");
                    if (AntiSym(X, boolMatrix) & Transit(X, boolMatrix) == true & Completeness(X, boolMatrix) == false)
                        Console.WriteLine("Отношение R относится к классу частичного порядка: да");
                    else
                        Console.WriteLine("Отношение R относится к классу частичного порядка: нет");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Некорректный ввод!");
                }
            }
            Console.ReadKey();
        }
        static bool Reflex(string[] X, bool[,] matrix)
        {
            bool reflex = false;
            int amount = 0;
            for (int i = 0; i < X.Length; i++)
            {
                if (matrix[i, i] == true)
                {
                    amount++;
                    if (amount == X.Length)
                        reflex = true;
                    else
                        reflex = false;
                }
            }
            return reflex;
        }
        static bool AntiReflex(string[] X, bool[,] matrix)
        {
            bool antiReflex = false;
            int amount = 0;
            for (int i = 0; i < X.Length; i++)
            {
                if (matrix[i, i] == false)
                {
                    antiReflex = true;
                    amount++;
                }
                if (amount != X.Length)
                {
                    antiReflex = false;
                }
            }
            return antiReflex;
        }
        static bool Sym(string[] X, bool[,] matrix)
        {
            bool sym = false;
            int amount = 0;
            for (int i = 0; i < X.Length; i++)
            {
                for (int j = 0; j < X.Length; j++)
                {
                    if (matrix[i, j] == matrix[j, i])
                    {
                        sym = true;
                        if (amount != 0)
                            sym = false;
                    }
                    else
                    {
                        sym = false;
                        amount++;
                    }
                }
            }
            return sym;
        }
        static bool AntiSym(string[] X, bool[,] matrix)
        {
            bool antiSym = false;
            int amount = 0;
            for (int i = 0; i < X.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (matrix[i, j] != matrix[j, i])
                    {
                        antiSym = true;
                        if (amount != 0)
                            antiSym = false;
                    }
                    else
                    {
                        antiSym = false;
                        amount++;
                    }
                }
            }
            return antiSym;
        }
        static bool Transit(string[] X, bool[,] matrix)
        {
            bool transit = false;
            int amount1 = 0;
            int amount2 = 0;
            bool[,] r = new bool[X.Length, X.Length];
            for (int i = 0; i < X.Length; i++)
            {
                for (int j = 0; j < X.Length; j++)
                {
                    r[i, j] = matrix[i, j] && matrix[j, i];
                    if (r[i, j] == true)
                        amount1++;
                    if (matrix[i, j] == true)
                        amount2++;
                    if (amount1 == amount2)
                        transit = true;
                    else
                        transit = false;
                }
            }
            return transit;

        }
        static bool Completeness(string[] X, bool[,] matrix)
        {
            bool complete = false;
            int n = X.Length * X.Length;
            int amount = 0;
            for (int i = 0; i < X.Length; i++)
            {
                for (int j = 0; j < X.Length; j++)
                {
                    if (matrix[i, j] == true)
                    {
                        amount++;
                        if (amount == n)
                            complete = true;
                        else
                            complete = false;
                    }
                    else
                        complete = false;
                }
            }
            return complete;
        }

        public static void Hash(string[] mnojes, HashSet<string> U)
        {
            for (int x = 0; x < mnojes.Length; x++)
            {
                U.Add(mnojes[x]);
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

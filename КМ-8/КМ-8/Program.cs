using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КМ_8
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> U = new HashSet<string>();
            HashSet<string> A = new HashSet<string>();
            HashSet<string> B = new HashSet<string>();
            HashSet<string> C = new HashSet<string>();
            Console.Write("Введите количество множеств (2 или 3):");
            int s = int.Parse(Console.ReadLine());
            Console.Write("Элементы множества U: ");
            string[] strU = Console.ReadLine().Split(new char[] { ' ', '\n', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
            Console.Write("Элементы множества U без дубликатов: ");
            Hash(ref strU, U);
            foreach (string el in U)
            {
                Console.Write(el + " ");
            }
            Console.WriteLine();
            Console.Write("Элементы множества A: ");
            string[] strA = Console.ReadLine().Split(new char[] { ' ', '\n', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
            Console.Write("Элементы множества A, принадлежащие универсуму: ");
            Hash(ref strA, A);
            Intersect(U, ref A);
            Console.WriteLine();
            Console.Write("Элементы множества B: ");
            string[] strB = Console.ReadLine().Split(new char[] { ' ', '\n', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
            Console.Write("Элементы множества B, принадлежащие универсуму: ");
            Hash(ref strB, B);
            Intersect(U, ref B);
            Console.WriteLine();
            Array.Resize(ref strA, U.Count);
            Array.Resize(ref strB, U.Count);
            BitArray mybU = new BitArray(U.Count);
            BitArray mybA = new BitArray(strA.Length);
            BitArray mybB = new BitArray(strB.Length);
            mybU.SetAll(true);
            mybA.SetAll(false);
            mybB.SetAll(false);
            for (int i = 0; i < U.Count; i++)
            {
                if (strA.Contains(U.ElementAt(i)))
                    mybA[i] = true;
                else
                    mybA[i] = false;
            }
            for (int i = 0; i < U.Count; i++)
            {
                if (strB.Contains(U.ElementAt(i)))
                    mybB[i] = true;
                else
                    mybB[i] = false;
            }
            BitArray newbA = new BitArray(mybA);
            BitArray newbAA = new BitArray(mybA);
            BitArray newbAAa = new BitArray(mybA);
            BitArray newbBB = new BitArray(mybB);
            BitArray newbB = new BitArray(mybB);
            BitArray mybAa = new BitArray(mybA);
            BitArray forA = new BitArray(mybA);
            BitArray forA1 = new BitArray(mybA);
            BitArray forB = new BitArray(mybB);
            BitArray forB1 = new BitArray(mybB);
            Console.Write("Элементы множества А: ");
            WriteBy(newbAA,U);
            Console.WriteLine();
            Console.Write("Элементы множества B: ");
            WriteBy(mybB,U);
            Console.WriteLine();
            Console.Write("Пересечение множеств А и В: ");
            And(ref newbAA, ref newbBB,U);
            Console.Write("Объединение множеств А и В: ");
            Or(ref newbA, ref newbBB,U);
            Console.Write("Разность множеств А и В: ");
            Xor(ref newbA, ref newbBB, U);
            Console.Write("Разность множеств B и A: ");
            Xor(ref newbBB, ref newbAAa, U);
            Console.Write("Дополнение множества А до U: ");
            Not(ref mybAa,U);
            Console.Write("Дополнение множества B до U: ");
            Not(ref newbB,U);
            if (s == 3)
            {
                Console.Write("Элементы множества C: ");
                string[] strC = Console.ReadLine().Split(new char[] { ' ', '\n', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
                Console.Write("Элементы множества C, принадлежащие универсуму: ");
                Hash(ref strC, C);
                Intersect(U, ref C);
                Console.WriteLine();
                Array.Resize(ref strC, U.Count);
                BitArray mybC = new BitArray(strC.Length);
                mybC.SetAll(false);
                for (int i = 0; i < U.Count; i++)
                {
                    if (strC.Contains(U.ElementAt(i)))
                        mybC[i] = true;
                    else
                        mybC[i] = false;
                }
                BitArray newbCa = new BitArray(mybC);                                                                                                                   BitArray myB = new BitArray(mybB); BitArray myA = new BitArray(mybA);
                BitArray newbCca = new BitArray(mybC);                                                                                                                   
                BitArray mybCcc = new BitArray(mybC);
                BitArray newbCb = new BitArray(mybC);
                BitArray newbCccb = new BitArray(mybC);
                BitArray myAc = new BitArray(mybA);
                BitArray myBc = new BitArray(mybB);
                Console.Write("Элементы множества C: ");
                WriteBy(mybC,U);
                Console.WriteLine();
                Console.Write("Пересечение множеств C и A: ");
                And(ref newbCa, ref myAc,U);
                Console.Write("Пересечение множеств C и B: ");
                And(ref newbCb, ref myBc,U);
                Console.Write("Объединение множеств C и A: ");
                Or(ref newbCca, ref myA,U);
                Console.Write("Объединение множеств C и B: ");
                Or(ref newbCccb, ref myB,U);
                Console.Write("Разность множеств C и A: ");                                                                                            
                Xor(ref newbCca, ref mybA,U);
                Console.Write("Разность множеств C и B: ");
                Xor(ref newbCccb, ref mybB,U);
                Console.Write("Разность множеств A и C: ");
                BitArray newbCcc = new BitArray(mybC);
                Xor(ref mybA,ref newbCcc, U);
                Console.Write("Разность множеств B и C: ");
                Xor(ref mybB, ref newbCcc, U);
                Console.Write("Дополнение множества C до U: ");
                Not(ref mybCcc,U);
                BitArray forC = new BitArray(mybC);
                BitArray forC1 = new BitArray(mybC);
                Console.Write("Укажите номер задания(1,2 или 3):");
                int q = int.Parse(Console.ReadLine());
                if (q == 1)
                { SpecialOp1(ref forA, ref forA1, ref forB, ref forC,U); }
                else if (q == 2)
                { SpecialOp2(ref forB, ref forB1, ref forC, ref forC1,U); }
                else
                { SpecialOp3(ref forA, ref forA1, ref forC, ref forC1,U); }
            }
            Console.ReadKey();
        }
        static void And(ref BitArray X, ref BitArray Y,HashSet<string> U)
        {
            BitArray op = X.And(Y);
            for (int i = 0; i < U.Count; i++)
            {
                if (op[i] == true)
                    foreach (char el in U.ElementAt(i))
                    {
                        Console.Write(el + " ");
                    }
            }
                Console.WriteLine();
        }
        static void Or(ref BitArray X, ref BitArray Y, HashSet<string> U)
        {
                BitArray op = X.Or(Y);
                for (int i = 0; i < U.Count; i++)
                {
                if (op[i] == true)
                    foreach (char el in U.ElementAt(i))
                    {
                        Console.Write(el + " ");

                    }
                }        
                Console.WriteLine();
        }
        static void Xor(ref BitArray X, ref BitArray Y,HashSet<string> U)
        {
            BitArray op = X.Xor(Y);
            for (int i = 0; i < U.Count; i++)
            {
                if (Y[i] != op[i] )
                {
                    if (op[i] == true)
                    {
                        foreach (char el in U.ElementAt(i))
                        {
                            Console.Write(el + " ");
                        }
                    }
                }
                    
            }
                Console.WriteLine();
        }
        static void Not(ref BitArray X, HashSet<string> U)
        {
            BitArray op = X.Not();
            for (int i = 0; i < U.Count; i++)
            {
                if (op[i] == true)
                    foreach (char el in U.ElementAt(i))
                    {
                        Console.Write(el + " ");
                    }
            }
            Console.WriteLine();
        }
        static void Hash(ref String[] X, HashSet<string> Y)
        {
            for (int k = 0; k < X.Length; k++)
            {
                Y.Add(X[k]);
            }
        }
        static void Intersect(HashSet<string> H, ref HashSet<string> X)
        {
            X.IntersectWith(H);
            foreach (string el in X)
            {
                Console.Write(el + " ");
            }
        }
        static void SpecialOp1(ref BitArray forA, ref BitArray forA1, ref BitArray B, ref BitArray C,HashSet<string> U)
        {
            BitArray notA = forA.Not();
            BitArray unionAB = forA1.Or(B);
            BitArray unionNotAB = notA.Or(B);
            BitArray unionNotABC = unionNotAB.Or(C);                                                                                                                                                         //BitArray total = unionNotABC.Xor(unionAB);
            BitArray total = unionAB.Not();
            Console.Write("Задание №1:");
            for (int i = 0; i < U.Count; i++)
            {
                if (total[i] == true)
                    foreach (char el in U.ElementAt(i))
                    {
                        Console.Write(el + " ");
                    }
            }
            Console.WriteLine();

        }
        static void SpecialOp2(ref BitArray B, ref BitArray B1, ref BitArray C, ref BitArray C1,HashSet<string> U)
        {
            BitArray notB = B.Not();
            BitArray notC = C.Not();
            BitArray opNotBC = notB.And(C1);
            BitArray opNotNotBC = notB.And(notC);
            BitArray opBC = B1.And(C);
            BitArray opUnionNotBC = opNotNotBC.Or(opNotBC);
            BitArray opUnionNotAllBC = opUnionNotBC.Or(opBC);                                                                                                                                                   //BitArray total = opUnionNotAllBC.Not();
            Console.Write("Задание №2: ");
            for (int i = 0; i < U.Count; i++)
            {
                if (opUnionNotAllBC[i] == true)
                    foreach (char el in U.ElementAt(i))
                    {
                        Console.Write(el + " ");
                    }
            }
            Console.WriteLine();
        }
        static void SpecialOp3(ref BitArray A, ref BitArray A1, ref BitArray C, ref BitArray C1,HashSet<string> U)
        {
            BitArray opAC = A.And(C);
            BitArray notC = C.Not();
            BitArray opAnotC = A1.And(notC);
            BitArray notA = A1.Not();
            BitArray opNotAC = notA.And(C);
            BitArray opUnionAC = opAnotC.Or(opAC);
            BitArray opUnionallAC = opUnionAC.Or(opNotAC);
            BitArray total = opUnionAC.Not();
            Console.Write("Задание №3: ");
            for (int i = 0; i < U.Count; i++)
            {
                if (total[i] == true)
                    foreach (char el in U.ElementAt(i))
                    {
                        Console.Write(el + " ");
                    }
            }
            Console.WriteLine();

        }
        static void WriteBy(BitArray bools, HashSet<string> U)
        {
            for (int i = 0; i < U.Count; i++)
            {
                if (bools[i] == true)
                    foreach (char el in U.ElementAt(i))
                    {
                        Console.Write(el + " ");
                    }


            }
        }
    }
}   

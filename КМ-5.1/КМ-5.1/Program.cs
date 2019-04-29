using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КМ_5._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество множеств (2 или 3): ");
            int s = int.Parse(Console.ReadLine());
            HashSet<string> U = new HashSet<string>();
            Console.Write("Элементы множества U: ");
            string[] strU = Console.ReadLine().Split(new char[] {' ','\n', '\t', ',' },StringSplitOptions.RemoveEmptyEntries);
            for (int k = 0; k <strU.Length; k++)
            {
                U.Add(strU[k]);
            }
            Console.Write("Элементы множества A: ");
            HashSet<string> A = new HashSet<string>();
            string[] strA = Console.ReadLine().Split(new char[]{' ', '\n', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < strA.Length; i++)
                {
                    A.Add(strA[i]);
                    U.Add(strA[i]);
                }
            Console.Write("Элементы множества А без учета повторяющихся элементов: ");
            foreach (string el in A)
            {
                Console.Write(el + " ");
            }
            Console.WriteLine();
            HashSet<string> B = new HashSet<string>();
            Console.Write("Элементы множества B: ");
            string[] strB = Console.ReadLine().Split(new char[] {' ', '\n', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < strB.Length; j++)
            {
                B.Add(strB[j]);
                U.Add(strB[j]);
            }
            Console.Write("Элементы множества B без учета повторяющихся элементов: ");
            foreach (string el in B)
            {
                Console.Write(el + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Универcальное множество c учетом заданных множеств A и B: ");
            foreach (string el in U)
            {
                Console.Write(el + " ");
            }
            string[] arrayU = U.ToArray<string>();
            Console.WriteLine();
            if ( s == 3)
            {   Console.Write("Элементы множества C: ");
                HashSet<string> C = new HashSet<string>();
                string[] strC = Console.ReadLine().Split(new char[] { ' ', '\n', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < strC.Length; i++)
                {
                    C.Add(strC[i]);
                    U.Add(strC[i]);
                }
                Console.Write("Элементы множества C без учета повторяющихся элементов: ");
                foreach (string el in C)
                {
                    Console.Write(el + " ");
                }
                Console.WriteLine();
                Console.WriteLine("Универcальное множество c учетом заданных множеств A и B и C: ");
                foreach (string el in U)
                {
                    Console.Write(el + " ");
                }
                Console.WriteLine();
                string[] arrayUc = U.ToArray<string>();
                OperationUnion(ref strC, ref strA);
                OperationUnion(ref strC, ref strB);
                OperationIntersect(ref strC, ref strA);
                OperationIntersect(ref strC, ref strB);
                OperationExcept(ref strC, ref strA);
                OperationExcept(ref strC, ref strB);
                OperationAddition(ref arrayUc, ref strC);
                Console.WriteLine();
                Console.WriteLine("Ответ получен согласно веденным значениям и выбранному заданию");
                
                    SpecialOper1(ref arrayUc, ref strA, ref strB, ref strC);
                
                    SpecialOper2(ref arrayUc, ref strB, ref strC);
               
                    SpecialOper3(ref arrayUc, ref strA, ref strC);
                
            }
            Console.WriteLine();
            OperationUnion(ref strA, ref strB);
            OperationIntersect(ref strA, ref strB);
            OperationExcept(ref strA, ref strB);
            OperationAddition(ref arrayU, ref strA);
            OperationAddition2(ref arrayU, ref strB);
            Console.ReadKey();

        }
        static void OperationUnion(ref string[] A, ref string[] B)
        {
            IEnumerable<string> opUnion = A.Union(B);
            Console.Write("Операция объединения между заданными множествами: ");
            foreach (string el in opUnion)
            {
                Console.Write(el + " ");
            }
            Console.WriteLine();
        }
        static void OperationIntersect(ref string[] A, ref string[] B)
        {
            string[] opIntersect = A.Intersect(B).ToArray<string>();
            Console.Write("Операция пересечения между заданными множествами: ");
            foreach (string el in opIntersect)
            {
                Console.Write(el + " ");
            }
            Console.WriteLine();
        }
        static void OperationExcept(ref string[] A, ref string[] B)
        {
            string[] opExcept = A.Except<string>(B).ToArray<string>();
            Console.Write("Операция разности между первым заданным множеством и вторым заданным множеством: ");
            foreach (string el in opExcept)
            {
                Console.Write(el + " ");
            }
            Console.WriteLine();
        }
        static void OperationAddition(ref string[] array, ref string[] A)
        {
            string[] opAddition = array.Except<string>(A).ToArray<string>();
            Console.Write("Дополнение первого заданного множества до нового универсума: ");
            foreach (string el in opAddition)
            {
                Console.Write(el + " ");
            }
            Console.WriteLine();
        }
        static void OperationAddition2(ref string[] array, ref string[] B)
        {
            string[] opAddition = array.Except<string>(B).ToArray<string>();
            Console.Write("Дополнение второго заданного множества до нового универсума: ");
            foreach (string el in opAddition)
            {
                Console.Write(el + " ");
            }
            Console.WriteLine();
        }
        static void SpecialOper1(ref string[] array,ref string[] A, ref string[] B,ref string[] C)
        {
            string[] notA = array.Except<string>(A).ToArray<string>();
            IEnumerable<string> opUnionAB = A.Union(B);
            IEnumerable<string> opUnionnotAB = notA.Union(B);
            IEnumerable<string> opUnionnotABC = opUnionnotAB.Union(C);
            string[] last = opUnionnotABC.Except<string>(opUnionAB).ToArray<string>();
            Console.Write("Задание №1: ");
            foreach (string el in last)
            {
                Console.Write(el + " ");
            }
            Console.WriteLine();
        }
        static void SpecialOper2(ref string[] array, ref string[] B, ref string[] C)
        {
            string[] notB = array.Except<string>(B).ToArray<string>();
            string[] notC = array.Except<string>(C).ToArray<string>();
            string[] opnotBC = notB.Intersect(C).ToArray<string>();
            string[] opnotnotBC = notB.Intersect(notC).ToArray<string>();
            string[] opBC = B.Intersect(C).ToArray<string>();
            IEnumerable<string> opUnionnotBC= opnotBC.Union(opnotnotBC);
            IEnumerable<string> opUnionnotallBC = opUnionnotBC.Union(opBC);
            string[] last = array.Except<string>(opUnionnotallBC).ToArray<string>();
            Console.Write("Задание №2: ");
            foreach (string el in last)
            {
                Console.Write(el + " ");
            }
            Console.WriteLine();
        }
        static void SpecialOper3(ref string[] array, ref string[] A, ref string[] C)
        {
            
            string[] opAC = A.Intersect(C).ToArray<string>();
            string[] notC = array.Except<string>(C).ToArray<string>();
            string[] opAnotC = A.Intersect(notC).ToArray<string>();
            IEnumerable<string> opUnionAC = opAnotC.Union(opAC);
            string[] notA = array.Except<string>(A).ToArray<string>();
            string[] opnotAC = notA.Intersect(C).ToArray<string>();
            IEnumerable<string> opUnionnotAC = opUnionAC.Union(opnotAC);
            Console.Write("Задание №3: ");
            foreach (string el in opUnionnotAC)
            {
                Console.Write(el + " ");
            }
            Console.WriteLine();
        }

    }
}

using System;
using System.Collections.Generic;

namespace cs_challenges
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        private static void TestArrayAnalyzer()
        {
            int[] arrayEx = { 1, 2, 3, 4, 5 };
            int[] arrayEy = { 6, 7 };

            object result = ArrayAnalyzer.SortArray(arrayEx, arrayEy, ArrayAnalyzer.SortType.AscendingOrder);
            object result2 = ArrayAnalyzer.SortArray(arrayEx, arrayEy, ArrayAnalyzer.SortType.DescendingOrder);
            object result3 = ArrayAnalyzer.SortArray(arrayEx, arrayEy, ArrayAnalyzer.SortType.EvenFirst);
            object result4 = ArrayAnalyzer.SortArray(arrayEx, arrayEy, ArrayAnalyzer.SortType.OddsFirst);
            ShowResult(result3);
        }
        private static void TestDictionaryAnalyzer()
        {

        }
        private static void TestStringAnalyzer()
        {

        }
        private static void ShowResult(object res)
        {
            if (res is int[])
            {
                foreach (int item in (int[])res)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine(res);
            }
        }
    }
}

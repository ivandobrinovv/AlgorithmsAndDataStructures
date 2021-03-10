using Sort.Buisiness.Helpers;
using System;

namespace SortAlgorithmsExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] array = SortHelper.GetArrayWithRandomValues(n);
            SortHelper.PrintArray(array);

            SortHelper.HeapSort(array);

            SortHelper.PrintArray(array);
        }
    }
}

using Sort.Buisiness.Helpers;
using System;

namespace SortAlgorithmsExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get input for the number of the elements in the array
            Console.WriteLine("Numbers of elements in the array:");
            int n = int.Parse(Console.ReadLine());

            // Create an array with random values with n elements
            int[] array = SortHelper.GetArrayWithRandomValues(n);

            // Print the array
            SortHelper.PrintArray(array);

            // Sort the array (a different sorting algorithm from the SortHelper can be used)
            SortHelper.MergeSortArray(array);

            // Print the sorted array
            SortHelper.PrintArray(array);
        }
    }
}

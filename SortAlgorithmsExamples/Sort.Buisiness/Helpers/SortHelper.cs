using System;

namespace Sort.Buisiness.Helpers
{
    public static class SortHelper
    {
        public static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public static void PrintArray(int[] array)
        {
            foreach (int a in array)
            {
                Console.Write($"{a} ");
            }

            Console.WriteLine();
        }

        public static int[] GetArrayWithRandomValues(int n)
        {
            int[] array = new int[n];

            Random random = new Random();

            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(0, 100);
            }

            return array;
        }

        public static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int min = i;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[min] > array[j])
                    {
                        min = j;
                    }
                }

                Swap(ref array[i], ref array[min]);
                PrintArray(array);
            }
        }

        public static void Sift(int l, int r, int[] b)
        {
            int i = l;
            int j = i + i;
            int x = b[i];

            while (j <= r)
            {
                if (j < r && b[j] < b[j + 1])
                    j++;
                if (x >= b[j]) break;
                b[i] = b[j];
                i = j;
                j *= 2;
            }
            b[i] = x;

        }

        #region SortAlorithms

        public static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int j = i;
                int temp = array[j];
                while (j > 0 && array[j - 1] >= temp)
                {
                    array[j] = array[j - 1];
                    j--;
                }
                array[j] = temp;
                PrintArray(array);
            }
        }

        public static void BubbleSort(int[] array)
        {
            bool check;
            for (int i = 0; i < array.Length - 1; i++)
            {
                check = false;
                for (int j = array.Length - 1; j > i; j--)
                {
                    if (array[j] < array[j - 1])
                    {
                        Swap(ref array[j], ref array[j - 1]);
                        check = true;
                    }
                }
                PrintArray(array);

                if (!check) break;
            }

        }

        public static void ShakerSort(int[] array)
        {
            int left = 0;
            int right = array.Length - 1;
            int k = 0;
            int i;

            while(right - left > 0)
            {
                for(i = right; i > left; i--)
                {
                    if(array[i] < array[i - 1])
                    {
                        Swap(ref array[i - 1], ref array[i]);
                        k = i;
                    }
                }

                left = k;

                for (i = left; i < right; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        Swap(ref array[i], ref array[i + 1]);
                        k = i;
                    }
                }

                right = k;
            }

        }

        public static void QuickSort(int[] array, int left, int right)
        {
            int i = left, j = right;
            int m = array[(left + right) / 2];
            /* partition */
            while (i <= j)
            {//докато i и j се разминат 
                while (array[i] < m) i++;
                while (array[j] > m) j--;
                if (i <= j)
                {
                    Swap(ref array[i], ref array[j]);
                    i++;
                    j--;
                }
            };
            /* recursion */
            if (left < j) QuickSort(array, left, j);
            if (i < right) QuickSort(array, i, right);
        }


        public static void HeapSort(int[] array)
        {
            int k;
            for (k = array.Length / 2; k > 0; k--)
            {
                Sift(k - 1, array.Length - 1, array);
            }

            for (k = array.Length - 1; k > 0; k--)
            {
                Swap(ref array[0], ref array[k]);
                Sift(0, k - 1, array);
            }
        }

        #endregion
    }
}

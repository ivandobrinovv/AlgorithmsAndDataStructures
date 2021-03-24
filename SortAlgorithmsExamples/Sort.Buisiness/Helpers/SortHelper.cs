using System;

namespace Sort.Buisiness.Helpers
{
    public static class SortHelper
    {
        /// <summary>
        /// Swaps the values of two intager variables
        /// </summary>
        /// <param name="a">First variable</param>
        /// <param name="b">Second variable</param>
        private static void Swap(ref int a, ref int b)
        {
            // Use a temporary variable to swap the values
            int temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Prints the values of an array in the console
        /// </summary>
        /// <param name="array">The array that will be printed</param>
        public static void PrintArray(int[] array)
        {
            foreach (int item in array)
            {
                Console.Write($"{item} ");
            }
            // Move the cursor in the console to a new line
            Console.WriteLine();
        }

        /// <summary>
        /// Creates an array with random values between 0 and 100 and certain number of elements
        /// </summary>
        /// <param name="n">The number of elements in the array</param>
        /// <returns>An array with n random elements</returns>
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

        /// <summary>
        /// Places the item at startIndex's value at the position it should be on a pyramid formed
        /// by the subarray of array between startIndex and endIndex
        /// </summary>
        /// <param name="startIndex">The index of the array from which the sift should start</param>
        /// <param name="endIndex">The index of the array to which the sift should be done</param>
        /// <param name="array">The array which should be sifted</param>
        private static void Sift(int startIndex, int endIndex, int[] array)
        {
            int parentIndex = startIndex;
            int childIndex = parentIndex * 2 + 1;
            int itemValue = array[parentIndex];

            while (childIndex <= endIndex)
            {
                // Take the index of the child with bigger value
                if (childIndex < endIndex && array[childIndex] < array[childIndex + 1])
                    childIndex++;

                // Check if the value of the the start item is bigger than both children's
                // values (if this is the correct place for it) and if it is break
                if (itemValue >= array[childIndex]) break;
                
                // Set the value of the bigger child as parent value
                array[parentIndex] = array[childIndex];

                // Take the index of the bigger child as a parent index
                parentIndex = childIndex;

                // Take the index of the first child of the new parent index
                childIndex *= 2;
                childIndex++;
            }

            // Set the value of the start item on the correct place (as found from the logic above)
            array[parentIndex] = itemValue;
        }

        /// <summary>
        /// Joins two sorted subarrays
        /// </summary>
        /// <param name="array">The array from which the two subarrays are part of</param>
        /// <param name="leftBorderIndex">The left border of the left array</param>
        /// <param name="middleIndex">The right border of the left array</param>
        /// <param name="rightBorderIndex">The right border of the right array</param>
        private static void Merge(int[] array, int leftBorderIndex, int middleIndex, int rightBorderIndex)
        {
            rightBorderIndex++;
            middleIndex++;
            int leftSubarrayRightBorder = middleIndex;
            int rightSubarrayIndex = middleIndex;
            int leftSubarrayIndex = leftBorderIndex;

            // The length of the array formed by merging the two subarrays
            int arrayLength = rightBorderIndex - leftBorderIndex;
            int[] helperArray = new int[arrayLength];
            int i = 0;

            // Stop when all of the elements from one of the subarrays are used
            while (i < arrayLength && leftBorderIndex != leftSubarrayRightBorder && rightSubarrayIndex != rightBorderIndex)
            {
                if (array[leftBorderIndex] < array[rightSubarrayIndex])
                {
                    helperArray[i] = array[leftBorderIndex++];
                }
                else
                {
                    helperArray[i] = array[rightSubarrayIndex++];
                }
                i++;
            }

            // Set the elements left from the right subarray at the end of the
            // helperArray if there are any
            if (leftBorderIndex == leftSubarrayRightBorder)
            {
                while (i < arrayLength)
                {
                    helperArray[i++] = array[rightSubarrayIndex++];
                }
            }

            // Set the elements left from the left subarray at the end of the
            // helperArray if there are any
            if (rightSubarrayIndex == rightBorderIndex)
            {
                while (i < arrayLength)
                {
                    helperArray[i++] = array[leftBorderIndex++];
                }
            }

            // Set the sorted subarray's values as values in the original array
            for (i = 0; i < arrayLength; i++)
                array[leftSubarrayIndex++] = helperArray[i];

        }

        /// <summary>
        /// Sorts a subarray by using the merge sort algorithm
        /// </summary>
        /// <param name="array">The array from which is the subarray that should be sorted</param>
        /// <param name="leftBorderIndex">The index of the left border of the subarray</param>
        /// <param name="rightBorderIndex">The index of the right border of the subarray</param>
        public static void MergeSortSubarray(int[] array, int leftBorderIndex, int rightBorderIndex)
        {
            if (leftBorderIndex < rightBorderIndex)// Check if there is anything to be sorted
            {
                int middleElementIndex = (rightBorderIndex + leftBorderIndex) / 2;
                MergeSortSubarray(array, leftBorderIndex, middleElementIndex); // Sort the left subarray
                MergeSortSubarray(array, middleElementIndex + 1, rightBorderIndex); // Sort the right subarray
                Merge(array, leftBorderIndex, middleElementIndex, rightBorderIndex); // Merge the two sorted subarrays
            }
        }

        #region SortAlorithms

        /// <summary>
        /// Sorts an array by using the insertion sort algorithm
        /// </summary>
        /// <param name="array">The array that should be sorted</param>
        public static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int j = i;
                int temp = array[j];

                // Move the elements on left from the current elements until an element
                // with smaller value is found
                while (j > 0 && array[j - 1] >= temp)
                {
                    array[j] = array[j - 1];
                    j--;
                }

                // Insert the element on the correct place from the elements in it's left
                array[j] = temp;
            }
        }

        /// <summary>
        /// Sorts an array by using the bubble sort algorithm
        /// </summary>
        /// <param name="array">The array that should be sorted</param>
        public static void BubbleSort(int[] array)
        {
            bool check = false;
            for (int i = 0; i < array.Length - 1; i++)
            {
                // Check if there are any two elements near each other which are not
                // in the correct order and swap each found pear from right to left
                for (int j = array.Length - 1; j > i; j--)
                {
                    if (array[j] < array[j - 1])
                    {
                        Swap(ref array[j], ref array[j - 1]);
                        check = true;
                    }
                }

                // Check if there were any changes made for the last item. If there
                // weren't any this means that the array is already sorted
                if (!check) break;
            }
        }

        /// <summary>
        /// Sorts an array by using the shaker sort algorithm
        /// </summary>
        /// <param name="array">The array that should be sorted</param>
        public static void ShakerSort(int[] array)
        {
            // The last sorted element from left to right's index
            int leftSortedBorder = 0;

            // The last sorted element from right to left's index
            int rightSortedBorder = array.Length - 1;
            int lastIndexOfChange = 0;

            while(rightSortedBorder - leftSortedBorder > 0)
            {
                // Check if there are any two elements near each other which are not
                // in the correct order and swap each found pear
                // from right to left
                for (int i = rightSortedBorder; i > leftSortedBorder; i--)
                {
                    if(array[i] < array[i - 1])
                    {
                        Swap(ref array[i - 1], ref array[i]);
                        lastIndexOfChange = i;
                    }
                }

                leftSortedBorder = lastIndexOfChange;

                // Check if there are any two elements near each other which are not
                // in the correct order and swap each found pear
                // from left to right
                for (int i = leftSortedBorder; i < rightSortedBorder; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        Swap(ref array[i], ref array[i + 1]);
                        lastIndexOfChange = i;
                    }
                }

                rightSortedBorder = lastIndexOfChange;
            }

        }

        /// <summary>
        /// Sorts an array by using the quick sort algorithm
        /// </summary>
        /// <param name="array">The array that should be sorted</param>
        /// <param name="leftBorder">The left border of the subarray that is being sorted</param>
        /// <param name="rightBorder">The right border of the subarray that is being sorted</param>
        public static void QuickSort(int[] array, int leftBorder, int rightBorder)
        {
            int i = leftBorder, j = rightBorder;
            int middleElementValue = array[(leftBorder + rightBorder) / 2];

            while (i <= j)
            {
                // Find an element smaller than the middle element value on the left
                while (array[i] < middleElementValue) i++;
                // Find an element bigger than the middle element value on the right
                while (array[j] > middleElementValue) j--;
                if (i <= j)
                {
                    // Swap the two elements
                    Swap(ref array[i], ref array[j]);
                    i++;
                    j--;
                }
            };

            if (leftBorder < j) QuickSort(array, leftBorder, j); // Call quick sort for the left subarray
            if (i < rightBorder) QuickSort(array, i, rightBorder); // Call quick sort for the right subarray
        }

        /// <summary>
        /// Sorts an array by using the selection sort algorithm
        /// </summary>
        /// <param name="array">The array that should be sorted</param>
        public static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int minValueIndex = i;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[minValueIndex] > array[j])
                    {
                        minValueIndex = j;
                    }
                }

                Swap(ref array[i], ref array[minValueIndex]);
            }
        }

        /// <summary>
        /// Sorts an array by using the heap sort algorithm
        /// </summary>
        /// <param name="array">The array that should be sorted</param>
        public static void HeapSort(int[] array)
        {
            // Call the Sift method for each parent element starting from the last one
            // to form a pyramid
            for (int i = array.Length / 2; i > 0; i--)
            {
                Sift(i - 1, array.Length - 1, array);
            }

            // Create a sorted array from the pyramid by taking the biggest element from the
            // non-sorted part (index 0 because it is a pyramid) and placing it at the end
            // of the non sorted part. Then call the Sift method for the non-sorted part to
            // set the biggest element at index 0 (create a pyramid) and repeat for the whole array.
            for (int i = array.Length - 1; i > 0; i--)
            {
                Swap(ref array[0], ref array[i]);
                Sift(0, i - 1, array);
            }
        }

        /// <summary>
        /// Sorts an array by using the merge sort algorithm
        /// </summary>
        /// <param name="array">The array that should be sorted</param>
        public static void MergeSortArray(int[] array)
        {
            MergeSortSubarray(array, 0, array.Length - 1);
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using static InsertionSortNS.InsertionSorter;

namespace InsertionSortNS
{
    internal class InsertionSorterMain
    {
        static void Main(string[] args)
        {
            // int[] testArray = { 11, 4, 6, 2, 1, 12, 2, 1 };
            // int[] testArray = { 4, 6, 11, 2, 1, 12, 2, 1 };
            int[] testArray = { 4, 6, 11, 8, 1, 12, 2, 1 };
            // int[] testArray = { 8, 7, 6, 5, 4, 3, 2, 1 };
            // int[] testArray = { 8, 1, 2, 3, 4, 5, 6, 7 };

            Debug.WriteLine("\nOriginal array:");

            for (int i = 0; i < testArray.Length; i++)
            {
                Debug.Write(testArray[i] + " ");
            }

            InsertionSort(testArray);

            Debug.WriteLine("\n*************************");

            Debug.WriteLine("\nSorted array:");
            for (int i = 0; i < testArray.Length; i++)
            {
                Debug.Write(testArray[i] + " ");
            };
        }
    }
}

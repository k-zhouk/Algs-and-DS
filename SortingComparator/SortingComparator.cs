using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using static BubbleSortNS.BubbleSorter;
using static SelectionSortNS.SelectionSorter;
using static InsertionSortNS.InsertionSorter;

namespace SortingComparator
{
    internal class SortingComparator
    {
        static void Main(string[] args)
        {
            string fileName = "randome_numbers.txt";
            bool setupArraysForSorting = true;

            if (setupArraysForSorting)
            {
                GenerateRandomeNumbersToFile(ushort.MaxValue, fileName);
            }

            // Reading the file with previously generated random numbers
            int[] randomNumbers = ReadRandomeNumbersFromFile(fileName);

            // Creating same arrays for every type of sorting
            int[] arrayForBubbleSort = new int[randomNumbers.Length];
            Array.Copy(randomNumbers, arrayForBubbleSort, randomNumbers.Length);

            int[] arrayForBubbleSort2 = new int[randomNumbers.Length];
            Array.Copy(randomNumbers, arrayForBubbleSort2, randomNumbers.Length);

            int[] arrayForInsertionSort = new int[randomNumbers.Length]; ;
            Array.Copy(randomNumbers, arrayForInsertionSort, randomNumbers.Length);

            int[] arrayForSelectionSort = new int[randomNumbers.Length];
            Array.Copy(randomNumbers, arrayForSelectionSort, randomNumbers.Length);

            int[] arrayForArraySort = new int[randomNumbers.Length];
            Array.Copy(randomNumbers, arrayForArraySort, randomNumbers.Length);

            Stopwatch sw = new Stopwatch();

            Debug.WriteLine($"\nTEST I: Starting Bubble Sort for {arrayForBubbleSort.Length} elements...");
            sw.Start();
            BubbleSort(arrayForBubbleSort);
            sw.Stop();
            Debug.WriteLine($"Bubble Sort is finished...");
            Debug.WriteLine($"Elapsed time: {sw.Elapsed}\n");
            sw.Reset();

            Debug.WriteLine($"TEST II: Starting Bubble Sort 2 for  {arrayForBubbleSort2.Length}  elements.....");
            sw.Start();
            BubbleSort2(arrayForBubbleSort2);
            sw.Stop();
            Debug.WriteLine($"Bubble Sort 2 is finished...");
            Debug.WriteLine($"Elapsed time: {sw.Elapsed}\n");
            sw.Reset();

            Debug.WriteLine($"TEST III: Starting Selection Sort for {arrayForSelectionSort.Length} elements...");
            sw.Start();
            SelectionSort(arrayForSelectionSort);
            sw.Stop();
            Debug.WriteLine($"Selection Sort is finished...");
            Debug.WriteLine($"Elapsed time: {sw.Elapsed}\n");
            sw.Reset();

            Debug.WriteLine($"TEST IV: Starting Insertion Sort for {arrayForInsertionSort.Length} elements...");
            sw.Start();
            InsertionSort(arrayForInsertionSort);
            sw.Stop();
            Debug.WriteLine($"Insertion Sort is finished...");
            Debug.WriteLine($"Elapsed time: {sw.Elapsed}\n");
            sw.Reset();

            Debug.WriteLine($"TEST V: Starting Array.Sort() Sort for {arrayForArraySort.Length} elements...");
            sw.Start();
            Array.Sort(arrayForArraySort);
            sw.Stop();
            Debug.WriteLine($"Array.Sort() Sort is finished...");
            Debug.WriteLine($"Elapsed time: {sw.Elapsed}\n");
            sw.Reset();

            // Checking that all selection have the same min and max numbers
            Debug.WriteLine($"Minimum numbers:");
            Debug.WriteLine($"{"Bubble sort:",-25}{arrayForBubbleSort[0]}");
            Debug.WriteLine($"{"Bubble sort 2: ",-25}{arrayForBubbleSort2[0]}");
            Debug.WriteLine($"{"Selection sort: ",-25}{arrayForSelectionSort[0]}");
            Debug.WriteLine($"{"Insertion sort: ",-25}{arrayForInsertionSort[0]}");
            Debug.WriteLine($"{"Array.Sort() sort: ",-25}{arrayForArraySort[0]}");

            Debug.WriteLine($"*************************");

            Debug.WriteLine($"Maximum numbers:");
            Debug.WriteLine($"{"Bubble sort: ",-25}{arrayForBubbleSort[randomNumbers.Length - 1]}");
            Debug.WriteLine($"{"Bubble sort 2: ",-25}{arrayForBubbleSort2[randomNumbers.Length - 1]}");
            Debug.WriteLine($"{"Selection sort: ",-25}{arrayForSelectionSort[randomNumbers.Length - 1]}");
            Debug.WriteLine($"{"Insertion sort: ",-25}{arrayForInsertionSort[randomNumbers.Length - 1]}");
            Debug.WriteLine($"{"Array.Sort(): ",-25}{arrayForArraySort[randomNumbers.Length - 1]}");
        }

        // Function generates a text file with randome numbers
        public static void GenerateRandomeNumbersToFile(int qty, string fileName)
        {
            Random rnd = new Random();
            Stopwatch stopWatch = new Stopwatch();

            Console.WriteLine($"\nGenerating a file with {qty} random numbers...");

            stopWatch.Start();
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                for (int i = 0; i < qty; i++)
                {
                    sw.WriteLine(rnd.Next());
                }
            }
            stopWatch.Stop();

            Console.WriteLine($"Generation is done in {stopWatch.Elapsed} time span");
        }

        public static int[] ReadRandomeNumbersFromFile(string fileName)
        {
            List<int> numbers = new List<int>();

            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    numbers.Add(int.Parse(line));
                }
            }

            return numbers.ToArray();
        }
    }
}

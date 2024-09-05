using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using static BubbleSortNS.BubbleSorter;
using static InsertionSortNS.InsertionSorter;
using static SelectionSortNS.SelectionSorter;

namespace SortingComparator
{
    internal class SortingComparator
    {
        static void Main(string[] args)
        {
            string fileName= "randome_numbers.txt";
            bool setupArraysForSorting = false;

            if (setupArraysForSorting)
            {
                GenerateRandomeNumbersToFile(ushort.MaxValue, fileName);
            }

            // Reading the file with previously generated random numbers
            int[] randomNumbers = ReadRandomeNumbersFromFile(fileName);
            
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

            Stopwatch sw= new Stopwatch();

            Debug.WriteLine($"\nTEST I: Starting Bubble Sorting for {arrayForBubbleSort.Length} elements...");
            sw.Start();
            BubbleSort(arrayForBubbleSort);
            sw.Stop();
            Debug.WriteLine("Bubble Sorting is finished...");
            Debug.WriteLine("Elapsed time: " + sw.Elapsed + "\n");
            sw.Reset();

            Debug.WriteLine($"TEST I: Starting Bubble Sorting for  {arrayForBubbleSort2.Length}  elements.....");
            sw.Start();
            BubbleSort2(arrayForBubbleSort2);
            sw.Stop();
            Debug.WriteLine("Bubble Sorting 2 is finished...");
            Debug.WriteLine("Elapsed time: " + sw.Elapsed + "\n");
            sw.Reset();

            /*
            Debug.WriteLine($"TEST III: Starting Insertion Sorting for {arrayForInsertionSort.Length} elements...");
            sw.Start();
            InsertionSort(arrayForInsertionSort);
            sw.Stop();
            Debug.WriteLine("Insertion Sorting is finished...");
            Debug.WriteLine("Elapsed time: " + sw.Elapsed + "\n");
            sw.Reset();

            Debug.WriteLine($"TEST IV: Starting Selection Sorting for {arrayForSelectionSort.Length} elements...");
            sw.Start();
            SelectionSort(arrayForSelectionSort);
            sw.Stop();
            Debug.WriteLine("Selection Sorting is finished...");
            Debug.WriteLine("Elapsed time: " + sw.Elapsed + "\n");
            sw.Reset();
            */

            Debug.WriteLine($"TEST V: Starting Array.Sort() Sorting for {arrayForArraySort.Length} elements...");
            sw.Start();
            Array.Sort(arrayForArraySort);
            sw.Stop();
            Debug.WriteLine("Array.Sort() Sorting is finished...");
            Debug.WriteLine("Elapsed time: " + sw.Elapsed + "\n");
            sw.Reset();
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

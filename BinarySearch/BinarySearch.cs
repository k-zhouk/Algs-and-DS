using System;
using System.Diagnostics;
using System.Reflection;

namespace BinarySearchNS
{
    internal class BinarySearchMain
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            // int[] testArray = new int[ushort.MaxValue + 1];
            int[] testArray = new int[11];

            // Fill in an array wit randome int numbers
            for (int i = 0; i < testArray.Length; i++)
            {
                // testArray[i] = rnd.Next(ushort.MaxValue);
                testArray[i] = i + 1;
            }

            // Sort an array
            Array.Sort(testArray);

            // Generate a test value
            // int testValue = rnd.Next((int)(ushort.MaxValue * 1.5));

            int testValue = 5;

            SearchResult srTest = new SearchResult();
            srTest = BinarySearch(testArray, testValue);

            if (srTest.Index != -1)
            {
                Debug.WriteLine($"The test value {testValue} has been found at index: {srTest.Index}");
                Debug.WriteLine($"Number of iterations: {srTest.Iterations}");
            }
            else
            {
                Debug.WriteLine($"The test value {testValue} in not in the array");
                Debug.WriteLine($"Number of iterations: {srTest.Iterations}");
            }
        }

        static SearchResult BinarySearch(int[] array, int value)
        {
            SearchResult sr = new SearchResult();

            int _iterationCounter = 0;

            int leftIndex = 0;
            int rightIndex = array.Length;
            int middle = (rightIndex + leftIndex) / 2;

            while (leftIndex != rightIndex)
            {
                if (array[middle] == value)
                {
                    sr.Index = middle;
                    sr.Iterations = _iterationCounter;
                    return sr;
                }

                if (value > array[middle])
                {
                    leftIndex = middle;
                }
                else
                {
                    rightIndex = middle;
                }
                middle = (rightIndex + leftIndex) / 2;
                _iterationCounter++;
            }

            sr.Index = -1;
            sr.Iterations = _iterationCounter;
            return sr;
        }
    }

    struct SearchResult
    {
        public int Index { get; set; }
        public int Iterations { get; set; }
    }
}

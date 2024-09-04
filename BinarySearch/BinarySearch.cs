using System;
using static BinarySearchNS.BinarySearcher;

namespace BinarySearchNS
{
    public class BinarySearchMain
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            int[] testArray = new int[ushort.MaxValue + 1];

            // Fill in an array wit randome int numbers
            for (int i = 0; i < testArray.Length; i++)
            {
                testArray[i] = rnd.Next(ushort.MaxValue);
            }

            // Sort an array
            Array.Sort(testArray);

            // Generate a test value
            int testValue = rnd.Next((int)(ushort.MaxValue * 1.5));

            SearchResult srTest = new SearchResult();
            srTest = BinarySearch(testArray, testValue);

            if (srTest.Index != -1)
            {
                Console.WriteLine($"The test value {testValue} has been found at index: {srTest.Index}");
                Console.WriteLine($"Number of iterations: {srTest.Iterations}");
            }
            else
            {
                Console.WriteLine($"The test value {testValue} in not in the array");
                Console.WriteLine($"Number of iterations: {srTest.Iterations}");
            }
        }
    }
}

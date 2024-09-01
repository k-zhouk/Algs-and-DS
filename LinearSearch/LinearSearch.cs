using System;
using System.Diagnostics;

namespace LinearSearch
{
    internal class LinearSearchMain
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

            int index = LinearSearch(testArray, testValue);

            if (index != -1)
            {
                Debug.WriteLine($"The test value {testValue} has been found at index: {index}");
            }
            else
            {
                Debug.WriteLine($"The test value {testValue} in not in the array");
            }
        }

        static int LinearSearch(int[] array, int value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                {
                    return i;
                }
            }
            // The value has not been found
            return -1;
        }
    }
}

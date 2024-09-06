namespace SelectionSortNS
{
    public class SelectionSorter
    {
        public static void SelectionSort(int[] inputArray)
        {
            int minIndex = 0;
            int tmp;

            // Main cycle
            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                // Cycle to search for a minimum number in the subarray
                for (int j = i; j < inputArray.Length; j++)
                {
                    if (inputArray[j] < inputArray[minIndex])
                    {
                        minIndex = j;
                    }
                }

                // Exchanging the 1st element of the subarray with the minimum element
                tmp = inputArray[i];
                inputArray[i] = inputArray[minIndex];
                inputArray[minIndex] = tmp;

                // New minimum index becomes an index of the 0th element in the subarray
                minIndex = i + 1;
            }
        }
    }
}

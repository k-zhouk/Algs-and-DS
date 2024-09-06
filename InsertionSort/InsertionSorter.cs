namespace InsertionSortNS
{
    public class InsertionSorter
    {
        /// <summary>
        /// Insertion sort
        /// </summary>
        /// <param name="inputArray"></param>
        public static void InsertionSort(int[] inputArray)
        {
            int tmp;
            int j;

            for (int i = 1; i < inputArray.Length; i++)
            {
                if (inputArray[i] < inputArray[i - 1])
                {
                    tmp = inputArray[i];

                    j = i;
                    while ((j > 0) && (tmp < inputArray[j - 1]))
                    {
                        inputArray[j] = inputArray[j - 1];
                        j--;
                    }
                    inputArray[j] = tmp;
                }
            }
        }
    }
}

namespace BubbleSortNS
{
    public class BubbleSorter
    {
        // Bubble sorting
        public static void BubbleSort(int[] inputArray)
        {
            int tmp = 0;

            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                for (int j = 0; j < inputArray.Length - 1 - i; j++)
                {
                    if (inputArray[j] > inputArray[j + 1])
                    {
                        tmp = inputArray[j];
                        inputArray[j] = inputArray[j + 1];
                        inputArray[j + 1] = tmp;
                    }
                }
            }
        }

        // Bubble sorting with some tracking
        public static void BubbleSort2(int[] inputArray)
        {
            int tmp = 0;
            bool exchanged = false;

            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                exchanged = false;

                for (int j = 0; j < inputArray.Length - 1 - i; j++)
                {
                    if (inputArray[j] > inputArray[j + 1])
                    {
                        tmp = inputArray[j];
                        inputArray[j] = inputArray[j + 1];
                        inputArray[j + 1] = tmp;
                        exchanged = true;
                    }
                }

                if (!exchanged)
                {
                    return;
                }
            }
        }
    }
}

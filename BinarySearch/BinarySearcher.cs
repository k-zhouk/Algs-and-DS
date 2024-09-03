namespace BinarySearchNS
{
    public class BinarySearcher
    {
        public static SearchResult BinarySearch(int[] array, int value)
        {
            SearchResult sr = new SearchResult();

            // Checking the boundaries
            if ((value < array[0]) || (value > array[array.Length - 1]))
            {
                sr.Index = -1;
                sr.Iterations = 0;
                return sr;
            }

            int _iterationsCounter = 0;
            int leftIndex = 0;
            int rightIndex = array.Length - 1;
            int middle = (rightIndex + leftIndex) / 2;

            while (leftIndex < rightIndex)
            {
                _iterationsCounter++;
                if (array[middle] == value)
                {
                    sr.Index = middle;
                    sr.Iterations = _iterationsCounter;
                    return sr;
                }

                if (value > array[middle])
                {
                    leftIndex = middle + 1;
                }
                else
                {
                    rightIndex = middle - 1;
                }
                middle = (rightIndex + leftIndex) / 2;
            }

            sr.Index = -1;
            sr.Iterations = _iterationsCounter;
            return sr;
        }
    }

    public struct SearchResult
    {
        public int Index { get; set; }
        public int Iterations { get; set; }
    }
}

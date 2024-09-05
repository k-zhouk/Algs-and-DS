namespace LinearStringSearchNS
{
    public class LinStrSearch
    {
        /// <summary>
        /// Methods searches for a substring in a string and returns an index of the first occurence
        /// </summary>
        /// <param name="inputStr">Input string</param>
        /// <param name="subStr">Substring</param>
        /// <returns>Returns an index at which the substring starts or -1 if the substring is not found</returns>
        public static int LinearStringSearch(string inputStr, string subStr)
        {
            if ((inputStr == string.Empty) || (subStr == string.Empty))
            {
                return -1;
            }

            int subStrIndex = -1;
            bool subStrFound = true;
            int maxIteration = inputStr.Length - subStr.Length;

            for (int i = 0; i <= maxIteration; i++)
            {
                // If the first letters match, star comparing the further symbols
                if (inputStr[i] == subStr[0])
                {
                    subStrFound = true;

                    for (int j = 0; j < subStr.Length; j++)
                    {
                        if (subStr[j] != inputStr[i + j])
                        {
                            subStrIndex = -1;
                            subStrFound = false;
                            break;
                        }
                    }

                    if (subStrFound)
                    {
                        return i;
                    }
                }
            }
            return subStrIndex;
        }
    }
}

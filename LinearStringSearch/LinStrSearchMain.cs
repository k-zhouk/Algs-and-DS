using System.Diagnostics;
using static LinearStringSearchNS.LinStrSearch;

namespace LinearStringSearchNS
{
    class LinStrSearchMain
    {
        static void Main(string[] args)
        {
            string testStr = "cda abcd cdefg a";
            string testSubstr = "cde";

            int subStrIndex= LinearStringSearch(testStr, testSubstr);

            Debug.WriteLine($"Test string: {testStr}");
            Debug.WriteLine($"Test substring: {testSubstr}");
            Debug.WriteLine($"Index of the substring: {subStrIndex}");
        }
    }
}

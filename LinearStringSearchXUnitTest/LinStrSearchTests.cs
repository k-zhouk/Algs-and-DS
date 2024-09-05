using System;
using Xunit;
using static LinearStringSearchNS.LinStrSearch;

namespace LinearStringSearchXUnitTest
{
    public class LinStrSearchTests
    {
        [Fact]
        public void LinStrSearchInEmptyInputStringWithEmptySubstringTest()
        {
            string testStr = "";
            string subStr = "";

            int index = LinearStringSearch(testStr, subStr);

            Assert.Equal(-1, index);
        }

        [Fact]
        public void LinStrSearchWithEmptyInputStringTest()
        {
            string testStr = "";
            string subStr = "abc";

            int index = LinearStringSearch(testStr, subStr);

            Assert.Equal(-1, index);
        }

        [Fact]
        public void LinStrSearchWithEmptySubstringTest()
        {
            string testStr = "abc";
            string subStr = "";

            int index = LinearStringSearch(testStr, subStr);

            Assert.Equal(-1, index);
        }

        [Fact]
        public void LinStrSearchWithSubstringAtBeginningTest()
        {
            string testStr = "cde abcd fg a";
            string testSubstr = "cde";

            int index = LinearStringSearch(testStr, testSubstr);

            Assert.Equal(0, index);
        }

        [Fact]
        public void LinStrSearchWithSubstringAtEndTest()
        {
            string testStr = "abcd cdfg a cde";
            string testSubstr = "cde";

            int index = LinearStringSearch(testStr, testSubstr);

            Assert.Equal(12, index);
        }

        [Fact]
        public void LinStrSearchWithSubstringInMiddleTest()
        {
            string testStr = "abcd cdefg a cde";
            string testSubstr = "cde";

            int index = LinearStringSearch(testStr, testSubstr);

            Assert.Equal(5, index);
        }
    }
}

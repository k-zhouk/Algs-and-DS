using System.IO;
using SortedLinkedListNameSpace;

namespace SortedLinkedListXUnitTest
{
    public class SortedLLUnitTests
    {
        [Fact]
        public void CreateEmptyListTest()
        {
            // Arrange
            SortedLinkedList testList = new SortedLinkedList();

            // Act

            // Assert
            int? headValue = testList.HeadValue;

            Assert.NotNull(testList);
            Assert.Null(headValue);
            Assert.Equal(0, testList.Count);
        }

        [Fact]
        public void CreateListWithParameterTest()
        {
            int testValue = 1;

            SortedLinkedList testList = new SortedLinkedList(testValue);

            Assert.NotNull(testList);
            Assert.Equal(1, testList.Count);
        }

        [Fact]
        public void AccessHeadValueOfEmptyListTest()
        {
            SortedLinkedList testList = new SortedLinkedList();

            int? headValue = testList.HeadValue;

            Assert.Null(headValue);
        }

        [Fact]
        public void AccessHeadOfOneNodeListTest()
        {
            int testValue = 1;

            SortedLinkedList testList = new SortedLinkedList(testValue);

            Assert.Equal(testValue, testList.HeadValue);
        }

        #region *************** Adding Nodes **********
        [Fact]
        public void AddNodeToEmptyListTest()
        {
            SortedLinkedList testList = new SortedLinkedList();
            
            testList.AddNode(1);

            Assert.Equal(1, testList.Count);
            Assert.Equal(1, testList.HeadValue);
        }

        [Fact]
        public void AddSameNodeValueToListTest()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            
            SortedLinkedList testList = new SortedLinkedList();
            
            testList.AddNode(1);
            testList.AddNode(1);
            testList.AddNode(1);
            testList.PrintList();

            Assert.Equal("1 1 1", sw.ToString());
            Assert.Equal(3, testList.Count);
        }

        [Fact]
        public void AddGreaterValueNodeToOneNodeListTest()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            SortedLinkedList testList = new SortedLinkedList(1);
            testList.AddNode(2);
            testList.PrintList();

            Assert.Equal("1 2", sw.ToString());
            Assert.Equal(2, testList.Count);
        }
        
        [Fact]
        public void AddLowerValueNodeToOneNodeListTest()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            SortedLinkedList testList = new SortedLinkedList(2);
            testList.AddNode(1);
            testList.PrintList();

            Assert.Equal("1 2", sw.ToString());
            Assert.Equal(2, testList.Count);
        }

        [Fact]
        public void AddNodesInAscendingOrderToListTest()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            SortedLinkedList testList= new SortedLinkedList();

            testList.AddNode(1);
            testList.AddNode(2);
            testList.AddNode(3);
            testList.AddNode(4);
            testList.AddNode(5);
            testList.PrintList();

            Assert.Equal("1 2 3 4 5", sw.ToString());
            Assert.Equal(5, testList.Count);
        }
        
        [Fact]
        public void AddNodesInDecendingOrderToListTest()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            SortedLinkedList testList= new SortedLinkedList();

            testList.AddNode(3);
            testList.AddNode(2);
            testList.AddNode(1);
            testList.PrintList();

            Assert.Equal("1 2 3", sw.ToString());
            Assert.Equal(3, testList.Count);
        }
        #endregion
    }
}

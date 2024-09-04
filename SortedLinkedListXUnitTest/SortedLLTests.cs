using SortedLinkedListNS;
using Xunit;
using System.IO;
using System;

namespace SortedLinkedListXUnitTest
{
    public class SortedLLTests
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

            SortedLinkedList testList = new SortedLinkedList();

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

            SortedLinkedList testList = new SortedLinkedList();

            testList.AddNode(5);
            testList.AddNode(4);
            testList.AddNode(3);
            testList.AddNode(2);
            testList.AddNode(1);
            testList.PrintList();

            Assert.Equal("1 2 3 4 5", sw.ToString());
            Assert.Equal(5, testList.Count);
        }

        [Fact]
        public void AddNodeInMiddleListTest()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            SortedLinkedList testList = new SortedLinkedList();

            testList.AddNode(3);
            testList.AddNode(1);
            testList.AddNode(4);
            testList.AddNode(2);
            testList.AddNode(5);
            testList.PrintList();

            Assert.Equal("1 2 3 4 5", sw.ToString());
            Assert.Equal(5, testList.Count);
        }

        [Fact]
        public void AddSameNodeToBeginningOfListTest()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            SortedLinkedList testList = new SortedLinkedList();

            testList.AddNode(3);
            testList.AddNode(1);
            testList.AddNode(4);
            testList.AddNode(1);
            testList.AddNode(1);
            testList.PrintList();

            Assert.Equal("1 1 1 3 4", sw.ToString());
            Assert.Equal(5, testList.Count);
        }

        [Fact]
        public void AddSameNodeInMiddleListWithDuplicateNodesTest()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            SortedLinkedList testList = new SortedLinkedList();

            testList.AddNode(5);
            testList.AddNode(1);
            testList.AddNode(2);
            testList.AddNode(3);
            testList.AddNode(2);
            testList.AddNode(2);
            testList.AddNode(4);
            testList.AddNode(5);

            testList.PrintList();

            Assert.Equal("1 2 2 2 3 4 5 5", sw.ToString());
            Assert.Equal(8, testList.Count);
        }
        #endregion

        #region *************** Printing Nodes **********
        [Fact]
        public void PrintEmptyListTest()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            SortedLinkedList testList = new SortedLinkedList();

            testList.PrintList();

            Assert.Equal("", sw.ToString());
        }

        [Fact]
        public void PrintOneNodeListTest()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            SortedLinkedList testList = new SortedLinkedList(0);

            testList.PrintList();

            Assert.Equal("0", sw.ToString());
        }

        [Fact]
        public void PrintNonEmptyListTest()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            SortedLinkedList testList = new SortedLinkedList();
            testList.AddNode(3);
            testList.AddNode(2);
            testList.AddNode(1);

            testList.PrintList();

            Assert.Equal("1 2 3", sw.ToString());
        }
        #endregion

        #region *************** Deleting Nodes **********
        [Fact]
        public void DeleteFirstNodeOfEmptyListTest()
        {
            SortedLinkedList testList = new SortedLinkedList();

            bool res = testList.DeleteFirstNode();

            Assert.False(res);
            Assert.NotNull(testList);
            Assert.Equal(0, testList.Count);
        }

        [Fact]
        public void DeleteFirstNodeOfOneNodeListTest()
        {
            SortedLinkedList testList = new SortedLinkedList(1);

            bool res = testList.DeleteFirstNode();

            Assert.True(res);
            Assert.NotNull(testList);
            Assert.Equal(0, testList.Count);
        }

        [Fact]
        public void DeleteFirstNodeOfListTest()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            SortedLinkedList testList = new SortedLinkedList();
            testList.AddNode(1);
            testList.AddNode(2);
            testList.AddNode(3);

            bool res = testList.DeleteFirstNode();

            testList.PrintList();

            Assert.True(res);
            Assert.Equal("2 3", sw.ToString());
            Assert.Equal(2, testList.Count);
        }

        [Fact]
        public void DeleteLastNodeOfEmptyListTest()
        {
            SortedLinkedList testList = new SortedLinkedList();

            bool res = testList.DeleteLastNode();

            Assert.False(res);
            Assert.NotNull(testList);
            Assert.Equal(0, testList.Count);
        }

        [Fact]
        public void DeleteLastNodeOfOneNodeListTest()
        {
            SortedLinkedList testList = new SortedLinkedList(1);

            bool res = testList.DeleteLastNode();

            Assert.True(res);
            Assert.NotNull(testList);
            Assert.Equal(0, testList.Count);
        }

        [Fact]
        public void DeleteLastNodeOfListTest()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            SortedLinkedList testList = new SortedLinkedList();
            testList.AddNode(1);
            testList.AddNode(2);
            testList.AddNode(3);

            bool res = testList.DeleteLastNode();

            testList.PrintList();

            Assert.True(res);
            Assert.Equal("1 2", sw.ToString());
            Assert.Equal(2, testList.Count);
        }

        [Fact]
        public void DeleteNodeOfEmptyListTest()
        {
            SortedLinkedList testList = new SortedLinkedList();

            bool res = testList.DeleteNode(1);

            Assert.False(res);
            Assert.NotNull(testList);
            Assert.Equal(0, testList.Count);
            Assert.Null(testList.HeadValue);
        }

        [Fact]
        public void DeleteNodeOfOneNodeListTest()
        {
            SortedLinkedList testList = new SortedLinkedList(1);

            bool res = testList.DeleteNode(1);

            Assert.True(res);
            Assert.NotNull(testList);
            Assert.Equal(0, testList.Count);
            Assert.Null(testList.HeadValue);
        }

        [Fact]
        public void DeleteNodeFirstNodeOfListTest()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            SortedLinkedList testList = new SortedLinkedList();

            testList.AddNode(1);
            testList.AddNode(2);
            testList.AddNode(3);

            bool res = testList.DeleteNode(1);
            testList.PrintList();

            Assert.True(res);
            Assert.Equal("2 3", sw.ToString());
            Assert.Equal(2, testList.Count);
            Assert.Equal(2, testList.HeadValue);
        }

        [Fact]
        public void DeleteNodeFirstNodeOfDuplicateFirstValuesOfListTest()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            SortedLinkedList testList = new SortedLinkedList(1);

            testList.AddNode(1);
            testList.AddNode(1);
            testList.AddNode(2);
            testList.AddNode(3);

            bool res = testList.DeleteNode(1);
            testList.PrintList();

            Assert.True(res);
            Assert.Equal("1 1 2 3", sw.ToString());
            Assert.Equal(4, testList.Count);
            Assert.Equal(1, testList.HeadValue);
        }

        [Fact]
        public void DeleteNodeInMiddleOfUniqueValuesListTest()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            SortedLinkedList testList = new SortedLinkedList();
            testList.AddNode(1);
            testList.AddNode(2);
            testList.AddNode(3);

            bool res = testList.DeleteNode(2);
            testList.PrintList();

            Assert.True(res);
            Assert.Equal("1 3", sw.ToString());
            Assert.Equal(2, testList.Count);
        }

        [Fact]
        public void DeleteNodeInMiddleOfDuplicateValuesListTest()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            SortedLinkedList testList = new SortedLinkedList();
            testList.AddNode(5);
            testList.AddNode(1);
            testList.AddNode(2);
            testList.AddNode(2);
            testList.AddNode(2);
            testList.AddNode(3);
            testList.AddNode(4);
            testList.AddNode(5);

            bool res = testList.DeleteNode(2);
            testList.PrintList();

            Assert.True(res);
            Assert.Equal("1 2 2 3 4 5 5", sw.ToString());
            Assert.Equal(7, testList.Count);
            Assert.Equal(1, testList.HeadValue);
        }

        [Fact]
        public void DeleteNodeWithNonExistingValueOfListTest()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            SortedLinkedList testList = new SortedLinkedList();
            testList.AddNode(1);
            testList.AddNode(2);
            testList.AddNode(3);

            bool res = testList.DeleteNode(5);
            testList.PrintList();

            Assert.False(res);
            Assert.Equal("1 2 3", sw.ToString());
            Assert.Equal(3, testList.Count);
            Assert.Equal(1, testList.HeadValue);
        }
        #endregion

        #region *************** Contains? Nodes Testing **********
        [Fact]
        public void ContainsInEmptyListTest()
        {
            SortedLinkedList testList = new SortedLinkedList();

            bool res = testList.Contains(0);

            Assert.False(res);
        }

        [Fact]
        public void ContainsInOneNodeListTest()
        {
            SortedLinkedList testList = new SortedLinkedList(1);

            bool res = testList.Contains(1);

            Assert.True(res);
        }

        [Fact]
        public void DoesntContainInOneNodeListTest()
        {
            SortedLinkedList testList = new SortedLinkedList(1);

            bool res = testList.Contains(0);

            Assert.False(res);
        }

        [Fact]
        public void ContainsInNonEmptyListTest()
        {
            SortedLinkedList testList = new SortedLinkedList();
            testList.AddNode(1);
            testList.AddNode(2);
            testList.AddNode(3);

            bool res = testList.Contains(2);

            Assert.True(res);
        }

        [Fact]
        public void DoesntContainInNonEmptyListTest()
        {
            SortedLinkedList testList = new SortedLinkedList();
            testList.AddNode(1);
            testList.AddNode(2);
            testList.AddNode(3);

            bool res = testList.Contains(10);

            Assert.False(res);
        }
        #endregion
    }
}

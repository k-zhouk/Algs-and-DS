using Xunit.Abstractions;
using System;
using System.IO;
using LinkedList;

namespace LinkedListTest
{
    public class SimpleLLUnitTest
    {
        [Fact]
        public void CreateEmptyListTest()
        {
            // Arrange
            SimpleLinkedList testList = new SimpleLinkedList();

            // Act

            // Assert
            int? headValue= testList.HeadValue;
            int? tailValue = testList.HeadValue;

            Assert.NotNull(testList);
            Assert.Null(headValue);
            Assert.Null(tailValue);
        }

        [Fact]
        public void NodesCountOfEmptyListTest()
        {
            // Arrange
            SimpleLinkedList testList = new SimpleLinkedList();

            // Act
            uint nodesCount = testList.Count;

            // Assert
            Assert.Equal((uint)0, nodesCount);
        }

        [Fact]
        public void CreateListWithParameterTest()
        {
            SimpleLinkedList testList = new SimpleLinkedList(1);

            Assert.NotNull(testList);
        }

        [Fact]
        public void NodesCountOfListCreatedWithParameterTest()
        {
            SimpleLinkedList testList = new SimpleLinkedList(1);

            uint nodesCount = testList.Count;

            Assert.Equal((uint)1, nodesCount);
        }

        [Fact]
        public void AccessHeadValueOfEmptyListTest()
        {
            SimpleLinkedList testList = new SimpleLinkedList();

            int? headValue = testList.HeadValue;

            Assert.Null(headValue);
        }

        [Fact]
        public void AccessTailValueOfEmptyListTest()
        {
            SimpleLinkedList testList = new SimpleLinkedList();

            int? headValue = testList.TailValue;

            Assert.Null(headValue);
        }

        [Fact]
        public void PrintEmptyListTest()
        {
            // Arrange
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            SimpleLinkedList testList = new SimpleLinkedList();
            testList.PrintList();

            // Assert
            Assert.Equal("", sw.ToString());
        }

        [Fact]
        public void AddFirstMethodTest()
        {
            // Testing the method by adding 5 odd numbers into the list
            // Arrange
            SimpleLinkedList testList = new SimpleLinkedList();

            // Act
            for (int i = 1; i <= 9; i++)
            {
                if ((i % 2) != 0)
                {
                    testList.AddFirst(i);
                }
            }

            int? headValue = testList.HeadValue;
            int? tailValue = testList.TailValue;
            uint nodesCount = testList.Count;

            // Assert
            Assert.Equal(9, headValue);
            Assert.Equal(1, tailValue);
            Assert.Equal((uint)5, nodesCount);
        }

        [Fact]
        public void AddLastMethodTest()
        {
            // Testing the method by adding 5 even numbers into the list
            // Arrange
            SimpleLinkedList testList = new SimpleLinkedList();

            // Act
            for (int i = 1; i <= 10; i++)
            {
                if ((i % 2) == 0)
                {
                    testList.AddFirst(i);
                }
            }

            // Assert
            int? headValue = testList.HeadValue;
            int? tailValue = testList.TailValue;
            uint nodesCount = testList.Count;

            Assert.Equal(10, headValue);
            Assert.Equal(2, tailValue);
            Assert.Equal((uint)5, nodesCount);
        }

        [Fact]
        public void AddBeforeValueToEmptyList()
        {
            // Testing the "AddBefore()" method by adding a value in an empty list
            // Arrange
            SimpleLinkedList testList = new SimpleLinkedList();

            // Act
            testList.AddBefore(100500, 10);

            // Assert
            int? headValue = testList.HeadValue;
            int? tailValue = testList.TailValue;
            uint nodesCount = testList.Count;

            Assert.Null(headValue);
            Assert.Null(tailValue);
            Assert.Equal((uint)0, nodesCount);
        }
        
        [Fact]
        public void AddBeforeValueInMiddleOfListTest()
        {
            // Testing the "AddBefore()" method by adding a value in the middle of a list
            // Arrange
            SimpleLinkedList testList = new SimpleLinkedList();

            // Creating a list with 5 even numbers
            for (int i = 1; i <= 10; i++)
            {
                if ((i % 2) == 0)
                {
                    testList.AddFirst(i);
                }
            }

            // Act
            testList.AddBefore(100500, 6);

            // Assert
            int? headValue = testList.HeadValue;
            int? tailValue = testList.TailValue;
            uint nodesCount = testList.Count;

            // Need another way of testing. Need to check the position in the list
            Assert.Equal(10, headValue);
            Assert.Equal(2, tailValue);
            Assert.Equal((uint)6, nodesCount);
        }
        
        [Fact]
        public void AddBeforeValueBeforeTailTest()
        {
            // Testing the "AddBefore()" method by adding a value before the tail
            // Arrange
            SimpleLinkedList testList = new SimpleLinkedList();

            // Creating a list with 5 even numbers
            for (int i = 1; i <= 10; i++)
            {
                if ((i % 2) == 0)
                {
                    testList.AddFirst(i);
                }
            }

            // Act
            testList.AddBefore(100500, 6);

            // Assert
            int? headValue = testList.HeadValue;
            int? tailValue = testList.TailValue;
            uint nodesCount = testList.Count;

            Assert.Equal(10, headValue);
            Assert.Equal(2, tailValue);
            Assert.Equal((uint)6, nodesCount);
        }

    }
}

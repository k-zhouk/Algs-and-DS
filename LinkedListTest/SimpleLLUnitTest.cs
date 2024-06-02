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

        #region *************** Testing AddBefore() method
        [Fact]
        public void AddBeforeValueToEmptyList()
        {
            // Testing the "AddBefore()" method by adding a value in an empty list
            // Arrange
            SimpleLinkedList testList = new SimpleLinkedList();

            // Act
            testList.AddBefore(100500, 10);

            // Assert
            // The new node should not be added
            int? headValue = testList.HeadValue;
            int? tailValue = testList.TailValue;
            uint nodesCount = testList.Count;

            Assert.Null(headValue);
            Assert.Null(tailValue);
            Assert.Equal((uint)0, nodesCount);
        }
        
        [Fact]
        public void AddBeforeBeforeHead()
        {
            // Testing the "AddBefore()" method by adding a value before the head
            // Arrange
            StringWriter sw= new StringWriter();
            Console.SetOut(sw);

            SimpleLinkedList testList = new SimpleLinkedList();
            testList.AddFirst(1);

            // Act
            testList.AddBefore(100500, 1);
            testList.PrintList();

            // Asserts
            Assert.Equal("100500 1", sw.ToString());
            Assert.Equal((uint)2, testList.Count);
        }

        [Fact]
        public void AddBeforeInMiddleOfListTest()
        {
            // Testing the "AddBefore()" method by adding a value in the middle of a list
            // Arrange
            StringWriter sw= new StringWriter();
            Console.SetOut(sw);

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
            testList.PrintList();

            // Asserts
            Assert.Equal("10 8 100500 6 4 2", sw.ToString());

            int? headValue = testList.HeadValue;
            Assert.Equal(10, headValue);
            
            int? tailValue = testList.TailValue;
            Assert.Equal(2, tailValue);

            uint nodesCount = testList.Count;
            Assert.Equal((uint)6, nodesCount);
        }

        [Fact]
        public void AddBeforeBeforeTailTest()
        {
            // Testing the "AddBefore()" method by adding a value before the tail
            // Arrange
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

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
            testList.AddBefore(100500, 2);
            testList.PrintList();

            // Asserts
            Assert.Equal("10 8 6 4 100500 2", sw.ToString());

            int? headValue = testList.HeadValue;
            Assert.Equal(10, headValue);

            int? tailValue = testList.TailValue;
            Assert.Equal(2, tailValue);

            uint nodesCount = testList.Count;
            Assert.Equal((uint)6, nodesCount);
        }
        
        [Fact]
        public void AddBeforeNonExistingValueTest()
        {
            // Testing the "AddBefore()" method by adding a before a non-existing value
            // Arrange
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

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
            testList.AddBefore(100500, 1);
            testList.PrintList();

            // Asserts
            Assert.Equal("10 8 6 4 2", sw.ToString());

            int? headValue = testList.HeadValue;
            Assert.Equal(10, headValue);

            int? tailValue = testList.TailValue;
            Assert.Equal(2, tailValue);

            uint nodesCount = testList.Count;
            Assert.Equal((uint)5, nodesCount);
        }
        #endregion

        #region *************** Testing AddAfter() method
        [Fact]
        public void AddAfterValueToEmptyList()
        {
            // Testing the "AddAfter()" method by adding a value in an empty list
            // Arrange
            SimpleLinkedList testList = new SimpleLinkedList();

            // Act
            testList.AddAfter(100500, 10);

            // Asserts
            // The new node should not be added
            int? headValue = testList.HeadValue;
            Assert.Null(headValue);

            int? tailValue = testList.TailValue;
            Assert.Null(tailValue);

            uint nodesCount = testList.Count;
            Assert.Equal((uint)0, nodesCount);
        }
        #endregion
    }
}

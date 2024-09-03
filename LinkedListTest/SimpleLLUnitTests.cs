using LinkedList;
using Xunit;
using System;
using System.IO;

namespace LinkedListTest
{
    public class SimpleLLUnitTests
    {
        [Fact]
        public void CreateEmptyListTest()
        {
            // Arrange
            SimpleLinkedList testList = new SimpleLinkedList();

            // Act

            // Assert
            int? headValue = testList.HeadValue;
            int? tailValue = testList.HeadValue;

            Assert.NotNull(testList);
            Assert.Null(headValue);
            Assert.Null(tailValue);
            Assert.Equal((uint)0, testList.Count);
        }

        [Fact]
        public void CreateListWithParameterTest()
        {
            int testValue = 1;

            SimpleLinkedList testList = new SimpleLinkedList(testValue);

            Assert.NotNull(testList);
            Assert.Equal((uint)1, testList.Count);
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
        public void AccessHeadAndTailValueOfOneNodeListTest()
        {
            SimpleLinkedList testList = new SimpleLinkedList(1);

            Assert.Equal(testList.TailValue, testList.HeadValue);
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

        #region *************** Testing AddFirst() and AddLast() methods ***************
        [Fact]
        public void AddFirstTest()
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
        public void AddLastTest()
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
        #endregion

        #region *************** Testing Clear() method ***************
        [Fact]
        public void ClearEmptyListTest()
        {
            // Arrange
            SimpleLinkedList testList = new SimpleLinkedList();

            // Act
            testList.Clear();

            // Assert
            Assert.NotNull(testList);
            Assert.Equal((uint)0, testList.Count);
        }

        [Fact]
        public void ClearOneNodeListTest()
        {
            // Arrange
            SimpleLinkedList testList = new SimpleLinkedList();

            // Act
            testList.Clear();

            // Assert
            Assert.NotNull(testList);
            Assert.Equal((uint)0, testList.Count);
        }

        [Fact]
        public void ClearListTest()
        {
            // Arrange
            SimpleLinkedList testList = new SimpleLinkedList();
            for (int i = 1; i <= 10; i++)
            {
                testList.AddFirst(i);
            }

            // Act
            testList.Clear();

            // Assert
            Assert.NotNull(testList);
            Assert.Equal((uint)0, testList.Count);
        }
        #endregion

        #region *************** Testing Contains() method ***************
        [Fact]
        public void ContainsForEmptyListTest()
        {
            // Arrange
            SimpleLinkedList testList = new SimpleLinkedList();

            // Act
            bool res = testList.Contains(0);

            // Assert
            Assert.False(res);
        }

        [Fact]
        public void ContainsTrueInOneNodeListTest()
        {
            // Arrange
            SimpleLinkedList testList = new SimpleLinkedList(1);

            // Act
            bool res = testList.Contains(1);

            // Assert
            Assert.True(res);
        }

        [Fact]
        public void ContainsFalseInOneNodeListTest()
        {
            // Arrange
            SimpleLinkedList testList = new SimpleLinkedList(1);

            // Act
            bool res = testList.Contains(0);

            // Assert
            Assert.False(res);
        }

        [Fact]
        public void ContainsTrueInListTest()
        {
            // Arrange
            SimpleLinkedList testList = new SimpleLinkedList(0);

            for(int i = 1;i <= 10; i++)
            {
                testList.AddFirst(i);
            }

            // Act
            bool res = testList.Contains(5);

            // Assert
            Assert.True(res);
        }
        
        [Fact]
        public void ContainsFalseInListTest()
        {
            // Arrange
            SimpleLinkedList testList = new SimpleLinkedList(0);

            for(int i = 1;i <= 10; i++)
            {
                testList.AddFirst(i);
            }

            // Act
            bool res = testList.Contains(50);

            // Assert
            Assert.False(res);
        }
        #endregion

        #region *************** Testing AddBefore() method ***************
        [Fact]
        public void AddBeforeValueToEmptyListTest()
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
        public void AddBeforeBeforeHeadTest()
        {
            // Testing the "AddBefore()" method by adding a value before the head
            // Arrange
            StringWriter sw = new StringWriter();
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

        #region *************** Testing AddAfter() method ***************
        [Fact]
        public void AddAfterValueToEmptyListTest()
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

        [Fact]
        public void AddAfterAfterHeadTest()
        {
            // Testing the "AddAfter()" method by adding a value in an empty list
            // Arrange
            SimpleLinkedList testList = new SimpleLinkedList(1);

            // Act
            testList.AddAfter(100500, 1);

            // Asserts
            int? headValue = testList.HeadValue;
            Assert.Equal(1, headValue);

            int? tailValue = testList.TailValue;
            Assert.Equal(100500, tailValue);

            uint nodesCount = testList.Count;
            Assert.Equal((uint)2, nodesCount);
        }

        [Fact]
        public void AddAfterInMiddleOfListTest()
        {
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
            testList.AddAfter(100500, 6);
            testList.PrintList();

            // Asserts
            Assert.Equal("10 8 6 100500 4 2", sw.ToString());

            int? headValue = testList.HeadValue;
            Assert.Equal(10, headValue);

            int? tailValue = testList.TailValue;
            Assert.Equal(2, tailValue);

            uint nodesCount = testList.Count;
            Assert.Equal((uint)6, nodesCount);
        }

        [Fact]
        public void AddAfterTailTest()
        {
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
            testList.AddAfter(100500, 2);
            testList.PrintList();

            // Asserts
            int? headValue = testList.HeadValue;
            Assert.Equal(10, headValue);

            int? tailValue = testList.TailValue;
            Assert.Equal(100500, tailValue);

            uint nodesCount = testList.Count;
            Assert.Equal((uint)6, nodesCount);
        }

        [Fact]
        public void AddAfterNonExistingValueTest()
        {
            // Testing the "AddAfter()" method by adding a before a non-existing value
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
            testList.AddAfter(100500, 1);
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

        #region *************** Testing of DeleteFirstNode() and DeleteLastNode() methods ***************
        [Fact]
        public void DeletFirstNodeForEmptyListTest()
        {
            // Arrange
            SimpleLinkedList testList = new SimpleLinkedList();

            // Act
            testList.DeleteFirstNode();

            // Asserts
            Assert.NotNull(testList);
            Assert.Null(testList.HeadValue);
            Assert.Null(testList.TailValue);
            Assert.Equal((uint)0, testList.Count);
        }

        [Fact]
        public void DeletFirstNodeForOneNodeListTest()
        {
            // Arrange
            SimpleLinkedList testList = new SimpleLinkedList(1);

            // Act
            testList.DeleteFirstNode();

            // Asserts
            Assert.NotNull(testList);
            Assert.Null(testList.HeadValue);
            Assert.Null(testList.TailValue);
            Assert.Equal((uint)0, testList.Count);
        }

        [Fact]
        public void DeletFirstNodeTest()
        {
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
            testList.DeleteFirstNode();

            // Asserts
            int? headValue = testList.HeadValue;
            Assert.Equal(8, headValue);

            int? tailValue = testList.TailValue;
            Assert.Equal(2, tailValue);

            uint nodesCount = testList.Count;
            Assert.Equal((uint)4, nodesCount);
        }

        [Fact]
        public void DeletLastNodeForEmptyListTest()
        {
            // Arrange
            SimpleLinkedList testList = new SimpleLinkedList();

            // Act
            testList.DeleteLastNode();

            // Asserts
            Assert.NotNull(testList);
            Assert.Null(testList.HeadValue);
            Assert.Null(testList.TailValue);
            Assert.Equal((uint)0, testList.Count);
        }

        [Fact]
        public void DeletLastNodeForOneNodeListTest()
        {
            // Arrange
            SimpleLinkedList testList = new SimpleLinkedList(1);

            // Act
            testList.DeleteLastNode();

            // Asserts
            Assert.NotNull(testList);
            Assert.Null(testList.HeadValue);
            Assert.Null(testList.TailValue);
            Assert.Equal((uint)0, testList.Count);
        }

        [Fact]
        public void DeletLastNodeTest()
        {
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
            testList.DeleteLastNode();

            // Asserts
            int? headValue = testList.HeadValue;
            Assert.Equal(10, headValue);

            int? tailValue = testList.TailValue;
            Assert.Equal(4, tailValue);

            uint nodesCount = testList.Count;
            Assert.Equal((uint)4, nodesCount);
        }
        #endregion

        #region *************** Testing of DeleteBefore() methods ***************
        [Fact]
        public void DeleteBeforeForEmptyListTest()
        {
            // Arrange
            SimpleLinkedList testList = new SimpleLinkedList();

            // Act
            bool res= testList.DeleteBefore(5);

            // Asserts
            Assert.False(res);
        }
        
        [Fact]
        public void DeleteBeforeForOneNodeListTest()
        {
            // Arrange
            SimpleLinkedList testList = new SimpleLinkedList(1);

            // Act
            testList.DeleteBefore(1);

            // Asserts
            Assert.NotNull(testList);
            Assert.Equal(1, testList.HeadValue);
            Assert.Equal(1, testList.TailValue);
            Assert.Equal((uint)1, testList.Count);
        }
        
        [Fact]
        public void DeleteBeforeHeadTest()
        {
            // Arrange
            StringWriter sw= new StringWriter();
            Console.SetOut(sw);

            SimpleLinkedList testList = new SimpleLinkedList();

            for (int i = 1; i <= 5; i++)
            {
                testList.AddFirst(i);
            }

            // Act
            testList.DeleteBefore(5);
            testList.PrintList();

            // Asserts
            Assert.Equal("5 4 3 2 1", sw.ToString());
            Assert.Equal((uint)5, testList.Count);
        }
        
        [Fact]
        public void DeleteBeforeTailTest()
        {
            // Arrange
            StringWriter sw= new StringWriter();
            Console.SetOut(sw);

            SimpleLinkedList testList = new SimpleLinkedList();

            for (int i = 1; i <= 5; i++)
            {
                testList.AddFirst(i);
            }

            // Act
            testList.DeleteBefore(1);
            testList.PrintList();

            // Asserts
            Assert.Equal("5 4 3 1", sw.ToString());
            Assert.Equal(5, testList.HeadValue);
            Assert.Equal(1, testList.TailValue);
            Assert.Equal((uint)4, testList.Count);
        }
        
        [Fact]
        public void DeleteBeforeForNonExistingNodeTest()
        {
            // Arrange
            StringWriter sw= new StringWriter();
            Console.SetOut(sw);

            SimpleLinkedList testList = new SimpleLinkedList();

            for (int i = 1; i <= 5; i++)
            {
                testList.AddFirst(i);
            }

            // Act
            testList.DeleteBefore(0);
            testList.PrintList();

            // Asserts
            Assert.Equal(5, testList.HeadValue);
            Assert.Equal(1, testList.TailValue);
            Assert.Equal((uint)5, testList.Count);
        }
        #endregion

        #region *************** Testing of DeleteAfter() methods ***************
        [Fact]
        public void DeleteAfterForEmptyListTest()
        {
            // Arrange
            SimpleLinkedList testList = new SimpleLinkedList();

            // Act
            bool res = testList.DeleteAfter(5);

            // Asserts
            Assert.False(res);
        }

        [Fact]
        public void DeleteAfterForOneNodeListTest()
        {
            // Arrange
            SimpleLinkedList testList = new SimpleLinkedList(1);

            // Act
            testList.DeleteAfter(1);

            // Asserts
            Assert.NotNull(testList);
            Assert.Equal(1, testList.HeadValue);
            Assert.Equal(1, testList.TailValue);
            Assert.Equal((uint)1, testList.Count);
        }

        [Fact]
        public void DeleteAfterHeadTest()
        {
            // Arrange
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            SimpleLinkedList testList = new SimpleLinkedList();

            for (int i = 1; i <= 5; i++)
            {
                testList.AddFirst(i);
            }

            // Act
            testList.DeleteAfter(5);
            testList.PrintList();

            // Asserts
            Assert.Equal("5 3 2 1", sw.ToString());
            Assert.Equal((uint)4, testList.Count);
        }

        [Fact]
        public void DeleteAfterTailTest()
        {
            // Arrange
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            SimpleLinkedList testList = new SimpleLinkedList();

            for (int i = 1; i <= 5; i++)
            {
                testList.AddFirst(i);
            }

            // Act
            testList.DeleteAfter(1);
            testList.PrintList();

            // Asserts
            Assert.Equal(5, testList.HeadValue);
            Assert.Equal(1, testList.TailValue);
            Assert.Equal((uint)5, testList.Count);
        }

        [Fact]
        public void DeleteAfterForNonExistingNodeTest()
        {
            // Arrange
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            SimpleLinkedList testList = new SimpleLinkedList();

            for (int i = 1; i <= 5; i++)
            {
                testList.AddFirst(i);
            }

            // Act
            testList.DeleteAfter(0);
            testList.PrintList();

            // Asserts
            Assert.Equal(5, testList.HeadValue);
            Assert.Equal(1, testList.TailValue);
            Assert.Equal((uint)5, testList.Count);
        }
        #endregion

        #region *************** Testing of Delete() methods ***************
        [Fact]
        public void DeleteForEmptyListTest()
        {
            // Arrange
            SimpleLinkedList testList = new SimpleLinkedList();

            // Act
            bool res = testList.Delete(0);

            // Asserts
            Assert.False(res);
        }

        [Fact]
        public void DeleteForOneNodeListTest()
        {
            // Arrange
            SimpleLinkedList testList = new SimpleLinkedList(1);

            // Act
            testList.Delete(1);

            // Asserts
            Assert.NotNull(testList);
            Assert.Null(testList.HeadValue);
            Assert.Null(testList.TailValue);
            Assert.Equal((uint)0, testList.Count);
        }

        [Fact]
        public void DeleteHeadTest()
        {
            // Arrange
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            SimpleLinkedList testList = new SimpleLinkedList();

            for (int i = 1; i <= 5; i++)
            {
                testList.AddFirst(i);
            }

            // Act
            testList.Delete(5);
            testList.PrintList();

            // Asserts
            Assert.Equal("4 3 2 1", sw.ToString());
            Assert.Equal((uint)4, testList.Count);
        }

        [Fact]
        public void DeleteTailTest()
        {
            // Arrange
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            SimpleLinkedList testList = new SimpleLinkedList();

            for (int i = 1; i <= 5; i++)
            {
                testList.AddFirst(i);
            }

            // Act
            testList.Delete(1);
            testList.PrintList();

            // Asserts
            Assert.Equal(5, testList.HeadValue);
            Assert.Equal(2, testList.TailValue);
            Assert.Equal((uint)4, testList.Count);
        }

        [Fact]
        public void DeleteForNonExistingNodeTest()
        {
            // Arrange
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            SimpleLinkedList testList = new SimpleLinkedList();

            for (int i = 1; i <= 5; i++)
            {
                testList.AddFirst(i);
            }

            // Act
            testList.Delete(0);
            testList.PrintList();

            // Asserts
            Assert.Equal(5, testList.HeadValue);
            Assert.Equal(1, testList.TailValue);
            Assert.Equal((uint)5, testList.Count);
        }
        #endregion

        #region *************** Testing of DeleteAllOccurrences() methods ***************
        [Fact]
        public void DeleteAllOccurrencesForEmptyListTest()
        {
            // Arrange
            SimpleLinkedList testList = new SimpleLinkedList();

            // Act
            testList.DeleteAllOccurrences(0);

            // Asserts
            Assert.NotNull(testList);
            Assert.Equal((uint)0, testList.Count);
        }

        [Fact]
        public void DeleteAllOccurrencesForOneNodeListTest()
        {
            // Arrange
            SimpleLinkedList testList = new SimpleLinkedList(1);

            // Act
            testList.DeleteAllOccurrences(1);

            // Asserts
            Assert.NotNull(testList);
            Assert.Equal(1, testList.HeadValue);
            Assert.Equal(1, testList.TailValue);
            Assert.Equal((uint)1, testList.Count);
        }

        [Fact]
        public void DeleteAllOccurrencesHeadTest()
        {
            // Arrange
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            SimpleLinkedList testList = new SimpleLinkedList(1);

            for (int i = 1; i <= 5; i++)
            {
                testList.AddFirst(i);
            }

            // Act
            testList.DeleteAllOccurrences(5);
            testList.PrintList();

            // Asserts
            Assert.Equal("4 3 2 1", sw.ToString());
            Assert.Equal((uint)4, testList.Count);
        }

        [Fact]
        public void DeleteAllOccurrencesTailTest()
        {
            // Arrange
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            SimpleLinkedList testList = new SimpleLinkedList(1);

            for (int i = 1; i <= 5; i++)
            {
                testList.AddFirst(i);
            }

            // Act
            testList.DeleteAllOccurrences(1);
            testList.PrintList();

            // Asserts
            Assert.Equal(5, testList.HeadValue);
            Assert.Equal(2, testList.TailValue);
            Assert.Equal((uint)4, testList.Count);
        }

        [Fact]
        public void DeleteAllOccurrencesForNonExistingNodeTest()
        {
            // Arrange
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            SimpleLinkedList testList = new SimpleLinkedList();

            for (int i = 1; i <= 5; i++)
            {
                testList.AddFirst(i);
            }

            // Act
            testList.DeleteAllOccurrences(0);
            testList.PrintList();

            // Asserts
            Assert.Equal(5, testList.HeadValue);
            Assert.Equal(1, testList.TailValue);
            Assert.Equal((uint)5, testList.Count);
        }
        
        [Fact]
        public void DeleteAllOccurrencesForAllSameNodesTest()
        {
            // Arrange
            SimpleLinkedList testList = new SimpleLinkedList();

            int testValue = 10;
            for (int i = 1; i <= 10; i++)
            {
                testList.AddFirst(testValue);
            }

            // Act
            testList.DeleteAllOccurrences(testValue);
            testList.PrintList();

            // Asserts
            Assert.NotNull(testList);
            Assert.Null(testList.HeadValue);
            Assert.Null(testList.TailValue);
            Assert.Equal((uint)0, testList.Count);
        }
        #endregion
    }
}

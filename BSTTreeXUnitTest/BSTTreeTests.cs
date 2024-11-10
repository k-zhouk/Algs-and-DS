using BST_Tree;
using Xunit;
using System;

namespace BSTTreeXUnitTest
{
    public class BSTTreeTests
    {
        #region *************** GROUP 1 TESTS- BST creation ***************
        [Fact]
        public void Group1_Creation_CreateEmptyTreeTest()
        {
            // Arrange

            // Act
            BSTTree testTree = new();

            // Assert
            Assert.NotNull(testTree);
            Assert.Equal((uint)0, testTree.Count);
        }

        [Fact]
        public void Group1_Creation_CreateNonEmptyTreeTest()
        {
            BSTTree testTree = new(100500);

            Assert.Equal((uint)1, testTree.Count);
            Assert.NotNull(testTree);
        }
        #endregion

        #region *************** GROUP 2 TESTS- Adding nodes ***************
        [Fact]
        public void Group2_Adding_Nodes_AddNewNodeToEmptyTreeTest()
        {
            BSTTree testTree = new();

            bool res = testTree.Add(50);

            Assert.True(res);
            Assert.NotNull(testTree);
            Assert.Equal((uint)1, testTree.Count);
        }

        [Fact]
        public void Group2_Adding_Nodes_AddNewNodeToNonEmptyTreeTest()
        {
            BSTTree testTree = new(0);

            bool res = testTree.Add(50);

            Assert.True(res);
            Assert.NotNull(testTree);
            Assert.Equal((uint)2, testTree.Count);
        }

        [Fact]
        public void Group2_Adding_Nodes_AddSeveralNewNodesTest()
        {
            BSTTree testTree = new();

            bool res1 = testTree.Add(50);
            bool res2 = testTree.Add(10);
            bool res3 = testTree.Add(60);
            bool res4 = testTree.Add(7);
            bool res5 = testTree.Add(11);
            bool res6 = testTree.Add(55);
            bool res7 = testTree.Add(20);

            Assert.True(res1);
            Assert.True(res2);
            Assert.True(res3);
            Assert.True(res4);
            Assert.True(res5);
            Assert.True(res6);
            Assert.True(res7);

            Assert.Equal((uint)7, testTree.Count);
        }

        [Fact]
        public void Group2_Adding_Nodes_AddSameNodeTest()
        {
            BSTTree testTree = new();

            _ = testTree.Add(50);
            _ = testTree.Add(10);
            _ = testTree.Add(60);
            _ = testTree.Add(7);
            _ = testTree.Add(15);
            _ = testTree.Add(55);
            _ = testTree.Add(20);
            _ = testTree.Add(14);
            _ = testTree.Add(13);
            _ = testTree.Add(18);
            _ = testTree.Add(22);
            _ = testTree.Add(19);

            bool res = testTree.Add(15);

            Assert.False(res);
            Assert.Equal((uint)12, testTree.Count);
        }
        #endregion

        #region *************** GROUP 3 TESTS- Deleting nodes ***************
        [Fact]
        public void Group3_Deleting_Nodes_DeleteNodeFromEmptyTreeTest()
        {
            BSTTree testTree = new();

            bool deletionResult = testTree.Delete(50);

            Assert.False(deletionResult);
            Assert.NotNull(testTree);
            Assert.Equal((uint)0, testTree.Count);
        }

        [Fact]
        public void Group3_Deleting_Nodes_DeleteNodeFromOneNodeTreeTest()
        {
            BSTTree testTree = new();
            _ = testTree.Add(50);

            bool deletionResult = testTree.Delete(50);

            Assert.True(deletionResult);
            Assert.NotNull(testTree);
            Assert.Equal((uint)0, testTree.Count);
        }

        [Fact]
        public void Group3_Deleting_Nodes_DeleteNonExistingNodeFromTreeTest()
        {
            BSTTree testTree = new();

            _ = testTree.Add(50);
            _ = testTree.Add(10);
            _ = testTree.Add(60);
            _ = testTree.Add(7);
            _ = testTree.Add(15);
            _ = testTree.Add(55);
            _ = testTree.Add(20);
            _ = testTree.Add(14);
            _ = testTree.Add(13);
            _ = testTree.Add(18);
            _ = testTree.Add(22);
            _ = testTree.Add(19);

            bool deletionResult = testTree.Delete(25);
            Assert.False(deletionResult);

            // The number of nodes should not change
            Assert.Equal((uint)12, testTree.Count);
        }

        [Fact]
        public void Group3_Deleting_Nodes_DeleteNodeWithNoChildrenIfLeftNodeTest()
        // Deleting a node with no children, if it's a left node of a parent node
        {
            BSTTree testTree = new();

            _ = testTree.Add(50);
            _ = testTree.Add(10);
            _ = testTree.Add(60);
            _ = testTree.Add(7);
            _ = testTree.Add(15);
            _ = testTree.Add(55);
            _ = testTree.Add(20);
            _ = testTree.Add(14);
            _ = testTree.Add(13);
            _ = testTree.Add(18);
            _ = testTree.Add(22);
            _ = testTree.Add(19);

            bool deletionResults = testTree.Delete(7);

            Assert.True(deletionResults);
            Assert.NotNull(testTree);
            Assert.False(testTree.Contains(7));
            Assert.Equal((uint)11, testTree.Count);
        }

        [Fact]
        public void Group3_Deleting_Nodes_DeleteNodeWithNoChildrenIfRightTest()
        // Deleting a node with no children, if it's a right node of a parent node
        {
            BSTTree testTree = new();

            _ = testTree.Add(50);
            _ = testTree.Add(10);
            _ = testTree.Add(60);
            _ = testTree.Add(7);
            _ = testTree.Add(15);
            _ = testTree.Add(55);
            _ = testTree.Add(20);
            _ = testTree.Add(14);
            _ = testTree.Add(13);
            _ = testTree.Add(18);
            _ = testTree.Add(22);
            _ = testTree.Add(19);

            bool deletionResults = testTree.Delete(19);

            Assert.True(deletionResults);
            Assert.NotNull(testTree);
            Assert.False(testTree.Contains(19));
            Assert.Equal((uint)11, testTree.Count);
        }

        [Fact]
        public void Group3_Deleting_Nodes_DelteNodeWithNullLeftChildTest()
        {
            BSTTree testTree = new();

            _ = testTree.Add(50);
            _ = testTree.Add(10);
            _ = testTree.Add(60);
            _ = testTree.Add(7);
            _ = testTree.Add(15);
            _ = testTree.Add(55);
            _ = testTree.Add(20);
            _ = testTree.Add(14);
            _ = testTree.Add(13);
            _ = testTree.Add(18);
            _ = testTree.Add(22);
            _ = testTree.Add(19);

            bool deletionResults = testTree.Delete(18);

            Assert.True(deletionResults);
            Assert.NotNull(testTree);
            Assert.False(testTree.Contains(18));
            Assert.Equal((uint)11, testTree.Count);
        }

        [Fact]
        public void Group3_Deleting_Nodes_DeleteNodeWithNullRightChildTest()
        {
            BSTTree testTree = new();

            _ = testTree.Add(50);
            _ = testTree.Add(10);
            _ = testTree.Add(60);
            _ = testTree.Add(7);
            _ = testTree.Add(15);
            _ = testTree.Add(55);
            _ = testTree.Add(20);
            _ = testTree.Add(14);
            _ = testTree.Add(13);
            _ = testTree.Add(18);
            _ = testTree.Add(22);
            _ = testTree.Add(19);

            bool deletionResults = testTree.Delete(14);

            Assert.True(deletionResults);
            Assert.Equal((uint)11, testTree.Count);
            Assert.False(testTree.Contains(14));
        }

        [Fact]
        public void Group3_Deleting_Nodes_DeleteNodeWithTwoChildrenTest()
        {
            BSTTree testTree = new();

            _ = testTree.Add(50);
            _ = testTree.Add(10);
            _ = testTree.Add(60);
            _ = testTree.Add(7);
            _ = testTree.Add(15);
            _ = testTree.Add(55);
            _ = testTree.Add(20);
            _ = testTree.Add(14);
            _ = testTree.Add(13);
            _ = testTree.Add(18);
            _ = testTree.Add(22);
            _ = testTree.Add(19);

            bool deletionResults = testTree.Delete(15);

            Assert.True(deletionResults);
            Assert.Equal((uint)11, testTree.Count);
            Assert.False(testTree.Contains(15));
        }

        [Fact]
        public void Group3_Deleting_Nodes_DeleteRootNodeWithTwoChildrenTest()
        {
            BSTTree testTree = new();

            _ = testTree.Add(50);
            _ = testTree.Add(10);
            _ = testTree.Add(60);
            _ = testTree.Add(7);
            _ = testTree.Add(15);
            _ = testTree.Add(55);
            _ = testTree.Add(20);
            _ = testTree.Add(14);
            _ = testTree.Add(13);
            _ = testTree.Add(18);
            _ = testTree.Add(22);
            _ = testTree.Add(19);

            bool deletionResult = testTree.Delete(50);

            Assert.True(deletionResult);
            Assert.Equal((uint)11, testTree.Count);
            Assert.False(testTree.Contains(50));
        }

        [Fact]
        public void Group3_Deleting_Nodes_DeleteRootNodeWithLeftChildTest()
        {
            BSTTree testTree = new();

            _ = testTree.Add(50);
            _ = testTree.Add(10);
            _ = testTree.Add(7);
            _ = testTree.Add(15);
            _ = testTree.Add(55);
            _ = testTree.Add(20);
            _ = testTree.Add(14);
            _ = testTree.Add(13);
            _ = testTree.Add(18);
            _ = testTree.Add(22);
            _ = testTree.Add(19);

            bool deletionResult = testTree.Delete(50);

            throw new Exception();

            // Deletion is not working properly- wrong node becomes a root

            Assert.True(deletionResult);
            Assert.Equal((uint)10, testTree.Count);
            Assert.False(testTree.Contains(50));
        }

        [Fact]
        public void Group3_Deleting_Nodes_DeleteRootNodeWithRightChildTest()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region *************** GROUP 4 TESTS- Maximum and Minimum values tests ***************
        [Fact]
        public void Group4_Max_Min_GetMinimumForEmptyTreeTest()
        {
            BSTTree testTree = new();

            Assert.Throws<ArgumentNullException>(() => testTree.GetMinimum());
        }

        [Fact]
        public void Group4_Max_Min_GetMinimumForOneNodeTreeTest()
        {
            BSTTree testTree = new();
            bool res = testTree.Add(50);

            int minimumValue = testTree.GetMinimum();

            Assert.Equal(50, minimumValue);
        }

        [Fact]
        public void Group4_Max_Min_GetMinimumForTreeTest()
        {
            BSTTree testTree = new();

            _ = testTree.Add(50);
            _ = testTree.Add(10);
            _ = testTree.Add(60);
            _ = testTree.Add(7);
            _ = testTree.Add(15);
            _ = testTree.Add(55);
            _ = testTree.Add(20);
            _ = testTree.Add(14);
            _ = testTree.Add(13);
            _ = testTree.Add(18);
            _ = testTree.Add(22);
            _ = testTree.Add(19);

            int minimumValue = testTree.GetMinimum();

            Assert.Equal(7, minimumValue);
        }

        [Fact]
        public void Group4_Max_Min_GetMaximumForEmptyTreeTest()
        {
            BSTTree testTree = new();

            Assert.Throws<ArgumentNullException>(() => testTree.GetMaximum());
        }

        [Fact]
        public void Group4_Max_Min_GetMaximumForOneNodeTreeTest()
        {
            BSTTree testTree = new();
            bool res = testTree.Add(50);

            int maximumValue = testTree.GetMaximum();

            Assert.Equal(50, maximumValue);
        }

        [Fact]
        public void Group4_Max_Min_GetMaximumForTreeTest()
        {
            BSTTree testTree = new();

            _ = testTree.Add(50);
            _ = testTree.Add(10);
            _ = testTree.Add(60);
            _ = testTree.Add(7);
            _ = testTree.Add(15);
            _ = testTree.Add(55);
            _ = testTree.Add(20);
            _ = testTree.Add(14);
            _ = testTree.Add(13);
            _ = testTree.Add(18);
            _ = testTree.Add(22);
            _ = testTree.Add(19);

            int maximumValue = testTree.GetMaximum();

            Assert.Equal(60, maximumValue);
        }

        #endregion

        #region *************** GROUP 5 TESTS- Contains tests ***************
        [Fact]
        public void Group5_Contains_ContainsForEmptyTreeTest()
        {
            BSTTree testTree = new();

            bool res = testTree.Contains(100);

            Assert.False(res);
        }

        [Fact]
        public void Group5_Contains_ContainsForExistingOneNodeTest()
        {
            BSTTree testTree = new(1);

            bool res = testTree.Contains(1);

            Assert.True(res);
        }

        [Fact]
        public void Group5_Contains_ContainsForNonExistingOneNodeTest()
        {
            BSTTree testTree = new(1);

            bool res = testTree.Contains(100);

            Assert.False(res);
        }

        [Fact]
        public void Group5_Contains_ContainsForExistingNodeTest()
        {
            BSTTree testTree = new();

            _ = testTree.Add(50);
            _ = testTree.Add(10);
            _ = testTree.Add(60);
            _ = testTree.Add(7);
            _ = testTree.Add(15);
            _ = testTree.Add(55);
            _ = testTree.Add(20);
            _ = testTree.Add(14);
            _ = testTree.Add(13);
            _ = testTree.Add(18);
            _ = testTree.Add(22);
            _ = testTree.Add(19);

            bool res = testTree.Contains(7);

            Assert.True(res);
        }

        [Fact]
        public void Group5_Contains_ContainsForNonExistingNodeTest()
        {
            BSTTree testTree = new();

            _ = testTree.Add(50);
            _ = testTree.Add(10);
            _ = testTree.Add(60);
            _ = testTree.Add(7);
            _ = testTree.Add(15);
            _ = testTree.Add(55);
            _ = testTree.Add(20);
            _ = testTree.Add(14);
            _ = testTree.Add(13);
            _ = testTree.Add(18);
            _ = testTree.Add(22);
            _ = testTree.Add(19);

            bool res = testTree.Contains(100);

            Assert.False(res);
        }
        #endregion

        #region *************** GROUP 6 TESTS- Count tests **********
        [Fact]
        public void Group6_Count_CountForEmptyTreeTest()
        {
            BSTTree testTree = new();

            uint count = testTree.Count;

            Assert.Equal((uint)0, count);
        }

        [Fact]
        public void Group6_Count_CountForOneNodeTreeTest()
        {
            BSTTree testTree = new();
            _ = testTree.Add(50);

            uint count = testTree.Count;

            Assert.Equal((uint)1, count);
        }

        [Fact]
        public void Group6_Count_CountTreeTest()
        {
            BSTTree testTree = new();

            _ = testTree.Add(50);
            _ = testTree.Add(10);
            _ = testTree.Add(60);
            _ = testTree.Add(7);
            _ = testTree.Add(15);
            _ = testTree.Add(55);
            _ = testTree.Add(20);
            _ = testTree.Add(14);
            _ = testTree.Add(13);
            _ = testTree.Add(18);
            _ = testTree.Add(22);
            _ = testTree.Add(19);

            uint count = testTree.Count;

            Assert.Equal((uint)12, count);
        }
        #endregion

        #region *************** GROUP 7 TESTS- Clear tests **********
        [Fact]
        public void Group7_Clear_ClearMethodForEmptyListTest()
        {
            BSTTree testTree = new();

            testTree.Clear();

            Assert.NotNull(testTree);
            Assert.Equal((uint)0, testTree.Count);
        }

        [Fact]
        public void Group7_Clear_ClearMethodForNonEmptyListTest()
        {
            BSTTree testTree = new();

            _ = testTree.Add(50);
            _ = testTree.Add(10);
            _ = testTree.Add(60);
            _ = testTree.Add(7);
            _ = testTree.Add(15);
            _ = testTree.Add(55);
            _ = testTree.Add(20);
            _ = testTree.Add(14);
            _ = testTree.Add(13);
            _ = testTree.Add(18);
            _ = testTree.Add(22);
            _ = testTree.Add(19);

            testTree.Clear();

            Assert.NotNull(testTree);
            Assert.Equal((uint)0, testTree.Count);
        }
        #endregion

        #region *************** GROUP 8 TESTS- Print tests **********
        [Fact]
        public void Group8_Print_PrintAscendingEmptyTreeTest()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void Group8_Print_PrintAscendingTreeTest()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void Group8_Print_PrintDescendingEmptyTreeTest()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void Group8_Print_PrintDescendingTreeTest()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region *************** GROUP 9 TESTS- Height tests **********
        [Fact]
        public void Group9_Height_HeightOfEmptyTreeTest()
        {
            BSTTree testTree = new();

            uint height = testTree.Height;

            Assert.Equal((uint)0, height);
        }

        [Fact]
        public void Group9_Height_HeightOfOneNodeTreeTest()
        {
            BSTTree testTree = new();
            _ = testTree.Add(50);

            uint height = testTree.Height;

            Assert.Equal((uint)1, height);
        }

        [Fact]
        public void Group9_Height_HeightOfTreeTest()
        {
            BSTTree testTree = new();

            _ = testTree.Add(50);
            _ = testTree.Add(10);
            _ = testTree.Add(60);
            _ = testTree.Add(7);
            _ = testTree.Add(15);
            _ = testTree.Add(55);
            _ = testTree.Add(20);
            _ = testTree.Add(14);
            _ = testTree.Add(13);
            _ = testTree.Add(18);
            _ = testTree.Add(22);
            _ = testTree.Add(19);

            uint height = testTree.Height;
            Assert.Equal((uint)4, height);
        }

        [Fact]
        public void Group9_Height_DecreaseOfHeightAfterDeletingNodeTest()
        {
            BSTTree testTree = new();

            _ = testTree.Add(50);
            _ = testTree.Add(10);
            _ = testTree.Add(60);
            _ = testTree.Add(7);
            _ = testTree.Add(15);
            _ = testTree.Add(55);
            _ = testTree.Add(20);
            _ = testTree.Add(14);
            _ = testTree.Add(13);
            _ = testTree.Add(18);
            _ = testTree.Add(22);
            _ = testTree.Add(19);

            uint height = testTree.Height;
            Assert.Equal((uint)4, height);

            _ = testTree.Delete(11);
            height = testTree.Height;
            Assert.Equal((uint)4, height);
        }

        [Fact]
        public void Group9_Height_NonDecreaseOfHeightAfterDeletingNodeTest()
        {
            BSTTree testTree = new();

            _ = testTree.Add(50);
            _ = testTree.Add(10);
            _ = testTree.Add(60);
            _ = testTree.Add(7);
            _ = testTree.Add(15);
            _ = testTree.Add(55);
            _ = testTree.Add(20);
            _ = testTree.Add(14);
            _ = testTree.Add(13);
            _ = testTree.Add(18);
            _ = testTree.Add(22);
            _ = testTree.Add(19);

            uint height = testTree.Height;
            Assert.Equal((uint)4, height);

            _ = testTree.Delete(60);
            height = testTree.Height;
            Assert.Equal((uint)4, height);
        }

        [Fact]
        public void Group9_Height_IncreaseOfHeightAfterAddingNodeTest()
        {
            BSTTree testTree = new();

            _ = testTree.Add(50);
            _ = testTree.Add(10);
            _ = testTree.Add(60);
            _ = testTree.Add(7);
            _ = testTree.Add(15);
            _ = testTree.Add(55);
            _ = testTree.Add(20);
            _ = testTree.Add(14);
            _ = testTree.Add(13);
            _ = testTree.Add(18);
            _ = testTree.Add(22);
            _ = testTree.Add(19);

            uint height = testTree.Height;
            Assert.Equal((uint)4, height);

            _ = testTree.Add(25);
            height = testTree.Height;
            Assert.Equal((uint)5, height);
        }

        [Fact]
        public void Group9_Height_NonIncreaseOfHeightAfterAddingNodeTest()
        {
            BSTTree testTree = new();

            _ = testTree.Add(50);
            _ = testTree.Add(10);
            _ = testTree.Add(60);
            _ = testTree.Add(7);
            _ = testTree.Add(15);
            _ = testTree.Add(55);
            _ = testTree.Add(20);
            _ = testTree.Add(14);
            _ = testTree.Add(13);
            _ = testTree.Add(18);
            _ = testTree.Add(22);
            _ = testTree.Add(19);

            uint height = testTree.Height;

            Assert.Equal((uint)4, height);

            _ = testTree.Add(65);
            Assert.Equal((uint)4, height);
        }

        [Fact]
        public void Group9_Height_HeightOfScewedTreeTest()
        {
            BSTTree testTree = new();

            testTree.Add(1);
            testTree.Add(2);
            testTree.Add(3);
            testTree.Add(4);
            testTree.Add(5);
            testTree.Add(6);

            uint height = testTree.Height;

            Assert.Equal((uint)6, height);
        }
        #endregion
    }
}

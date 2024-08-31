using BST_Tree;

namespace BSTTreeXUnitTest
{
    public class BSTTreeTests
    {
        #region *************** BST creation ***************
        [Fact]
        public void CreateEmptyTreeTest()
        {
            BSTTree testTree = new();

            Assert.NotNull(testTree);
        }

        [Fact]
        public void CreateNonEmptyTreeTest()
        {
            BSTTree testTree = new(0);

            Assert.NotNull(testTree);
        }
        #endregion

        #region *************** Adding nodes ***************
        [Fact]
        public void AddNewNodeToEmptyTreeTest()
        {
            BSTTree testTree = new();

            bool res = testTree.Add(50);

            Assert.True(res);
            Assert.NotNull(testTree);
        }

        [Fact]
        public void AddNewNodeToNonEmptyTreeTest()
        {
            BSTTree testTree = new(0);

            bool res = testTree.Add(50);

            Assert.True(res);
            Assert.NotNull(testTree);
        }

        [Fact]
        public void AddSeveralNewNodesTest()
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
        }

        [Fact]
        public void AddSameNodeTest()
        {
            BSTTree testTree = new();

            _ = testTree.Add(50);
            _ = testTree.Add(10);
            _ = testTree.Add(60);
            _ = testTree.Add(7);
            _ = testTree.Add(11);
            _ = testTree.Add(55);
            _ = testTree.Add(20);

            bool res = testTree.Add(11);

            Assert.False(res);
        }
        #endregion

        #region *************** Deleting nodes ***************
        [Fact]
        public void DeleteNodeFromEmptyTreeTest()
        {
            BSTTree testTree = new();

            bool deletionResult = testTree.Delete(50);

            Assert.False(deletionResult);
            Assert.Equal((uint)0, testTree.Count);
            Assert.NotNull(testTree);
        }

        [Fact]
        public void DeleteNodeFromOneNodeTreeTest()
        {
            BSTTree testTree = new();

            _ = testTree.Add(50);

            bool deletionResult = testTree.Delete(50);

            Assert.True(deletionResult);
            Assert.Equal((uint)0, testTree.Count);
            Assert.NotNull(testTree);
        }

        [Fact]
        public void DeleteNonExistingNodeFromTreeTest()
        {
            BSTTree testTree = new();

            _ = testTree.Add(50);
            _ = testTree.Add(10);
            _ = testTree.Add(60);
            _ = testTree.Add(7);
            _ = testTree.Add(11);
            _ = testTree.Add(55);
            _ = testTree.Add(20);

            bool deletionResult = testTree.Delete(25);
            Assert.False(deletionResult);

            // The number of nodes should not change
            Assert.Equal((uint)7, testTree.Count);
        }

        [Fact]
        public void DeleteRootNodeFromTreeTest()
        {
            BSTTree testTree = new();

            _ = testTree.Add(50);
            _ = testTree.Add(10);
            _ = testTree.Add(60);
            _ = testTree.Add(7);
            _ = testTree.Add(11);
            _ = testTree.Add(55);
            _ = testTree.Add(20);

            bool deletionResult = testTree.Delete(50);

            Assert.True(deletionResult);
            Assert.NotNull(testTree);
            Assert.Equal((uint)6, testTree.Count);
            Assert.False(testTree.Contains(50));

            // The height of the tree should not change, as the "60" node will move to the root, so the left sub-tree and its height will remain as is
            Assert.Equal((uint)4, testTree.Height);
        }

        [Fact]
        public void DeleteNodeWithNoChildrenTest()
        {
            BSTTree testTree = new();

            _ = testTree.Add(50);
            _ = testTree.Add(10);
            _ = testTree.Add(60);
            _ = testTree.Add(7);
            _ = testTree.Add(11);
            _ = testTree.Add(55);
            _ = testTree.Add(20);

            bool deletionResults = testTree.Delete(20);

            Assert.True(deletionResults);
            Assert.NotNull(testTree);
            Assert.False(testTree.Contains(20));
            Assert.Equal((uint)6, testTree.Count);

            // The height of the tree should decrease by 1 from 4 to 3
            Assert.Equal((uint)3, testTree.Height);
        }

        [Fact]
        public void DelteNodeWithLeftNullChildAndRightChildTest()
        {
            BSTTree testTree = new();

            _ = testTree.Add(50);
            _ = testTree.Add(10);
            _ = testTree.Add(60);
            _ = testTree.Add(7);
            _ = testTree.Add(11);
            _ = testTree.Add(55);
            _ = testTree.Add(20);

            bool deletionResults = testTree.Delete(11);

            Assert.True(deletionResults);
            Assert.NotNull(testTree);
            Assert.False(testTree.Contains(11));
            Assert.Equal((uint)6, testTree.Count);

            // The height of the tree should decrease by 1 from 4 to 3
            Assert.Equal((uint)3, testTree.Height);
        }

        [Fact]
        public void DeleteNodeWithLeftChildAndNullRightChildTest()
        {
            BSTTree testTree = new();

            _ = testTree.Add(50);
            _ = testTree.Add(10);
            _ = testTree.Add(60);
            _ = testTree.Add(7);
            _ = testTree.Add(11);
            _ = testTree.Add(55);
            _ = testTree.Add(20);

            bool deletionResults = testTree.Delete(60);

            Assert.True(deletionResults);
            Assert.NotNull(testTree);
            Assert.False(testTree.Contains(60));
            Assert.Equal((uint)6, testTree.Count);

            // The height of the tree should decrease by 1 from 4 to 3
            Assert.Equal((uint)3, testTree.Height);
        }

        [Fact]
        public void DeleteNodeWithTwoChildrenTest()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void DeleteRootNodeWithTwoChildrenTest()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region *************** Maximum and Minimum values tests ***************
        [Fact]
        public void GetMinimumForEmptyTreeTest()
        {
            BSTTree testTree = new();

            Assert.Throws<InvalidOperationException>(() => testTree.GetMinimum());
        }

        [Fact]
        public void GetMinimumForOneNodeTreeTest()
        {
            BSTTree testTree = new();
            bool res = testTree.Add(50);

            int minimumValue = testTree.GetMinimum();

            Assert.Equal(50, minimumValue);
        }

        [Fact]
        public void GetMinimumForTreeTest()
        {
            BSTTree testTree = new();

            _ = testTree.Add(50);
            _ = testTree.Add(10);
            _ = testTree.Add(60);
            _ = testTree.Add(7);
            _ = testTree.Add(11);
            _ = testTree.Add(55);
            _ = testTree.Add(20);

            int minimumValue = testTree.GetMinimum();

            Assert.Equal(7, minimumValue);
        }

        [Fact]
        public void GetMaximumForEmptyTreeTest()
        {
            BSTTree testTree = new();

            Assert.Throws<InvalidOperationException>(() => testTree.GetMaximum());
        }

        [Fact]
        public void GetMaximumForOneNodeTreeTest()
        {
            BSTTree testTree = new();
            bool res = testTree.Add(50);

            int maximumValue = testTree.GetMaximum();

            Assert.Equal(50, maximumValue);
        }

        [Fact]
        public void GetMaximumForTreeTest()
        {
            BSTTree testTree = new();

            _ = testTree.Add(50);
            _ = testTree.Add(10);
            _ = testTree.Add(60);
            _ = testTree.Add(7);
            _ = testTree.Add(11);
            _ = testTree.Add(55);
            _ = testTree.Add(20);

            int maximumValue = testTree.GetMaximum();

            Assert.Equal(60, maximumValue);
        }

        #endregion

        #region *************** Contains tests ***************
        [Fact]
        public void ContainsForEmptyTreeTest()
        {
            BSTTree testTree = new();

            bool res = testTree.Contains(100);

            Assert.False(res);
        }

        [Fact]
        public void ContainsForExistingOneNodeTest()
        {
            BSTTree testTree = new(1);

            bool res = testTree.Contains(1);

            Assert.True(res);
        }

        [Fact]
        public void ContainsForNonExistingOneNodeTest()
        {
            BSTTree testTree = new(1);

            bool res = testTree.Contains(100);

            Assert.False(res);
        }

        [Fact]
        public void ContainsForExistingNodeTest()
        {
            BSTTree testTree = new();

            _ = testTree.Add(50);
            _ = testTree.Add(10);
            _ = testTree.Add(60);
            _ = testTree.Add(7);
            _ = testTree.Add(11);
            _ = testTree.Add(55);
            _ = testTree.Add(20);

            bool res = testTree.Contains(7);

            Assert.True(res);
        }

        [Fact]
        public void ContainsForNonExistingNodeTest()
        {
            BSTTree testTree = new();

            _ = testTree.Add(50);
            _ = testTree.Add(10);
            _ = testTree.Add(60);
            _ = testTree.Add(7);
            _ = testTree.Add(11);
            _ = testTree.Add(55);
            _ = testTree.Add(20);

            bool res = testTree.Contains(100);

            Assert.False(res);
        }
        #endregion

        #region *************** Count tests **********
        [Fact]
        public void CountForEmptyTreeTest()
        {
            BSTTree testTree = new();

            uint count = testTree.Count;

            Assert.Equal((uint)0, count);
        }

        [Fact]
        public void CountForOneNodeTreeTest()
        {
            BSTTree testTree = new();
            _ = testTree.Add(50);

            uint count = testTree.Count;

            Assert.Equal((uint)1, count);
        }

        [Fact]
        public void CountTreeTest()
        {
            BSTTree testTree = new();

            _ = testTree.Add(50);
            _ = testTree.Add(10);
            _ = testTree.Add(60);
            _ = testTree.Add(7);
            _ = testTree.Add(11);
            _ = testTree.Add(55);
            _ = testTree.Add(20);

            uint count = testTree.Count;

            Assert.Equal((uint)7, count);
        }
        #endregion

        #region *************** Clear tests **********
        [Fact]
        public void ClearMethodForEmptyListTest()
        {
            BSTTree testTree = new();

            testTree.Clear();

            Assert.NotNull(testTree);
            Assert.Equal((uint)0, testTree.Count);
        }

        [Fact]
        public void ClearMethodForNonEmptyListTest()
        {
            BSTTree testTree = new();

            _ = testTree.Add(50);
            _ = testTree.Add(10);
            _ = testTree.Add(60);
            _ = testTree.Add(7);
            _ = testTree.Add(11);
            _ = testTree.Add(55);
            _ = testTree.Add(20);

            testTree.Clear();

            Assert.NotNull(testTree);
            Assert.Equal((uint)0, testTree.Count);
        }
        #endregion

        #region *************** Print tests **********
        [Fact]
        public void PrintAscendingEmptyTreeTest()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void PrintAscendingTreeTest()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void PrintDescendingEmptyTreeTest()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void PrintDescendingTreeTest()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region *************** Height tests **********
        [Fact]
        public void HeightOfEmptyTreeTest()
        {
            BSTTree testTree = new();

            uint height = testTree.Height;

            Assert.Equal((uint)0, height);
        }

        [Fact]
        public void HeightOfOneNodeTreeTest()
        {
            BSTTree testTree = new();
            _ = testTree.Add(50);

            uint height = testTree.Height;

            Assert.Equal((uint)1, height);
        }

        [Fact]
        public void HeightOfTreeTest()
        {
            BSTTree testTree = new();

            _ = testTree.Add(50);
            _ = testTree.Add(10);
            _ = testTree.Add(60);
            _ = testTree.Add(7);
            _ = testTree.Add(11);
            _ = testTree.Add(55);
            _ = testTree.Add(20);

            uint height = testTree.Height;
            Assert.Equal((uint)4, height);
        }

        [Fact]
        public void DecreaseOfHeightAfterDeletingNodeTest()
        {
            BSTTree testTree = new();

            _ = testTree.Add(50);
            _ = testTree.Add(10);
            _ = testTree.Add(60);
            _ = testTree.Add(7);
            _ = testTree.Add(11);
            _ = testTree.Add(55);
            _ = testTree.Add(20);

            uint height = testTree.Height;
            Assert.Equal((uint)4, height);

            _ = testTree.Delete(11);
            height = testTree.Height;
            Assert.Equal((uint)4, height);
        }
        
        [Fact]
        public void NonDecreaseOfHeightAfterDeletingNodeTest()
        {
            BSTTree testTree = new();

            _ = testTree.Add(50);
            _ = testTree.Add(10);
            _ = testTree.Add(60);
            _ = testTree.Add(7);
            _ = testTree.Add(11);
            _ = testTree.Add(55);
            _ = testTree.Add(20);

            uint height = testTree.Height;
            Assert.Equal((uint)4, height);

            _ = testTree.Delete(60);
            height = testTree.Height;
            Assert.Equal((uint)4, height);
        }

        [Fact]
        public void IncreaseOfHeightAfterAddingNodeTest()
        {
            BSTTree testTree = new();

            _ = testTree.Add(50);
            _ = testTree.Add(10);
            _ = testTree.Add(60);
            _ = testTree.Add(7);
            _ = testTree.Add(11);
            _ = testTree.Add(55);
            _ = testTree.Add(20);

            uint height = testTree.Height;
            Assert.Equal((uint)4, height);

            _ = testTree.Add(25);
            height = testTree.Height;
            Assert.Equal((uint)5, height);
        }
        
        [Fact]
        public void NonIncreaseOfHeightAfterAddingNodeTest()
        {
            BSTTree testTree = new();

            _ = testTree.Add(50);
            _ = testTree.Add(10);
            _ = testTree.Add(60);
            _ = testTree.Add(7);
            _ = testTree.Add(11);
            _ = testTree.Add(55);
            _ = testTree.Add(20);

            uint height = testTree.Height;

            Assert.Equal((uint)4, height);

            _ = testTree.Add(65);
            Assert.Equal((uint)4, height);
        }

        [Fact]
        public void HeightOfScewedTreeTest()
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

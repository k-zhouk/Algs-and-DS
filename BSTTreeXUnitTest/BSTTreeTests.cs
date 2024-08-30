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
        public void DeleteNodeFromEmptyTree()
        {
            BSTTree testTree = new();

            bool deletionResult = testTree.Delete(50);

            Assert.False(deletionResult);
            Assert.Equal((uint)0, testTree.Count);
            Assert.NotNull(testTree);
        }

        [Fact]
        public void DeleteNodeFromOneNodeTree()
        {
            BSTTree testTree = new();

            _ = testTree.Add(50);

            bool deletionResult = testTree.Delete(50);

            Assert.True(deletionResult);
            Assert.Equal((uint)0, testTree.Count);
            Assert.NotNull(testTree);
        }

        [Fact]
        public void DeleteNonExistingNodeFromTree()
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
        public void DeleteRootNodeFromTree()
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
        public void DeleteNodeWithNoChildren()
        {
            BSTTree testTree = new();

            _ = testTree.Add(50);
            _ = testTree.Add(10);
            _ = testTree.Add(60);
            _ = testTree.Add(7);
            _ = testTree.Add(11);
            _ = testTree.Add(55);
            _ = testTree.Add(20);

            bool deletionResults= testTree.Delete(20);

            Assert.True(deletionResults);
            Assert.NotNull(testTree);
            Assert.Equal((uint)6, testTree.Count);
            Assert.False(testTree.Contains(20));

            // The height of the tree should decrease by 1 from 4 to 3
            Assert.Equal((uint)3, testTree.Height);
        }

        [Fact]
        public void DelteNodeWithLeftNullChildAndRightChild()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void DelteNodeWithLeftChildAndNullRightChild()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void DelteNodeWithTwoChildren()
        {
            throw new NotImplementedException();
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

        #region *************** Other tests **********
        [Fact]
        public void ClearMethodForEmptyList()
        {
            BSTTree testTree = new();

            testTree.Clear();

            Assert.NotNull(testTree);
            Assert.Equal((uint)0, testTree.Count);
        }

        [Fact]
        public void ClearMethodForNonEmptyList()
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
    }
}

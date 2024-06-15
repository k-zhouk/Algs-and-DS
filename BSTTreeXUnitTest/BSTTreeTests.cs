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
        public void ClearForEmptyList()
        {
            BSTTree testTree = new();

            testTree.Clear();

            Assert.NotNull(testTree);
            Assert.Equal((uint)0, testTree.Count);
        }
        
        [Fact]
        public void ClearForNonEmptyList()
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

using System;

namespace BST_Tree
{
    public class BSTTree
    {
        // Pointer to the root of the tree
        private BSTNode root;

        #region *************** Constructors ***************
        public BSTTree()
        {
            root = null;
        }

        public BSTTree(int value)
        {
            root = new BSTNode(value);
        }
        #endregion

        #region *************** Main methods ***************
        /// <summary>
        /// The method adds a new node to the tree
        /// </summary>
        /// <param name="newValue"></param>
        public bool Add(int newValue)
        {
            BSTNode newNode = new BSTNode(newValue);

            if (root == null)
            {
                root = newNode;
                return true;
            }

            BSTNode currentNode = root;
            while (!(currentNode is null))
            {
                if (newNode.Value < currentNode.Value)
                {
                    if (currentNode.LeftNode is null)
                    {
                        currentNode.LeftNode = newNode;
                        return true;
                    }
                    else currentNode = currentNode.LeftNode;
                }
                else if (newNode.Value > currentNode.Value)
                {
                    if (currentNode.RightNode is null)
                    {
                        currentNode.RightNode = newNode;
                        return true;
                    }
                    else currentNode = currentNode.RightNode;
                }
                // Break if the value is already in the tree
                else if (currentNode.Value == newNode.Value) break;
            }

            return false;
        }

        /// <summary>
        /// The method deletes a node. Returns true if a node has been deleted
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Returns true if a node was deleted</returns>
        public bool Delete(int value)
        {
            // Case 1: the tree is empty
            if (root is null)
            {
                return false;
            }

            // Case 2: deleting the root
            if (root.Value == value)
            {
                root = null;
                return true;
            }

            BSTNode topNode = null;
            BSTNode currentNode = root;

            while (!(currentNode is null))
            {
                // Case 3: deleting a node with no children
                if ((currentNode.LeftNode is null) && (currentNode.RightNode is null))
                {

                }
                // Case 4: deleting a ...
                // Case 5: deleting a ...
            }

            return false;
        }

        /// <summary>
        /// The method returns true if the node is in the tree and false otherwise
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Returns true, if a value is in the tree</returns>
        public bool Contains(int value)
        {
            // Start search from the root node
            BSTNode currentNode = root;
            while (currentNode != null)
            {
                if (currentNode.Value == value)
                {
                    return true;
                }
                else
                {
                    if (value < currentNode.Value)
                    {
                        currentNode = currentNode.LeftNode;
                    }
                    else currentNode = currentNode.RightNode;
                }
            }
            return false;
        }

        /// <summary>
        /// Method finds a node with the minimum value
        /// </summary>
        /// <returns>Minmum value as an integer</returns>
        public int GetMinimum()
        {
            BSTNode currentNode = root;

            // Case 1: The tree is empty
            if (root is null)
            {
                throw new InvalidOperationException("The tree is empty and doesn't contain any nodes");
            }
            
            // Case 2: The tree has only a root node
            if ((root.LeftNode is null) && (root.RightNode is null))
            {
                return root.Value;
            }

            // Case 3: The tree has more than 1 node
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method returns a node with the maximum value
        /// </summary>
        /// <returns>Maximum value as an integer</returns>
        public int GetMaximum()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The method clears the tree
        /// </summary>
        public void Clear()
        {
            root = null;
        }
        #endregion

        #region *************** Other methods ***************
        /// <summary>
        /// The method prints the content of the tree in the ascending order
        /// </summary>
        public void PrintAscending()
        {
            BSTNode currentNode = root;

            Travers(currentNode);

            void Travers(BSTNode node)
            {
                if ((currentNode.LeftNode is null) && currentNode.RightNode is null)
                {
                    Console.Write(currentNode.Value + " ");
                    return;
                }
                else if (currentNode.LeftNode is null)
                {
                    currentNode = currentNode.RightNode;
                }
                else
                {
                    currentNode = currentNode.LeftNode;
                }
                Travers(currentNode);
            }
            // throw new NotImplementedException();
        }

        /// <summary>
        /// The method prints the content of the tree in the descending order
        /// </summary>
        public void PrintDescending()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region *************** Tree properties ***************
        // The readonly property contains the number of elements in the tree.
        private uint _count = 0;
        public uint Count
        {
            get
            {
                _count = 0;
                GetCount(root);
                return _count;
            }
        }

        // The read-only property contains the height of the tree
        public uint Height
        {
            get => GetHeigh();
        }
        #endregion

        #region *************** Private methods ***************
        /// <summary>
        /// Method returns number of items in the tree. The number of nodes is counted by traversing the tree
        /// </summary>
        /// <param name="node"></param>
        private void GetCount(BSTNode node)
        {
            if (node is null)
            {
                return;
                // Every time we visit a node that is not null, we increase the private _count variable (extrnal to the method)
            }
            else _count++;

            GetCount(node.LeftNode);
            GetCount(node.RightNode);

            return;
        }

        /// <summary>
        /// The method returns the height of the tree
        /// </summary>
        /// <returns>Returns the height of the tree as an uint number</returns>
        private uint GetHeigh()
        {
            uint height = 0;
            throw new NotImplementedException();
        }
        #endregion

        #region *************** BST Node class ***************
        // For now the class is working with int numbers only
        class BSTNode
        {
            // Constructor
            public BSTNode(int value)
            {
                Value = value;
            }

            public int Value { get; set; }

            public BSTNode LeftNode { get; set; }
            public BSTNode RightNode { get; set; }
        }
        #endregion
    }
}

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
            _count = 1;
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
                _count++;
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
                        _count++;
                        return true;
                    }
                    else currentNode = currentNode.LeftNode;
                }
                else if (newNode.Value > currentNode.Value)
                {
                    if (currentNode.RightNode is null)
                    {
                        currentNode.RightNode = newNode;
                        _count++;
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
            // The tree is empty, there is nothing to delete
            if (root is null)
            {
                return false;
            }

            BSTNode parentNode = root;
            BSTNode currentNode = root;

            // Looking for a node with the value specified and its parent
            while (currentNode.Value != value)
            {
                parentNode = currentNode;

                if (value > currentNode.Value)
                {
                    currentNode = currentNode.RightNode;
                }
                else
                {
                    currentNode = currentNode.LeftNode;
                }

                // The currentNode becomes null in case a value provided is not in the tree
                if (currentNode is null)
                {
                    return false;
                }
            }

            // Case 1: Deleting a node with no children
            if ((currentNode.LeftNode is null) && (currentNode.RightNode is null))
            {
                // The parentNode and currentNode are equal is the root ie being deleted
                if (parentNode == currentNode)
                {
                    root = null;
                }
                else
                {
                    if (parentNode.LeftNode == currentNode)
                    {
                        parentNode.LeftNode = null;
                    }
                    else
                    {
                        parentNode.RightNode = null;
                    }
                }

                _count--;
                return true;
            }

            // Case 2: Deleting a node with 1 child only
            if (!(currentNode.LeftNode is null) && (currentNode.RightNode is null))
            {
                // parentNode is equal to currentNode if the root is being deleted
                if (parentNode == currentNode)
                {
                    root = parentNode.LeftNode;
                }

                if (parentNode.LeftNode == currentNode)
                {
                    parentNode.LeftNode = currentNode.LeftNode;
                }

                if (parentNode.RightNode == currentNode)
                {
                    parentNode.RightNode = currentNode.LeftNode;
                }

                _count--;
                return true;
            }

            if ((currentNode.LeftNode is null) && !(currentNode.RightNode is null))
            {
                // parentNode is equal to currentNode if the root is being deleted
                if (parentNode == currentNode)
                {
                    root = parentNode.RightNode;
                }

                if (parentNode.LeftNode == currentNode)
                {
                    parentNode.LeftNode = currentNode.RightNode;
                }

                if (parentNode.LeftNode == currentNode)
                {
                    parentNode.RightNode = currentNode.RightNode;
                }

                _count--;
                return true;
            }

            // Case 3: Deleting a node with 2 children
            if (!(currentNode.LeftNode is null) || !(currentNode.RightNode is null))
            {
                BSTNode minNode = FindMinNode(currentNode.RightNode);
                int minNodeValue = minNode.Value;
                BSTNode minNodeRightChild = minNode.RightNode;

                // Looking for a parent node of a minimum node
                BSTNode parentMinNode = null;
                BSTNode tmpNode = currentNode;

                // Looking for a parent of the MinimumNode
                while (tmpNode.Value != minNodeValue)
                {
                    if (minNodeValue > tmpNode.Value)
                    {
                        parentMinNode = tmpNode;
                        tmpNode = tmpNode.RightNode;
                    }
                    else
                    {
                        parentMinNode = tmpNode;
                        tmpNode = tmpNode.LeftNode;
                    }
                }

                // Now we have all necessary information to delete a node

                // Step 1: Point left child of Min Node's parent to the Min Node's right child
                parentMinNode.LeftNode = minNodeRightChild;

                // Step 2: Setup left and right children of the minimum node to the children of the node being deleted
                minNode.LeftNode = currentNode.LeftNode;
                minNode.RightNode = currentNode.RightNode;

                // Step 3: Replace a node of the parent node with the Min node
                // Check if we are deleting the root node. In this case we will not have the parent node
                if (root.Value == value)
                {
                    root = minNode;
                }
                else // else we are deleting non-root node
                {
                    if (parentNode.LeftNode.Value == value)
                    {
                        parentNode.LeftNode = minNode;
                    }
                    else parentNode.RightNode = minNode;
                }

                // Adjust the nodes counter and return
                _count--;
                return true;
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
        /// Private method resturns minimum for a given subtree
        /// </summary>
        /// <param name="startNode">Node to start with</param>
        /// <returns></returns>
        private BSTNode FindMinNode(BSTNode startNode)
        {
            // Case 1: the subtree is empty
            if (startNode is null)
            {
                throw new ArgumentNullException("The subtree is empty and doesn't contain any nodes");
            }

            // Case 2: The subtree has more than one node
            BSTNode currentNode = startNode;

            while (!(currentNode.LeftNode is null))
            {
                currentNode = currentNode.LeftNode;
            }

            return currentNode;
        }

        /// <summary>
        /// Method finds a node with the minimum value
        /// </summary>
        /// <returns>Minmum value as an integer</returns>
        /// <exception cref="InvalidOperationException">Exception is thrown if the tree is empty</exception>
        public int GetMinimum()
        {
            return FindMinNode(root).Value;
        }

        private int GetMaximumForSubtree(BSTNode startNode)
        {
            // Case 1: The subtree is empty
            if (startNode is null)
            {
                throw new ArgumentNullException("The tree is empty and doesn't contain any nodes");
            }

            // Case 2: The subtree has more than 1 node
            BSTNode currentNode = startNode;

            while (!(currentNode.RightNode is null))
            {
                currentNode = currentNode.RightNode;
            }

            return currentNode.Value;
        }

        // Should not be public. Used for unit tests
        public int? FindParentNode(int value)
        {
            BSTNode parentNode = null;
            BSTNode currentNode = root;

            while (currentNode.Value != value)
            {
                if (value < currentNode.Value)
                {
                    parentNode = currentNode;
                    currentNode = currentNode.LeftNode;
                }
                else
                {
                    parentNode = currentNode;
                    currentNode = currentNode.RightNode;
                }
            }

            if (parentNode is null)
            {
                return null;
            }
            else
            {
                return parentNode.Value;
            }
        }

        /// <summary>
        /// Method returns a node with the maximum value
        /// </summary>
        /// <returns>Maximum value as an integer</returns>
        /// <exception cref="InvalidOperationException">Exception is thrown if the tree is empty</exception>
        public int GetMaximum()
        {
            return GetMaximumForSubtree(root);
        }

        /// <summary>
        /// The method clears the tree
        /// </summary>
        public void Clear()
        {
            root = null;
            _count = 0;
        }
        #endregion

        #region *************** Other methods ***************
        /// <summary>
        /// The method prints the content of the tree in the ascending order
        /// </summary>
        public void PrintAscending()
        {
            if (root is null)
            {
                Console.WriteLine("The tree is empty");
                return;
            }

            BSTNode currentNode = root;

            Travers(currentNode);

            // Internal function here, because it's a recursion function
            void Travers(BSTNode node)
            {
                if (node is null)
                {
                    return;
                }
                Travers(node.LeftNode);
                Console.Write(node.Value + " ");
                Travers(node.RightNode);
            }
            // throw new NotImplementedException();
        }

        /// <summary>
        /// The method prints the content of the tree in the descending order
        /// </summary>
        public void PrintDescending()
        {
            if (root is null)
            {
                Console.WriteLine("The tree is empty");
                return;
            }

            BSTNode currentNode = root;

            Traverse(currentNode);

            void Traverse(BSTNode node)
            {
                if (node is null)
                {
                    return;
                }

                Traverse(node.RightNode);
                Console.Write(node.Value + " ");
                Traverse(node.LeftNode);
            }
        }
        #endregion

        #region *************** Tree properties ***************
        // The readonly property contains the number of elements in the tree
        private uint _count = 0;
        public uint Count
        {
            get => _count;
        }

        // The read-only property contains the height of the tree
        public uint Height
        {
            get => GetHeigh();
        }
        #endregion

        #region *************** Private methods ***************

        /// <summary>
        /// The method returns the height of the tree
        /// </summary>
        /// <returns>Returns the height of the tree as an uint number</returns>
        private uint GetHeigh()
        {
            if (_count == 0)
            {
                return 0;
            }

            throw new NotImplementedException();
        }
        #endregion

        #region *************** Internal BST Node class ***************
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

﻿using System;

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

            BSTNode parentNode = null;
            BSTNode currentNode = root;

            // Looking for a specified value
            while (currentNode.Value != value)
            {
                if (value > currentNode.Value)
                {
                    parentNode = currentNode;
                    currentNode = currentNode.RightNode;
                }
                else
                {
                    parentNode = currentNode;
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
                if (parentNode.LeftNode == currentNode)
                {
                    parentNode.LeftNode = null;
                }
                else
                {
                    parentNode.RightNode = null;
                }
                _count--;

                return true;
            }

            // Case 2: Deleting a node with 1 child- No LEFT child
            if ((currentNode.LeftNode is null) && !(currentNode.RightNode is null))
            {
                parentNode.RightNode = currentNode.RightNode;
                _count--;

                return true;
            }
            // Case 3: Deleting a node with 1 child- No RIGHT child
            if (!(currentNode.LeftNode is null) && (currentNode.RightNode is null))
            {
                parentNode.RightNode = currentNode.LeftNode;
                _count--;

                return true;
            }

            // Case 4: Deleting a node with 2 children


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
        private int GetMinimumForSubtree(BSTNode startNode)
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

            return currentNode.Value;
        }

        /// <summary>
        /// Method finds a node with the minimum value
        /// </summary>
        /// <returns>Minmum value as an integer</returns>
        /// <exception cref="InvalidOperationException">Exception is thrown if the tree is empty</exception>
        public int GetMinimum()
        {
            return GetMinimumForSubtree(root);
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

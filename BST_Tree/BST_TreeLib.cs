using System;

namespace BST_Tree
{
    class BST_Tree
    {
        private BST_Node root;
        // Constructors
        public BST_Tree(BST_Node node)
        {
            root = node;
        }

        public BST_Tree()
        {
            root = null;
        }

        // Node to store a current node
        private BST_Node currentNode = default;
        // Node to store a parent node in the Find method
        private BST_Node parentNode = default;

        #region Main BST methods
        public void Add(BST_Node newNode)
        {
            if (root == null)
            {
                root = newNode;
                return;
            }

            currentNode = root;
            while (!(currentNode is null))
            {
                if (newNode.value < currentNode.value)
                {
                    if (currentNode.LeftNode is null)
                    {
                        currentNode.LeftNode = newNode;
                        return;
                    }
                    else currentNode = currentNode.LeftNode;
                }
                else if (newNode.value > currentNode.value)
                {
                    if (currentNode.RightNode is null)
                    {
                        currentNode.RightNode = newNode;
                        return;
                    }
                    else currentNode = currentNode.RightNode;
                }

                // Break if the value is already in the tree
                else if (currentNode.value == newNode.value) break;
            }
        }

        // Returns true if the node with the value specified is in the tree and false otherwise
        public bool CheckPresense(BST_Node node)
        {
            // Start search from the root node
            currentNode = root;
            while (currentNode != null)
            {
                if (currentNode.value == node.value)
                {
                    return true;
                }
                else
                {
                    if (node.value < currentNode.value)
                    {
                        currentNode = currentNode.LeftNode;
                    }
                    else currentNode = currentNode.RightNode;
                }
            }
            return false;
        }

        // Method clears the tree
        public void Clear()
        {
            root = null;
        }

        // Method deletes a node and its left and right subtrees. If a node is not in the tree, the method returns false and true otherwise
        public bool DeleteSubtree(BST_Node node)
        {
            // Case 1: the tree is empty
            if (root is null)
            {
                return false;
            }

            // Case 2: the root is deleted
            if (root.value == node.value)
            {
                root = null;
                return true;
            }

            // Case 3: some node is deleted
            bool isRight = false;
            parentNode = null;
            currentNode = root;

            while (!(currentNode is null))
            {
                if (currentNode.value == node.value) break;

                parentNode = currentNode;
                if (node.value < currentNode.value)
                {
                    currentNode = currentNode.LeftNode;
                    isRight = false;
                }
                else
                {
                    currentNode = currentNode.RightNode;
                    isRight = true;
                }
            }

            if (isRight)
            {
                parentNode.RightNode = null;
            }
            else parentNode.LeftNode = null;

            return true;
        }

        // Method deletes a specific node
        public void DeleteNode(BST_Node node)
        {
            // Start search from the root node
            currentNode = root;

            // Node to track the part node
            parentNode = currentNode;

            while (currentNode != null)
            {
                if (currentNode.value == node.value)
                {
                    // Case 3: node to be deleted has no children
                    if (currentNode.LeftNode is null & currentNode.RightNode is null)
                    {
                        return;
                    }
                }
                else
                {
                    parentNode = currentNode;
                    if (node.value < currentNode.value)
                    {
                        currentNode = currentNode.LeftNode;
                    }
                    else currentNode = currentNode.RightNode;
                }
            }
        }
        #endregion

        #region Main BST properties
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
        
        // Method returns number of items in the tree by traversal
        private void GetCount(BST_Node node)
        {
            if (node is null)
            {
                return;
            // Every time we visit a node that is not null, we increase the private _count counter
            } else _count++;
            
            GetCount(node.LeftNode);
            GetCount(node.RightNode);

            return;
        }

        // The property returns the height of the tree
        public uint Height
        {
            get => GetHeigh();
        }

        // Method returns the height of the tree
        private uint GetHeigh()
        {
            uint height = 0;
            throw new NotImplementedException();
        }
        #endregion

        #region Support methods
        public void Print()
        {
            throw new NotImplementedException();
        }
        #endregion
    }

    class BST_Node
    {
        public BST_Node(int value)
        {
            this.value = value;
        }

        public int value;

        // public BST_Node ParentNode { get; set; }
        public BST_Node LeftNode { get; set; }
        public BST_Node RightNode { get; set; }
    }

}

using System;

namespace BST_Tree
{
    class BST_Tree
    {
        // Pointer to the root of the tree
        private BST_Node root;

        #region Constructors
        public BST_Tree()
        {
            root = null;
        }

        public BST_Tree(int value)
        {
            root= new BST_Node(value);
        }
        #endregion

        #region Main BST methods
        // Method adds a new node to the tree
        public void Add(int newValue)
        {
            BST_Node newNode = new BST_Node(newValue);

            if (root == null)
            {
                root = newNode;
                return;
            }

            BST_Node currentNode = root;
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
        public bool CheckPresense(int value)
        {
            BST_Node node = new BST_Node(value);
            // Start search from the root node
            BST_Node currentNode = root;
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

        // Method deletes a node with its subtrees. If a node to be deleted is not in the tree, the method returns false and true otherwise
        public bool DeleteSubtree(int value)
        {
            BST_Node node = new BST_Node(value);
            // Case 1: the tree is empty
            if (root is null)
            {
                return false;
            }

            // Case 2: the root is being deleted
            if (root.value == node.value)
            {
                root = null;
                return true;
            }

            // Case 3: some random node is deleted
            bool isRight = false;
            BST_Node parentNode = null;
            BST_Node currentNode = root;

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
        public void DeleteNode(int value)
        {
            throw new NotImplementedException();

            BST_Node node = new BST_Node(value);

            // Start search from the root node
            BST_Node currentNode = root;

            // Node to track the parent node
            BST_Node parentNode = currentNode;

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

        #region Main tree properties
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
        
        // Method returns number of items in the tree
        // The number of the items is counted by traversing the tree
        private void GetCount(BST_Node node)
        {
            if (node is null)
            {
                return;
            // Every time we visit a node that is not null, we increase the private _count variable (extrnal to the method)
            } else _count++;
            
            GetCount(node.LeftNode);
            GetCount(node.RightNode);

            return;
        }

        // The read-only property contains the height of the tree
        public uint Height
        {
            get => GetHeigh();
        }

        // Method returns the height of the tree
        private uint GetHeigh()
        {
            uint height = 0;
            throw new NotImplementedException();

            return height;
        }
        #endregion

        #region Support methods

        // Method prints the content of the tree
        public void Print()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region BST Node class implementation
        // For now the class is working with int numbers only
        class BST_Node
        {
            // Constructor
            public BST_Node(int value)
            {
                this.value = value;
            }

            public int value;

            public BST_Node LeftNode { get; set; }
            public BST_Node RightNode { get; set; }
        }
        #endregion
    }
}

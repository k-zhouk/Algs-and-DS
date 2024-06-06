using System;

namespace SortedLinkedList
{
    class SortedLinkedList
    {
        private Node head, tail;

        #region *************** Constructors ***************
        public SortedLinkedList()
        {
            head = tail = null;
            _nodesCounter = 0;
        }

        public SortedLinkedList(int value)
        {
            Node node = new Node(value);
            head = tail = node;

            _nodesCounter = 1;
        }
        #endregion

        /// <summary>
        /// The method inserts a node in the sorted list into a proper position
        /// </summary>
        /// <param name="value"></param>
        public void AddNode(int value)
        {
            Node node = new Node(value);

            // Case 1: the list is empty
            if (head is null)
            {
                head = tail = node;
                _nodesCounter = 1;
            }

            Node currentNode = head;

            while(currentNode != null)
            {
                if(currentNode.Value == value)
                {
                    node.nextNode = currentNode.nextNode;
                }
            }
        }

        public void DeleteFirstNode()
        {
            // Empty list
            if (head is null)
            {
                return;
            }

            // List with one node
            if (head.nextNode is null)
            {
                head = tail = null;
            }
            else
            {
                head = head.nextNode;
            }
            _nodesCounter--;
        }

        public void DeleteLastNode()
        {
            // Nothing to delete, if the list is empty
            if (head is null)
            {
                return;
            }

            // One node list
            if (head.nextNode is null)
            {
                head = tail = null;
                _nodesCounter--;
                return;
            }

            if (!(tail is null))
            {
                Node currentNode = head;
                while (currentNode.nextNode != tail)
                {
                    currentNode = currentNode.nextNode;
                }
                currentNode.nextNode = null;
                tail = currentNode;
                _nodesCounter--;
            }
        }

        /// <summary>
        /// The method removes a node from the sorted list
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool DeleteNode(int value)
        {
            return false;
        }

        #region ********** Other list methods **********
        /// <summary>
        /// The method prints the values of the list if it's not empty
        /// </summary>
        public void PrintList()
        {
            Node currentNode = head;
            while (!(currentNode is null))
            {
                if (currentNode.nextNode is null)
                {
                    Console.Write(currentNode.Value);
                }
                else
                {
                    Console.Write(currentNode.Value + " ");
                }
                currentNode = currentNode.nextNode;
            }
        }

        /// <summary>
        /// The method returns true if a value is in the list and false otherwise
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(int value)
        {
            Node currentNode = head;
            while (!(currentNode is null))
            {
                if (currentNode.Value == value)
                {
                    return true;
                }
                else
                {
                    currentNode = currentNode.nextNode;
                }
            }
            return false;
        }
        #endregion

        #region *************** Class properties ***************
        /// <summary>
        /// The read-only property returns a number of nodes in the list
        /// </summary>
        public int Count
        {
            get => _nodesCounter;
        }
        private int _nodesCounter;

        /// <summary>
        /// The read-only property returns the value of the head node, it could be a number or a null, if the list is empty
        /// </summary>
        /// <returns></returns>
        public int? HeadValue
        {
            get => head?.Value;
        }

        /// <summary>
        /// The read-only property returns the value of the tail node, it could be a number or a null, if the list is empty
        /// </summary>
        public int? TailValue
        {
            get => tail?.Value;
        }

        #endregion

        class Node
        {
            public Node() { }

            public Node(int value)
            {
                Value = value;
                nextNode = null;
            }

            public int Value { get; set; }
            public Node nextNode;
        }
    }
}

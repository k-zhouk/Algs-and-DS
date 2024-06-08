using System;

namespace SortedLinkedListNameSpace
{
    public class SortedLinkedList
    {
        private Node head;

        #region *************** Constructors ***************
        public SortedLinkedList()
        {
            head = null;
            _nodesCounter = 0;
        }

        public SortedLinkedList(int value)
        {
            Node node = new Node(value);
            head = node;

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
                head = node;
                _nodesCounter = 1;
                return;
            }

            // Case 2: 1 node list
            if(head.nextNode is null)
            {
                if (value >= head.Value)
                {
                    head.nextNode = node;
                    _nodesCounter++;
                    return;
                }
                else
                {
                    node.nextNode = head;
                    head = node;
                    _nodesCounter++;
                    return;
                }
            }

            // Case 3: more than 2 nodes
            Node currentNode = head.nextNode;
            Node previousNode = head;

            while (!(currentNode is null))
            {
                if (value < currentNode.Value)
                {
                    currentNode = currentNode.nextNode;
                    previousNode = currentNode;
                }
                else
                {
                    node.nextNode = currentNode;
                    previousNode.nextNode = node;
                    previousNode = node;
                    _nodesCounter++;
                    return;
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
                head = null;
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
                head = null;
                _nodesCounter--;
                return;
            }

            Node currentNode = head;
            while (!(currentNode.nextNode is null))
            {
                currentNode = currentNode.nextNode;
            }
            currentNode.nextNode = null;
            _nodesCounter--;
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

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
            // In this case the head points to the newly created node
            if (head is null)
            {
                head = node;
                _nodesCounter = 1;
                return;
            }

            // Case 2: non-empty list
            // The head is pointing to the lowest value always, so if we get a new value that is equal or lower,
            // we add it to the left and move the head pointer
            if (value <= head.Value)
            {
                node.nextNode = head;
                head = node;
                _nodesCounter++;
                return;
            }

            Node currentNode = head;
            Node previousNode = null;

            while (!(currentNode is null))
            {
                // Case A: we reached the final node, so we add a new node to the end of the list
                if ((value > currentNode.Value) && (currentNode.nextNode is null))
                {
                    currentNode.nextNode = node;
                    _nodesCounter++;
                    return;
                }

                // Case B: we are somewhere in the list and the new node is less than or equal the current node
                if (value <= currentNode.Value)
                {
                    node.nextNode = currentNode;
                    previousNode.nextNode = node;
                    _nodesCounter++;
                    return;
                }

                previousNode = currentNode;
                currentNode = currentNode.nextNode;
            }
        }

        public bool DeleteFirstNode()
        {
            // Case 1: Empty list
            if (head is null)
            {
                return false;
            }

            // Case 2: List with one node
            if (head.nextNode is null)
            {
                head = null;
            }
            // Case 3: List with several nodes
            else
            {
                head = head.nextNode;
            }
            _nodesCounter--;
            return true;
        }

        public bool DeleteLastNode()
        {
            // Case 1: Nothing to delete, if the list is empty
            if (head is null)
            {
                return false;
            }

            // Case 2: One node list
            if (head.nextNode is null)
            {
                head = null;
                _nodesCounter--;
                return true;
            }

            // Case 3: list with several nodes
            Node currentNode = head;
            Node previousNode = null;

            while (!(currentNode is null))
            {
                if (currentNode.nextNode is null)
                {
                    previousNode.nextNode = null;
                    _nodesCounter--;
                    return true;
                }
                previousNode = currentNode;
                currentNode = currentNode.nextNode;
            }

            return false;
        }

        /// <summary>
        /// The method deletes a node from the sorted list
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool DeleteNode(int value)
        {
            // Case 1: empty list
            if (head is null)
            {
                return false;
            }

            // Case 2: Delete the head of a one node list
            if (head.nextNode is null)
            {
                if (value == head.Value)
                {
                    head = null;
                    _nodesCounter--;
                    return true;
                }
            }

            // Case 3: Deletion from a non-empty list
            // Start from the 2nd node
            Node currentNode = head;
            Node previousNode = null;

            while (!(currentNode is null))
            {
                if ((value == currentNode.Value) && (previousNode is null))
                {
                    head = head.nextNode;
                    _nodesCounter--;
                    return true;
                }

                if ((value== currentNode.Value) && !(previousNode is null))
                {
                    previousNode.nextNode = currentNode.nextNode;
                    _nodesCounter--;
                    return true;
                }
                previousNode = currentNode;
                currentNode = currentNode.nextNode;
            }
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

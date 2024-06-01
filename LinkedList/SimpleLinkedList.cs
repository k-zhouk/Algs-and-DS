using System;

namespace LinkedList
{
    /// <summary>
    /// This class implements a singly linked list
    /// </summary>
    public class SimpleLinkedList
    {
        private Node head, tail;

        #region ********** Constructors **********
        public SimpleLinkedList()
        {
            head = tail = null;
        }

        public SimpleLinkedList(int value)
        {
            Node node = new Node(value);
            _nodesCounter = 1;
            head = tail = node;
        }
        #endregion

        #region ********** Adding elements **********
        public void AddFirst(int value)
        {
            Node node = new Node(value);
            if (head is null)
            {
                head = tail = node;
            }
            else
            {
                node.nextNode = head;
                head = node;
            }
            _nodesCounter++;
        }

        public void AddLast(int value)
        {
            Node node = new Node(value);
            if (head is null)
            {
                head = tail = node;
            }
            else
            {
                tail.nextNode = node;
                tail = node;
            }
            _nodesCounter++;
        }

        public void AddBefore(int newValue, int value)
        {
            if (head is null)
            {
                return;
            }

            Node node = new Node(newValue);

            Node currentNode = head.nextNode;
            Node previousNode = head;
            while (currentNode != null)
            {
                if (currentNode.Value == value)
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

        public void AddAfter(int newValue, int value)
        {
            if (head is null)
            {
                return;
            }

            Node node = new Node(newValue);

            Node currentNode = head;
            while (currentNode != null)
            {
                if (currentNode.Value == value)
                {
                    node.nextNode = currentNode.nextNode;
                    currentNode.nextNode = node;
                    
                    if (currentNode == tail)
                    {
                        tail = node;
                    }

                    _nodesCounter++;
                    return;
                }
                currentNode = currentNode.nextNode;
            }
        }
        #endregion

        #region ********** Deleting elements **********
        public void DeleteFirstNode()
        {
            if (head is null)
            {
                return;
            }
            else
            {
                head=head.nextNode;
                _nodesCounter--;
            }
        }

        public void DeleteLastNode()
        {


            if (tail != null)
            {
                Node currentNode = new Node();
                currentNode = head;
                while (currentNode.nextNode != tail)
                {
                    currentNode = currentNode.nextNode;
                }
                currentNode.nextNode = null;
                tail = currentNode;
                _nodesCounter--;
            }
            else
            {
                Console.WriteLine("The linked list is empty. Nothing to delete");
            }
        }

        /// <summary>
        /// The method returns deletes a node before a specified one and returns true, if
        /// the node has been deleted. Otherwise it returns false
        /// </summary>
        /// <param name="refNode"></param>
        /// <returns></returns>
        public bool DeleteBefore(int value)
        {
            Node node = new Node(value);

            // Check if the list is empty
            if (head == null)
            {
                Console.WriteLine("The list is empty. Nothing to delete");
                return false;
            }
            // Check if the reference node is the first node
            else if (head.Value == node.Value)
            {
                Console.WriteLine("This is the first node. Deletion is not possible");
                return false;
            }
            // Check if the 2nd node is our node
            else if (head.nextNode.Value == node.Value)
            {
                DeleteFirstNode();
                _nodesCounter--;
                return true;
            }
            else
            {
                // We start search from the 2nd node.
                Node prevNode = head;
                Node currentNode = head.nextNode;

                while (currentNode != null)
                {
                    if (currentNode.Value == node.Value)
                    {
                        Node newCurrentNode = head;
                        while (newCurrentNode.nextNode.Value != prevNode.Value)
                        {
                            newCurrentNode = newCurrentNode.nextNode;
                        }
                        newCurrentNode.nextNode = currentNode;
                        _nodesCounter--;
                        return true;
                    }
                    prevNode = currentNode;
                    currentNode = currentNode.nextNode;
                }
            }
            return false;
        }
        public bool DeleteAfter(int value)
        {
            Node node = new Node(value);
            if (_nodesCounter == 0)
            {
                Console.WriteLine("The list is empty. Nothing to delete");
                return false;
            }
            // Check if our node is the last one
            else if (tail.Value == node.Value)
            {
                Console.WriteLine("This is the last node. Node possible to delete.");
                return false;
            }
            else
            {
                Node currentNode = head;
                while (currentNode != null)
                {
                    if (currentNode.Value == node.Value)
                    {
                        if (currentNode.nextNode.nextNode == null)
                        {
                            DeleteLastNode();
                            _nodesCounter--;
                            return true;
                        }
                        else
                        {
                            currentNode.nextNode = currentNode.nextNode.nextNode;
                            _nodesCounter--;
                            return true;
                        }
                    }
                    currentNode = currentNode.nextNode;
                }
            }
            return false;
        }

        public void DeleteFirstOccurrence()
        {
            throw new NotImplementedException("The DeleteFirstOccurrence() method is not implemented yet");
        }

        public void DeleteAllOccurrences()
        {
            throw new NotImplementedException("The DeleteAllOccurrences() method is not implemented yet");
        }

        /// <summary>
        /// The method clears the list
        /// </summary>
        public void Clear()
        {
            head = tail = null;
            _nodesCounter = 0;
        }
        #endregion

        #region ********** Other list methods **********
        /// <summary>
        /// The method prints the values of the list if it's not empty
        /// </summary>
        public void PrintList()
        {
            Node currentNode = head;
            while (currentNode != null)
            {
                Console.Write(" " + currentNode.Value);
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
            while (currentNode != null)
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

        #region ********** Properties **********
        /// <summary>
        /// The read-only property returns a number of nodes in the list
        /// </summary>
        public uint Count
        {
            get => _nodesCounter;
        }
        private uint _nodesCounter;

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

        /// <summary>
        /// The internal Node class implements a linked list node.
        /// The node contains a value and a link to the next node.
        /// </summary>
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

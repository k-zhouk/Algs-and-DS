using System;

namespace LinkedList
{
    /// <summary>
    /// The Node class implements a linked list node.
    /// The node contains a value and a link to the next node.
    /// </summary>
    sealed class Node
    {
        public int value;
        public Node nextNode;

        #region Constructors
        public Node()
        {
            value = default;
            nextNode = null;
        }

        public Node(int value)
        {
            this.value = value;
            nextNode = null;
        }
        #endregion
    }

    /// <summary>
    /// This class implements a singly linked list or just a linked list
    /// </summary>
    class LinkedList
    {
        private int nodesCounter = 0;
        private Node head, tail;

        #region ********** Constructors **********
        public LinkedList()
        {
            head = tail = null;
        }
        public LinkedList(Node node)
        {
            nodesCounter = 1;
            head = tail = node;
        }
        #endregion

        #region ********** Adding elements **********
        public void AddFirst(Node node)
        {
            if (head == null)
            {
                head = tail = node;
            }
            else
            {
                node.nextNode = head;
                head = node;
            }
            nodesCounter++;
        } // end of AddFirst
        public void AddLast(Node node)
        {
            if (head == null)
            {
                head = tail = node;
            }
            else
            {
                tail.nextNode = node;
                tail = node;
            }
            nodesCounter++;
        } // end of AddLast
        public void AddBefore(Node beforeNode, Node node)
        {
            throw new NotImplementedException("The AddBefore() method is not implemented yet");
        }
        public bool AddAfter(Node afterNode, Node newNode)
        {
            if (nodesCounter == 0)
            {
                AddFirst(newNode);
                return true;
            }
            else
            {
                Node currentNode = new Node();
                currentNode = head;

                while (currentNode != null)
                {
                    if (currentNode.value == afterNode.value)
                    {
                        newNode.nextNode = currentNode.nextNode;
                        currentNode.nextNode = newNode;
                        nodesCounter++;

                        if (currentNode.value == tail.value)
                        {
                            tail = newNode;
                        }
                        return true;
                    }
                    currentNode = currentNode.nextNode;
                }
                return false;
            }
        }
        #endregion

        #region ********** Deleting elements **********
        public void DeleteFirstNode()
        {
            if (head != null)
            {
                head = head.nextNode;
                nodesCounter--;
            }
            else
            {
                Console.WriteLine("The linked list is empty. Nothing to delete");
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
                nodesCounter--;
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
        public bool DeleteBefore(Node refNode)
        {
//            throw new NotImplementedException("The DeleteBefore() method is not implemented yet");
            
            // Check if the list is empty
            if (head==null)
            {
                Console.WriteLine("The list is empty. Nothing to delete");
                return false;
            }
            // Check if the reference node is the first node
            else if (head.value == refNode.value)
            {
                Console.WriteLine("This is the first node. Deletion is not possible");
                return false;
            }
            // Check if the 2nd node is our node
            else if(head.nextNode.value== refNode.value)
            {
                DeleteFirstNode();
                nodesCounter--;
                return true; 
            }
            else
            {
                // We start search from the 2nd node.
                Node prevNode = head;
                Node currentNode = head.nextNode;

                while (currentNode != null)
                {
                    if(currentNode.value== refNode.value)
                    {
                        Node newCurrentNode = head;
                        while (newCurrentNode.nextNode.value != prevNode.value)
                        {
                            newCurrentNode = newCurrentNode.nextNode;
                        }
                        newCurrentNode.nextNode = currentNode;
                        nodesCounter--;
                        return true;
                    }
                    prevNode = currentNode;
                    currentNode = currentNode.nextNode;
                }                
            }
            return false;
        }
        public bool DeleteAfter(Node refNode)
        {
            if (nodesCounter == 0)
            {
                Console.WriteLine("The list is empty. Nothing to delete");
                return false;
            }
            // Check if our node is the last one
            else if(tail.value== refNode.value)
            {
                Console.WriteLine("This is the last node. Node possible to delete.");
                return false;
            }
            else
            {
                Node currentNode = head;
                while (currentNode != null)
                {
                    if (currentNode.value == refNode.value)
                    {
                        if (currentNode.nextNode.nextNode == null)
                        {
                            DeleteLastNode();
                            nodesCounter--;
                            return true;
                        }
                        else
                        {
                            currentNode.nextNode = currentNode.nextNode.nextNode;
                            nodesCounter--;
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
        public void Clear()
        {
            head = tail = null;
            nodesCounter = 0;
        }
        #endregion
        public bool Contains(int value)
        {
            Node currentNode = new Node();
            currentNode = head;

            while (currentNode != null)
            {
                if (currentNode.value == value)
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
        public void PrintList()
        {
            Node currentNode = head;

            Console.Write("Linked list values are:");
            while (currentNode != null)
            {
                Console.Write(" "+ currentNode.value);
                currentNode = currentNode.nextNode;
            }
            Console.Write($". Total elements count: {nodesCounter}\n");
        }
        #region ********** Properties **********
        /// <summary>
        /// The read-only property returns a number of elements in the list
        /// </summary>
        public int Count
        {
            get { return nodesCounter; }

        }
        /// <summary>
        /// The read-only property returns the last element of the list
        /// </summary>
        /// <returns></returns>
        public Node LastNode
        {
            get { return tail; }
        }
        /// <summary>
        /// The read-only property returns the first element of the list
        /// </summary>
        /// <returns></returns>
        public Node FirstNode
        {
            get { return head; }
        }
        #endregion
    }
}

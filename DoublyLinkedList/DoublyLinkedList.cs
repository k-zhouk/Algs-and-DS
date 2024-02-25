using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList
{
    /// <summary>
    /// Class implements a doubly linked list
    /// </summary>
    class DoublyLinkedList
    {
        private int nodesCounter = default;
        DLLNode head = default;
        DLLNode tail = default;
        #region ********** Constructors *********
        public DoublyLinkedList()
        {
            nodesCounter = 0;
            head = tail = null;
        }
        public DoublyLinkedList(DLLNode node)
        {
            nodesCounter = 1;
            head = tail = node;
        }
        #endregion

        #region ********** Adding Elements **********
        public void AddFirst(DLLNode newNode)
        {
            if (nodesCounter == 0)
            {
                head = tail = newNode;
                nodesCounter++;
            }
            else
            {
                head.PreviousNode = newNode;
                newNode.PreviousNode = null;
                newNode.NextNode = head;
                head = newNode;
                nodesCounter++;
            }
        }
        public void AddLast(DLLNode newNode)
        {
            if (nodesCounter == 0)
            {
                AddFirst(newNode);
            }
            else
            {
                newNode.NextNode = null;
                newNode.PreviousNode = tail;
                tail.NextNode = newNode;
                tail = newNode;
                nodesCounter++;
            }
        }
        public void AddAfter(DLLNode refNode, DLLNode newNode)
        {
            if (nodesCounter == 0)
            {
                throw new InvalidOperationException("The doubly linked list is empty. The reference node doesn't exist");
            }
            else
            {
                DLLNode currentNode = new DLLNode();
                currentNode = head;
                while (currentNode != null)
                {
                    // Found our node
                    if (currentNode.Value == refNode.Value)
                    {
                        newNode.NextNode = currentNode.NextNode;
                        newNode.PreviousNode = currentNode;
                        currentNode.NextNode.PreviousNode = newNode;
                        currentNode.NextNode = newNode;

                        if(currentNode.Value == tail.Value)
                        {
                            tail = newNode;
                        }
                        nodesCounter++;
                    }
                    currentNode = currentNode.NextNode;
                }
            }
        }
        #endregion

        #region ********** Deleting Elements **********
        public void DeleteFirst()
        {
            if (nodesCounter == 0)
            {
                throw new InvalidOperationException("The doubly linked list is empty. Nothing to delete");
            }
            else if (head == tail)
            {
                head = tail = null;
            } else
            {
                DLLNode tempNode = new DLLNode();
                tempNode = head;

                head = head.NextNode;
                head.PreviousNode = null;

                tempNode.NextNode = null;
                nodesCounter--;
            }
        }
        public void DeleteLast()
        {
            if (nodesCounter == 0)
            {
                throw new InvalidOperationException("The list is empty. Nothing to delete");
            }
            else if (head == tail)
            {
                head = tail = null;
            } else
            {
                DLLNode tempNode = new DLLNode();
                tempNode = tail;

                tail = tail.PreviousNode;
                tail.NextNode = null;

                tempNode.PreviousNode = null;
                nodesCounter--;
            }
        }
        public bool DeleteNode(DLLNode refNode)
        {
            if (nodesCounter == 0)
            {
                throw new InvalidOperationException("The list is empty. Cannot delete the node");
            }
            else
            {
                DLLNode currentNode = head;
                while(currentNode!= null)
                {
                    if (currentNode.Value == refNode.Value)
                    {
                        currentNode.PreviousNode.NextNode = currentNode.NextNode;
                        currentNode.NextNode.PreviousNode = currentNode.PreviousNode;
                        nodesCounter--;
                        return true;
                    }
                    currentNode = currentNode.NextNode;
                }
            }
            return false;
        }
        #endregion
        public void Clear()
        {
            head = tail = null;
            nodesCounter = 0;
        }
        public void PrintList()
        {
            DLLNode currentNode = head;

            Console.Write("\nDoubly linked list values are:");
            while (currentNode != null)
            {
                Console.Write(" " + currentNode.Value);
                currentNode = currentNode.NextNode;
            }
            Console.Write($". Total elements count: {nodesCounter}\n");
        }

        public void PrintInReverseOrder()
        {
            DLLNode currentNode = tail;

            Console.Write("\nDoubly linked list values are:");
            while (currentNode!= null)
            {
                Console.Write(" " + currentNode.Value);
                currentNode = currentNode.PreviousNode;
            }
            Console.Write($". Total elements count: {nodesCounter}\n");
        }

        #region ********** Properties **********
        public DLLNode FirstNode
        {
            get { return head; }
        }
        public DLLNode LastNode {
            get { return tail; }
        }
        public int Count
        {
            get { return nodesCounter; }
        }
        #endregion
    }
}

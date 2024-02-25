using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedLinkedList
{
    sealed class Node
    {
        public int Value { get; set; }
        public Node nextNode;
        public Node()
        {
            this.Value = default;
            nextNode = null;
        }
        public Node(int value)
        {
            this.Value = value;
            nextNode = null;
        }
    }
    class SortedLinkedList
    {
        private int nodesCounter;
        private Node head;
        private Node tail;
        public SortedLinkedList()
        {
            head = tail = null;
            nodesCounter = 0;
        }
        public SortedLinkedList(Node newNode)
        {
            head = tail = newNode;
            nodesCounter = 1;
        }
        public void AddNode(Node newNode)
        {
            if (nodesCounter == 0)
            {
                head = tail = newNode;
                nodesCounter = 1;
            }
            else
            {
                Node currentNode = head;
                while (currentNode != null)
                {

                }
            }
        }
        private Node FindPosition()
        {
            return new Node();
        }
    }
}

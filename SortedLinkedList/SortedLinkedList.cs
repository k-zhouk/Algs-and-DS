using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedLinkedList
{
    class SortedLinkedList
    {
        private Node head, tail;

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

        private Node FindPosition()
        {
            return new Node();
        }

        #region *************** Class properties ***************
        public int Count
        {
            get => _nodesCounter;
        }
        private int _nodesCounter;
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

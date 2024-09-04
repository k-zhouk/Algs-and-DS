namespace DoublyLinkedList
{
    /// <summary>
    /// Class for a doubly linked list node.
    /// The node contains a value and two links- to the previous and next nodes
    /// </summary>
    sealed class DLLNode
    {
        public int Value { get; set; }
        public DLLNode PreviousNode { get; set; }
        public DLLNode NextNode { get; set; }
        public DLLNode()
        {
            Value = default;
            PreviousNode = NextNode = null;
        }
        public DLLNode(int value)
        {
            Value = value;
            PreviousNode = NextNode = null;
        }
    }
}

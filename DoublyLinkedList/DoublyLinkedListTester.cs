using System;

namespace DoublyLinkedList
{
    class DoublyLinkedListTester
    {
        static void Main(string[] args)
        {
            ConsoleColor origTextColor = Console.ForegroundColor;

            DoublyLinkedList testDoublyLinkedList = new DoublyLinkedList();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n********** Test 1 **********");
            Console.ForegroundColor = origTextColor;
            Console.WriteLine("Populating a new linked list with 10 nodes with odd numbers\n");
            for (int i = 1; i <= 19; i++)
            {
                if ((i % 2) != 0)
                {
                    testDoublyLinkedList.AddFirst(new DLLNode() { Value = i });
                }
            }
            testDoublyLinkedList.PrintList();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n********** Test 2 **********");
            Console.ForegroundColor = origTextColor;
            Console.WriteLine("Adding a new node after a specified node\n");

            DLLNode newNode = new DLLNode() { Value = 100500 };
            Console.WriteLine($"New node to add: {newNode.Value}");
            DLLNode refNode = new DLLNode() { Value = 15 };
            Console.WriteLine($"Node to add after: {refNode.Value}");

            testDoublyLinkedList.AddAfter(refNode, newNode);
            testDoublyLinkedList.PrintList();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n********** Test 3 **********");
            Console.ForegroundColor = origTextColor;
            Console.WriteLine("Deleting the first node\n");

            testDoublyLinkedList.DeleteFirst();
            testDoublyLinkedList.PrintList();
            Console.WriteLine($"The new first node is: {testDoublyLinkedList.FirstNode.Value}");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n********** Test 4 **********");
            Console.ForegroundColor = origTextColor;
            Console.WriteLine("Deleting the last node\n");

            testDoublyLinkedList.DeleteLast();
            testDoublyLinkedList.PrintList();

            Console.WriteLine($"The new last node is: {testDoublyLinkedList.LastNode.Value}");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n********** Test 5 **********");
            Console.ForegroundColor = origTextColor;
            Console.WriteLine("Printing the list in the revers order\n");

            Console.Write("The direct order:");
            testDoublyLinkedList.PrintList();

            Console.Write("The reverse order:");
            testDoublyLinkedList.PrintInReverseOrder();

            // ********************************************************************************
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n********** Test 6 **********");
            Console.ForegroundColor = origTextColor;
            Console.WriteLine("Deleting a node from the list");
            refNode.Value = 100500;
            Console.WriteLine($"Node to delete: {refNode.Value}");

            bool res= testDoublyLinkedList.DeleteNode(refNode);
            if (!res)
            {
                Console.WriteLine("The node hasn't been found in the list");
            }
            else
            {
                Console.Write("The direct order:");
                testDoublyLinkedList.PrintList();
                Console.Write("The reverse order:");
                testDoublyLinkedList.PrintInReverseOrder();
            }

            Console.WriteLine("\nPress any key to exit");
            Console.ReadKey();
        }
    }
}

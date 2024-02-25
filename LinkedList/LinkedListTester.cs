using System;

namespace LinkedList
{
    class LinkedListTester
    {
        static void Main(string[] args)
        {
            ConsoleColor origTextColor = Console.ForegroundColor;

            // Test printing of an empty linked list
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("********** Test 1 **********");
            Console.ForegroundColor = origTextColor;
            Console.WriteLine("Test printing of an empty linked list\n");
            LinkedList testLinkedList = new LinkedList();
            testLinkedList.PrintList();

            // Test printing of an empty first node
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n********** Test 2 **********");
            Console.ForegroundColor = origTextColor;
            Console.WriteLine("Test printing of an empty first node\n");

            Node firstNode = testLinkedList.FirstNode;
            if (firstNode!=null)
            {
                Console.WriteLine($"The value of the first node is: {firstNode.value}");
            }
            else
            {
                Console.WriteLine($"The first node is empty");
            }

            // Test printing of the an empty last node
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n********** Test 3 **********");
            Console.ForegroundColor = origTextColor;
            Console.WriteLine("Test printing of an empty last node\n");
            Node lastNode = testLinkedList.LastNode;
            if (lastNode != null)
            {
                Console.WriteLine($"The value of the last node is: {lastNode.value}");
            }
            else
            {
                Console.WriteLine($"The last node is empty");
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n********** Test 4 **********");
            Console.ForegroundColor = origTextColor;
            Console.WriteLine("Populating a new linked list with 10 nodes with odd numbers\n");
            for (int i=1; i <= 19; i++)
            {
                if ((i % 2)!=0)
                {
                    testLinkedList.AddLast(new Node() { value = i });
                }
            }
            testLinkedList.PrintList();


            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n********** Test 5 **********");
            Console.ForegroundColor = origTextColor;
            Console.WriteLine("Adding a node after a node specified");

            Node newNode = new Node() { value = 100500 };
            Console.WriteLine($"Node to add: {newNode.value}");
            Node testNode = new Node() { value = 19 };
            Console.WriteLine($"Node to add after: {testNode.value}");

            bool res= testLinkedList.AddAfter(testNode, newNode);
            if (!res)
            {
                Console.WriteLine("The node has not been added");
            }
            else
            {
                testLinkedList.PrintList();
            }

            Node testNode2 = new Node() { value = 25 };
            testLinkedList.AddLast(testNode2);
            testLinkedList.PrintList();

            // ********************************************************************************
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n********** Test 5 **********");
            Console.ForegroundColor = origTextColor;
            Console.WriteLine("Deleting the first node\n");

            testLinkedList.DeleteFirstNode();
            testLinkedList.PrintList();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n********** Test 6 **********");
            Console.ForegroundColor = origTextColor;
            Console.WriteLine("Deleting the last node\n");

            testLinkedList.DeleteLastNode();
            testLinkedList.PrintList();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n********** Test 7 **********");
            Console.ForegroundColor = origTextColor;
            Console.WriteLine("Deleting a node before the node specified");

            testNode.value = 19;
            Console.WriteLine($"Reference node: {testNode.value}");
            res= testLinkedList.DeleteBefore(testNode);
            if (!res)
            {
                Console.WriteLine("The node has not been deleted");
            }
            else
            {
                testLinkedList.PrintList();
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n********** Test 8 **********");
            Console.ForegroundColor = origTextColor;
            Console.WriteLine("Deleting a node after the node specified");

            testNode.value = 3;
            Console.WriteLine($"Reference node: {testNode.value}");
            res = testLinkedList.DeleteAfter(testNode);
            if (!res)
            {
                Console.WriteLine("The node has not been deleted");
            }
            else
            {
                testLinkedList.PrintList();
            }
            // ********************************************************************************



            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n********** Test 7 **********");
            Console.ForegroundColor = origTextColor;
            Console.WriteLine("Searching for a value that presents in the list\n");

            int testValue = 5;
            Console.WriteLine($"The vlaue to search for: {testValue}");

            res = testLinkedList.Contains(testValue);
            if (!res)
            {
                Console.WriteLine("The value is NOT in the list");
            }
            else
            {
                Console.WriteLine("The value is in the list");
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n********** Test 8 **********");
            Console.ForegroundColor = origTextColor;
            Console.WriteLine("Searching for a value that is not in the list\n");

            testValue = 100500;
            Console.WriteLine($"The vlaue to search for: {testValue}");
            res = testLinkedList.Contains(testValue);
            if (!res)
            {
                Console.WriteLine("The value is NOT in the list");
            }
            else
            {
                Console.WriteLine("The value is in the list");
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n********** Test 9 **********");
            Console.ForegroundColor = origTextColor;
            Console.Write("Printing the first node of a non-empty list: ");

            Console.Write(testLinkedList.FirstNode.value+"\n");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n********** Test 10 **********");
            Console.ForegroundColor = origTextColor;
            Console.Write("Printing the last node of a non-empty list: ");

            Console.Write(testLinkedList.LastNode.value+ "\n");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n********** Test XXX **********");
            Console.ForegroundColor = origTextColor;
            Console.WriteLine("Clearing the list");
            testLinkedList.Clear();
            testLinkedList.PrintList();

            Console.ReadKey();
        }
    }
}

﻿using System;

namespace LinkedList
{
    class LinkedListTesting
    {
        static void Main(string[] args)
        {
            uint testsCounter = 1;

            ConsoleColor origTextColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"********** Test {testsCounter}- Create an empty list **********");
            Console.ForegroundColor = origTextColor;
            LinkedList ll = new LinkedList();
            Console.WriteLine($"Total elements count: {ll.Count}");
            Console.WriteLine($"Done{Environment.NewLine}");
            testsCounter++;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"********** Test {testsCounter}- Accessing Head and Tail values of the empty list **********");
            Console.ForegroundColor = origTextColor;
            Console.WriteLine($"Head value of the empty list: {ll.HeadValue}");
            Console.WriteLine($"Tail value of the empty list: {ll.TailValue}");
            Console.WriteLine($"Done{Environment.NewLine}");
            testsCounter++;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"********** Test {testsCounter}- Printing of the empty list **********");
            Console.ForegroundColor = origTextColor;
            ll.PrintList();
            Console.WriteLine($"Done{Environment.NewLine}");
            testsCounter++;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"********** Test {testsCounter} - Testing \"AddFirst()\" method by adding 10 odd numbers into the list **********");
            Console.ForegroundColor = origTextColor;
            for (int i = 1; i <= 19; i++)
            {
                if ((i % 2) != 0)
                {
                    ll.AddFirst(i);
                }
            }
            Console.WriteLine($"Linked list values are:");
            ll.PrintList();
            Console.Write($". Total elements count: {ll.Count}{Environment.NewLine}");
            Console.WriteLine($"Done{Environment.NewLine}");
            testsCounter++;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"********** Test {testsCounter} - Testing \"AddLast()\" method by adding 10 even numbers into the list **********");
            Console.ForegroundColor = origTextColor;
            for (int i = 1; i <= 20; i++)
            {
                if ((i % 2) == 0)
                {
                    ll.AddLast(i);
                }
            }
            Console.WriteLine($"Linked list values are:");
            ll.PrintList();
            Console.Write($". Total elements count: {ll.Count}{Environment.NewLine}");
            Console.WriteLine($"Done{Environment.NewLine}");
            testsCounter++;

            #region *************** Testing AddBefore() method ***************
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"********** Test {testsCounter} - Testing \"AddBefore()\" method by adding a value in an empty list **********");
            Console.ForegroundColor = origTextColor;
            {
                LinkedList abList = new LinkedList();
                abList.AddBefore(100500, 10);
                Console.WriteLine($"Linked list values are:");
                abList.PrintList();
                Console.Write($". Total elements count: {abList.Count}{Environment.NewLine}");
            }
            Console.WriteLine($"Done{Environment.NewLine}");
            testsCounter++;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"********** Test {testsCounter} - Testing \"AddBefore()\" method by adding a value somewhere into the list **********");
            Console.ForegroundColor = origTextColor;
            {
                Console.WriteLine($"The list before calling the \"AddBefore()\": ");
                ll.PrintList();
                Console.Write($". Total elements count: {ll.Count}{Environment.NewLine}");

                ll.AddBefore(100500, 1);

                Console.WriteLine($"Linked list values are:");
                ll.PrintList();
                Console.Write($". Total elements count: {ll.Count}{Environment.NewLine}");
            }
            Console.WriteLine($"Done{Environment.NewLine}");
            testsCounter++;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"********** Test {testsCounter} - Testing \"AddBefore()\" method by adding a value before the tail **********");
            Console.ForegroundColor = origTextColor;
            {
                Console.WriteLine($"The list before calling the \"AddBefore()\": ");
                ll.PrintList();
                Console.Write($". Total elements count: {ll.Count}{Environment.NewLine}");

                ll.AddBefore(200500, 20);

                Console.WriteLine($"Linked list values are:");
                ll.PrintList();
                Console.Write($". Total elements count: {ll.Count}{Environment.NewLine}");
            }
            Console.WriteLine($"Done{Environment.NewLine}");
            testsCounter++;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"********** Test {testsCounter} - Testing \"AddBefore()\" before a non-existing value **********");
            Console.ForegroundColor = origTextColor;
            {
                Console.WriteLine($"The list before calling the \"AddBefore()\": ");
                ll.PrintList();
                Console.Write($". Total elements count: {ll.Count}{Environment.NewLine}");

                ll.AddBefore(300500, 21);

                Console.WriteLine($"Linked list values are:");
                ll.PrintList();
                Console.Write($". Total elements count: {ll.Count}{Environment.NewLine}");
            }
            Console.WriteLine($"Done{Environment.NewLine}");
            testsCounter++;
            #endregion

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"********** Test {testsCounter} - Testing \"AddAfter()\" method by adding a value in an empty list **********");
            Console.ForegroundColor = origTextColor;
            {
                LinkedList aaList = new LinkedList();
                aaList.AddAfter(100500, 10);
                Console.WriteLine($"Linked list values are:");
                aaList.PrintList();
                Console.Write($". Total elements count: {aaList.Count}{Environment.NewLine}");
            }
            Console.WriteLine($"Done{Environment.NewLine}");
            testsCounter++;


            #region *************** Testing AddAfter() method ***************
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"********** Test {testsCounter} - Testing \"AddAfter()\" method by adding a value in an empty list **********");
            Console.ForegroundColor = origTextColor;
            {
                LinkedList aaList = new LinkedList();
                aaList.AddAfter(100500, 10);
                Console.WriteLine($"Linked list values are:");
                aaList.PrintList();
                Console.Write($". Total elements count: {aaList.Count}{Environment.NewLine}");
            }
            Console.WriteLine($"Done{Environment.NewLine}");
            testsCounter++;

            /***********************************************************************************************************************************************/
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"********** Test {testsCounter} - Testing \"AddAfter()\" method by adding a value somewhere into the list **********");
            Console.ForegroundColor = origTextColor;
            {
                Console.WriteLine($"The list before calling the \"AddAfter()\": ");
                ll.PrintList();
                Console.Write($". Total elements count: {ll.Count}{Environment.NewLine}");

                ll.AddAfter(100500, 1);

                Console.WriteLine($"Linked list values are:");
                ll.PrintList();
                Console.Write($". Total elements count: {ll.Count}{Environment.NewLine}");
            }
            Console.WriteLine($"Done{Environment.NewLine}");
            testsCounter++;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"********** Test {testsCounter} - Testing \"AddAfter()\" method by adding a value before the tail **********");
            Console.ForegroundColor = origTextColor;
            {
                Console.WriteLine($"The list before calling the \"AddBefore()\": ");
                ll.PrintList();
                Console.Write($". Total elements count: {ll.Count}{Environment.NewLine}");

                ll.AddBefore(200500, 20);

                Console.WriteLine($"Linked list values are:");
                ll.PrintList();
                Console.Write($". Total elements count: {ll.Count}{Environment.NewLine}");
            }
            Console.WriteLine($"Done{Environment.NewLine}");
            testsCounter++;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"********** Test {testsCounter} - Testing \"AddAfter()\" before a non-existing value **********");
            Console.ForegroundColor = origTextColor;
            {
                Console.WriteLine($"The list before calling the \"AddBefore()\": ");
                ll.PrintList();
                Console.Write($". Total elements count: {ll.Count}{Environment.NewLine}");

                ll.AddBefore(300500, 21);

                Console.WriteLine($"Linked list values are:");
                ll.PrintList();
                Console.Write($". Total elements count: {ll.Count}{Environment.NewLine}");
            }
            Console.WriteLine($"Done{Environment.NewLine}");
            testsCounter++;
            #endregion

            /***********************************************************************************************************************************************/
            //Console.ForegroundColor = ConsoleColor.DarkYellow;
            //Console.WriteLine("\n********** Test 5 **********");
            //Console.ForegroundColor = origTextColor;
            //Console.WriteLine("Deleting the first node\n");

            //testLinkedList.DeleteFirstNode();
            //testLinkedList.PrintList();

            //Console.ForegroundColor = ConsoleColor.DarkYellow;
            //Console.WriteLine("\n********** Test 6 **********");
            //Console.ForegroundColor = origTextColor;
            //Console.WriteLine("Deleting the last node\n");

            //testLinkedList.DeleteLastNode();
            //testLinkedList.PrintList();

            //Console.ForegroundColor = ConsoleColor.DarkYellow;
            //Console.WriteLine("\n********** Test 7 **********");
            //Console.ForegroundColor = origTextColor;
            //Console.WriteLine("Deleting a node before the node specified");

            //testNode.value = 19;
            //Console.WriteLine($"Reference node: {testNode.value}");
            //res= testLinkedList.DeleteBefore(testNode);
            //if (!res)
            //{
            //    Console.WriteLine("The node has not been deleted");
            //}
            //else
            //{
            //    testLinkedList.PrintList();
            //}

            //Console.ForegroundColor = ConsoleColor.DarkYellow;
            //Console.WriteLine("\n********** Test 8 **********");
            //Console.ForegroundColor = origTextColor;
            //Console.WriteLine("Deleting a node after the node specified");

            //testNode.value = 3;
            //Console.WriteLine($"Reference node: {testNode.value}");
            //res = testLinkedList.DeleteAfter(testNode);
            //if (!res)
            //{
            //    Console.WriteLine("The node has not been deleted");
            //}
            //else
            //{
            //    testLinkedList.PrintList();
            //}
            //// ********************************************************************************

            //Console.ForegroundColor = ConsoleColor.DarkYellow;
            //Console.WriteLine("\n********** Test 7 **********");
            //Console.ForegroundColor = origTextColor;
            //Console.WriteLine("Searching for a value that presents in the list\n");

            //int testValue = 5;
            //Console.WriteLine($"The vlaue to search for: {testValue}");

            //res = testLinkedList.Contains(testValue);
            //if (!res)
            //{
            //    Console.WriteLine("The value is NOT in the list");
            //}
            //else
            //{
            //    Console.WriteLine("The value is in the list");
            //}

            //Console.ForegroundColor = ConsoleColor.DarkYellow;
            //Console.WriteLine("\n********** Test 8 **********");
            //Console.ForegroundColor = origTextColor;
            //Console.WriteLine("Searching for a value that is not in the list\n");

            //testValue = 100500;
            //Console.WriteLine($"The vlaue to search for: {testValue}");
            //res = testLinkedList.Contains(testValue);
            //if (!res)
            //{
            //    Console.WriteLine("The value is NOT in the list");
            //}
            //else
            //{
            //    Console.WriteLine("The value is in the list");
            //}

            //Console.ForegroundColor = ConsoleColor.DarkYellow;
            //Console.WriteLine("\n********** Test 9 **********");
            //Console.ForegroundColor = origTextColor;
            //Console.Write("Printing the first node of a non-empty list: ");

            //Console.Write(testLinkedList.FirstNode.value+"\n");

            //Console.ForegroundColor = ConsoleColor.DarkYellow;
            //Console.WriteLine("\n********** Test 10 **********");
            //Console.ForegroundColor = origTextColor;
            //Console.Write("Printing the last node of a non-empty list: ");

            //Console.Write(testLinkedList.LastNode.value+ "\n");

            //Console.ForegroundColor = ConsoleColor.DarkYellow;
            //Console.WriteLine("\n********** Test XXX **********");
            //Console.ForegroundColor = origTextColor;
            //Console.WriteLine("Clearing the list");
            //testLinkedList.Clear();
            //testLinkedList.PrintList();

            // Console.ReadKey();
        }
    }
}

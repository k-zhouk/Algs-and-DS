using System;

namespace SortedLinkedList
{
    class SortedLinkedListTesting
    {
        static void Main(string[] args)
        {
            uint testsCounter = 1;

            ConsoleColor origTextColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"********** Test {testsCounter}- Create an empty list **********");
            Console.ForegroundColor = origTextColor;
            SortedLinkedList sll = new SortedLinkedList();
            Console.WriteLine($"Total elements count: {sll.Count}");
            Console.WriteLine($"Done{Environment.NewLine}");
            testsCounter++;


        }
    }
}

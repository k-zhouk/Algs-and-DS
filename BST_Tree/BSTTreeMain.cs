using System.Diagnostics;

namespace BST_Tree
{
    class BSTTreeMain
    {
        static void Main(string[] args)
        {
            BSTTree testTree = new BSTTree();
            testTree.Add(50);
            testTree.Add(10);
            testTree.Add(60);
            testTree.Add(7);
            testTree.Add(11);
            testTree.Add(55);
            testTree.Add(20);

            int minValue = testTree.GetMinimum();
            int maxValue = testTree.GetMaximum();

            // BST tree methods
            uint count = testTree.Count;
            Debug.WriteLine($"Number of elements: {count}");

            // Checking addition of the same node
            testTree.Add(11);

            int testValue = 55;
            Debug.Write($"Test value 1 to find: {testValue}. ");
            Debug.WriteLine($"Test value is in the tree: {testTree.Contains(testValue)}");

            testValue = 100500;
            Debug.Write($"Test value 1 to find: {testValue}. ");
            Debug.WriteLine($"Test value is in the tree: {testTree.Contains(testValue)}");

            Debug.WriteLine($"Calling the Clear method");
            testTree.Clear();

            // Example of an unbalanced BST tree ^_^
            testTree.Add(1);
            testTree.Add(2);
            testTree.Add(3);
            testTree.Add(4);
            testTree.Add(5);
            testTree.Add(6);

            // Deletion checks
            // Setup the tree for deletion checks
            testTree.Clear();

            // Case 1: deletion from an empty tree
            bool res = true;
            res = testTree.Delete(100500);

            // Adding some nodes into the tree
            testTree.Add(50);
            testTree.Add(10);
            testTree.Add(60);
            testTree.Add(7);
            testTree.Add(11);
            testTree.Add(55);
            testTree.Add(20);

            // Case 1: Deletion of a non-existing value
            res = true;
            res = testTree.Delete(100500);

            // Case 2: deletion of the root node
            res = true;
            res = testTree.Delete(50);

            // Adding some nodes into the tree again
            testTree.Add(50);
            testTree.Add(10);
            testTree.Add(60);
            testTree.Add(7);
            testTree.Add(11);
            testTree.Add(55);
            testTree.Add(20);

            // Case 3: deletion of a node with no children
            res = false;
            res = testTree.Delete(20);
            testTree.Add(20);

            // Case 4: deletion of a node without LEFT child
            res = false;
            res = testTree.Delete(11);
            res = testTree.Add(11);

            // Case 5: deletion of a node without RIGHT child
            res = false;
            res = testTree.Delete(60);
            res = testTree.Add(60);

            // Case 5: deletion of a node with LEFT and RIGHT child
            res = false;
            res = testTree.Delete(10);

            // ******************************************************************

            //Debug.WriteLine($"Deleting a node with the value of {testValue}: {testTree.Delete(testValue)}");

            //testValue = 20;
            //Debug.WriteLine($"Deleting a node with the value of {testValue}: {testTree.Delete(testValue)}");

            //// Printing checks
            //testTree.PrintAscending();
            //testTree.PrintDescending();
        }
    }
}

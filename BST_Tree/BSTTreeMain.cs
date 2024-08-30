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

            testTree.PrintAscending();

            // BST tree methods
            uint count = testTree.Count;
            Debug.WriteLine($"Number of elements: {count}");

            // Testing addition of the same node
            testTree.Add(11);

            // Testing deletion of a leaf node (node with no children)
            testTree.Delete(20);
            
            int testValue = 55;
            Debug.Write($"Test value 1 to find: {testValue}. ");
            Debug.WriteLine($"Test value is in the tree: {testTree.Contains(testValue)}");

            testValue = 100500;
            Debug.Write($"Test value 1 to find: {testValue}. ");
            Debug.WriteLine($"Test value is in the tree: {testTree.Contains(testValue)}");

            Debug.WriteLine($"Deleting a node with the value of {testValue}: {testTree.Delete(testValue)}");

            testValue = 20;
            Debug.WriteLine($"Deleting a node with the value of {testValue}: {testTree.Delete(testValue)}");

            Debug.WriteLine($"Calling the Clear method");
            testTree.Clear();

            // Example of an unbalanced BST tree ^_^
            testTree.Add(1);
            testTree.Add(2);
            testTree.Add(3);
            testTree.Add(4);
            testTree.Add(5);
            testTree.Add(6);
        }
    }
}

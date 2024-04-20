using System;
using System.Diagnostics;

namespace BST_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            // Nodes to test the BST tree class
            BST_Node testNode1 = new BST_Node(50);
            BST_Node testNode2 = new BST_Node(10);
            BST_Node testNode3 = new BST_Node(60);
            BST_Node testNode4 = new BST_Node(7);
            BST_Node testNode5 = new BST_Node(11);
            BST_Node testNode6 = new BST_Node(55);
            BST_Node newNode1 = new BST_Node(20);
            BST_Node newNode2 = new BST_Node(11);

            // BST tree methods
            BST_Tree testTree = new BST_Tree();

            uint count = testTree.Count;

            testTree.Add(testNode1);
            testTree.Add(testNode2);
            testTree.Add(testNode3);
            testTree.Add(testNode4);
            testTree.Add(testNode5);
            testTree.Add(testNode6);
            testTree.Add(newNode1);

            count = testTree.Count;
            Debug.WriteLine($"Number of elements: {count}");

            // Testing addition of the same node
            // testTree.Add(newNode2);

            // Testing deletion of a leaf node (node with no children)
            testTree.DeleteNode(newNode1);

            /*
            BST_Node testValue = new BST_Node(55);
            Debug.Write($"Test value 1 to find: {testValue.value}. ");
            Debug.WriteLine($"Test value is in the tree: {testTree.CheckPresense(testValue)}");

            testValue.value = 100500;
            Debug.Write($"Test value 1 to find: {testValue.value}. ");
            Debug.WriteLine($"Test value is in the tree: {testTree.CheckPresense(testValue)}");

            Debug.WriteLine($"Deleting a node with the value of {testValue.value}: {testTree.DeleteSubtree(testValue)}");

            testValue.value = 20;
            Debug.WriteLine($"Deleting a node with the value of {testValue.value}: {testTree.DeleteSubtree(testValue)}");

            Debug.WriteLine($"Calling the Clear method");
            testTree.Clear();
            */

            /*
            // Example of the unbalanced BST tree ^_^
            testNode1 = new BST_Node(1);
            testNode2 = new BST_Node(2);
            testNode3 = new BST_Node(3);
            testNode4 = new BST_Node(4);
            testNode5 = new BST_Node(5);
            testNode6 = new BST_Node(6);

            testTree.Add(testNode1);
            testTree.Add(testNode2);
            testTree.Add(testNode3);
            testTree.Add(testNode4);
            testTree.Add(testNode5);
            testTree.Add(testNode6);
            */
        }
    }
}

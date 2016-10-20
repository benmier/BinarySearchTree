using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree theTree = new BinaryTree();

            theTree.addNode(50, "Boss");

            theTree.addNode(25, "Vice President");

            theTree.addNode(15, "Office Manager");

            theTree.addNode(30, "Secretary");

            theTree.addNode(75, "Sales Manager");

            theTree.addNode(85, "Salesman 1");

            //theTree.inOrderTraversal(theTree.root);
            //theTree.preOrderTraversal(theTree.root);
            //theTree.postOrderTraversal(theTree.root);
            Console.WriteLine(theTree.findNode(30).toString());
        }
    }

    class Node
    {
        public int key;
        public string name;
        public Node leftChild;
        public Node rightChild;

        public Node(int key, string name)
        {
            this.key = key;
            this.name = name;
        }

        public string toString()
        {
            return $"{this.name} has a key {this.key}";
        }
    }

    class BinaryTree
    {
        public Node root;

        public void addNode(int key, string name)
        {
            Node newNode = new Node(key, name);

            if (root == null)
            {
                root = newNode;
            }
            else
            {
                Node focusNode = root;
                Node parent;

                while (true)
                {
                    parent = focusNode;

                    if (key < focusNode.key)
                    {
                        focusNode = focusNode.leftChild;

                        if (focusNode == null)
                        {
                            parent.leftChild = newNode;
                            return;
                        }
                    }
                    else
                    {
                        focusNode = focusNode.rightChild;

                        if (focusNode == null)
                        {
                            parent.rightChild = newNode;
                            return;
                        }
                    }
                }
            }
        }

        public void inOrderTraversal(Node focusNode)
        {
            if (focusNode != null)
            {
                inOrderTraversal(focusNode.leftChild);
                Console.WriteLine(focusNode.toString());
                inOrderTraversal(focusNode.rightChild);
            }
        }

        public void preOrderTraversal(Node focusNode)
        {
            if (focusNode != null)
            {
                Console.WriteLine(focusNode.toString());
                preOrderTraversal(focusNode.leftChild);
                preOrderTraversal(focusNode.rightChild);
            }
        }

        public void postOrderTraversal(Node focusNode)
        {
            if (focusNode != null)
            {
                postOrderTraversal(focusNode.leftChild);
                postOrderTraversal(focusNode.rightChild);
                Console.WriteLine(focusNode.toString());
            }
        }

        public Node findNode(int key)
        {
            Node focusNode = root;

            while (key != focusNode.key)
            {
                if (key < focusNode.key)
                {
                    focusNode = focusNode.leftChild;
                }
                else
                {
                    focusNode = focusNode.rightChild;
                }

                if (focusNode == null)
                {
                    return null;
                }
            }

            return focusNode;
        }
    }
}

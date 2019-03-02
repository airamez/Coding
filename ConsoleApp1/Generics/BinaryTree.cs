using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Generic implementation of a Binary Tree.
/// </summary>
namespace Coding.Generics
{
    public class Node<T> // T is the generic concept where could be anytype provided at coding time
        where T : IComparable // T has to implement IComparable. The Binary tree rely on it to store elements
    {
        public Node(T data)
        {
            this.Data = data;
        }

        public T Data { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public int CompareTo(Node<T> other)
        {
            return Data.CompareTo(other.Data);
        }
    }

    public class BinaryTree<T> where T : IComparable
    {
        private Node<T> root;

        public BinaryTree()
        {
            root = null;
        }

        public void Add(T newData)
        {
            Node<T> newNode = new Node<T>(newData);
            if (root == null) {
                root = newNode;
            } else {
                Add(root, newNode);
            }
        }

        private void Add(Node<T> node, Node<T> newNode)
        {
            if (node.Data.CompareTo(newNode.Data) > 0) {
                if (node.Left == null)
                    node.Left = newNode;
                else
                    Add(node.Left, newNode);
            } else {
                if (node.Right == null)
                    node.Right = newNode;
                else
                    Add(node.Right, newNode);
            }
        }

        public List<T> TransverseInOrder()
        {
            List<T> list = new List<T>();
            TransverseInOrder(root, list);
            return list;
        }

        private void TransverseInOrder(Node<T> node, List<T> list)
        {
            if (node == null)
                return;
            TransverseInOrder(node.Left, list);
            list.Add(node.Data);
            TransverseInOrder(node.Right, list);
        }
    }

    public class BinaryTreeDemo {
        public static void Main (string[] args)
        {
            BinaryTree<int> intBinTree = new BinaryTree<int>();
            intBinTree.Add(64);
            intBinTree.Add(32);
            intBinTree.Add(96);
            intBinTree.Add(16);
            intBinTree.Add(8);
            intBinTree.Add(116);
            intBinTree.Add(4);
            intBinTree.Add(2);
            intBinTree.Add(87);
            foreach(int n in intBinTree.TransverseInOrder()) {
                Console.Write(n + ", ");
            }
            Console.WriteLine();

            BinaryTree<string> strBinTree = new BinaryTree<string>();
            strBinTree.Add("h");
            strBinTree.Add("e");
            strBinTree.Add("j");
            strBinTree.Add("z");
            strBinTree.Add("l");
            strBinTree.Add("m");
            strBinTree.Add("d");
            strBinTree.Add("i");
            strBinTree.Add("o");
            strBinTree.Add("s");
            foreach(string s in strBinTree.TransverseInOrder()) {
                Console.Write(s + ", ");
            }
            Console.WriteLine();
        }
    }
}

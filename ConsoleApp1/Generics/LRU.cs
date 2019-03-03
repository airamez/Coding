using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    /// <summary>
    /// Genric LRU - Least Recently Used implementation
    /// Two data structures are used combined: HashTable and a double linked list
    /// </summary>
    public class LRU <T>
    {
        Dictionary<T, Node<T>> cache; // HashTable to store the Node based on the Key (Data)
        Node<T> head; // Head of the doubled linked list
        Node<T> tail; // Tail of the double liked list
        readonly int MAX_SIZE;

        public LRU(int maxSize = 10)
        {
            cache = new Dictionary<T, Node<T>>();
            MAX_SIZE = maxSize;
        }

        public void Add(T value)
        {
            Console.WriteLine($"Adding : {value}");
            if (head == null) {
                head = new Node<T>(value);
                tail = head;
                cache.Add(head.Data, head);
                return;
            }
            if (!cache.ContainsKey(value)) {
                Node<T> newNode = new Node<T>(value);
                cache.Add(newNode.Data, newNode);
                FixLinksNewNode(newNode);
            } else {
                Node<T> node = cache[value];
                FixLinksExistingNode(node);
            }
            if (cache.Count > MAX_SIZE) {
                cache.Remove(tail.Data);
                tail = tail.Previous;
                tail.Next = null;
            }
        }

        private void FixLinksNewNode(Node<T> newNode)
        {
            newNode.Next = head;
            head.Previous = newNode;
            head = newNode;
        }

        private void FixLinksExistingNode(Node<T> node)
        {
            if (node != head) {
                if (node == tail) {
                    tail = tail.Previous;

                }
                node.Previous.Next = node.Next;
                if (node.Next != null) {
                    node.Next.Previous = node.Previous;
                }
                head.Previous = node;
                node.Next = head;
                node.Previous = null;
                head = node;
            }
        }

        public void Print()
        {
            if (head == null)
                return;
            Node<T> runner = head;
            while (runner != null) {
                Console.Write(runner.Data + ", ");
                runner = runner.Next;
            }
            Console.WriteLine();
        }
    }

    public class Node <T> {
        public Node<T> Previous;
        public Node<T> Next;
        public T Data;

        public Node (T data)
        {
            this.Data = data;
        }
    }

    public class LRUDemo
    {
        public static void Main (string[] args)
        {
            LRU<string> lru = new LRU<string>(5);
            lru.Add("D");
            lru.Print();
            lru.Add("C");
            lru.Print();
            lru.Add("C");
            lru.Print();
            lru.Add("D");
            lru.Print();
            lru.Add("A");
            lru.Print();
            lru.Add("B");
            lru.Print();
            lru.Add("A");
            lru.Print();
            lru.Add("B");
            lru.Print();
            lru.Add("C");
            lru.Print();
            lru.Add("D");
            lru.Print();
            lru.Add("Z");
            lru.Print();
            lru.Add("V");
            lru.Print();
            lru.Add("A");
            lru.Print();
            lru.Add("B");
            lru.Print();
            lru.Add("K");
            lru.Print();
            lru.Add("W");
            lru.Print();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    public class LRU
    {
        Dictionary<string, Node> cache;
        Node head;

        public LRU()
        {
            cache = new Dictionary<string, Node>();
        }

        public void Add(string value)
        {
            if (head == null) {
                head = new Node(value);
                cache.Add(head.Data, head);
                return;
            }
            if (!cache.ContainsKey(value)) {
                Node newNode = new Node(value);
                cache.Add(newNode.Data, newNode);
                FixLinksNewNode(newNode);
            } else {
                Node node = cache[value];
                FixLinksExistingNode(node);
            }
        }

        private void FixLinksNewNode(Node newNode)
        {
            newNode.Next = head;
            head.Previous = newNode;
            head = newNode;
        }

        private void FixLinksExistingNode(Node node)
        {
            if (node != head) {
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
            Node runner = head;
            while (runner != null) {
                Console.Write(runner.Data + ", ");
                runner = runner.Next;
            }
            Console.WriteLine();
        }
    }

    public class Node {
        public Node Previous;
        public Node Next;
        public string Data;

        public Node (string data)
        {
            this.Data = data;
        }
    }

    public class LRUDemo
    {
        public static void Main (string[] args)
        {
            LRU lru = new LRU();
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
            lru.Add("K");
            lru.Print();
            lru.Add("W");
            lru.Print();
        }
    }
}

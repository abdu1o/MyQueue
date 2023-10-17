using MyQueue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQueue
{
    public class PriorityQueue<T>
    {
        private List<(T item, int priority)> items;

        public int Count => items.Count;

        public PriorityQueue()
        {
            items = new List<(T, int)>();
        }

        public void insert_with_priority(T item, int priority)
        {
            items.Add((item, priority));
            items.Sort((x, y) => x.priority.CompareTo(y.priority));
        }

        public void insert(T item)
        {
            insert_with_priority(item, 0);
        }

        public T pull_highest_priority_element()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Queue is empty");
                return default;
            }

            T item = items[0].item;
            items.RemoveAt(0);

            return item;
        }

        public bool isEmpty()
        {
            if(items.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public T peek()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Queue is empty");
                return default;
            }

            return items[0].item;
        }

        public void delete(T item)
        {
            int index = items.FindIndex(x => x.item.Equals(item));

            if (index != -1)
            {
                items.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Element is not exist");
            }
        }
    }

}

internal class Program
{
    static void Main(string[] args)
    {
        PriorityQueue<string> priority_queue = new PriorityQueue<string>();

        priority_queue.insert_with_priority("asd", 1);
        priority_queue.insert("qwe");

        Console.WriteLine(priority_queue.peek());
        priority_queue.delete("qwe");

        Console.WriteLine(priority_queue.peek());
        priority_queue.delete("asd");

        Console.WriteLine(priority_queue.isEmpty());
    }
}


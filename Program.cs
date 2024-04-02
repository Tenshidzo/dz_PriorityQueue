using System.Collections;

namespace dz_PriorityQueue
{
    public class PriorityQueue : IEnumerable, IEnumerator
    {
        private List<object> _items;
        private int _position = -1;

        public PriorityQueue()
        {
            _items = new List<object>();
        }

        public void Enqueue(object item)
        {
            _items.Add(item);
            _items.Sort();
        }

        public object Dequeue()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            object item = _items[0];
            _items.RemoveAt(0);
            return item;
        }

        public object Peek()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return _items[0];
        }

        public bool Contains(object item)
        {
            return _items.Contains(item);
        }

        public void Clear()
        {
            _items.Clear();
        }

        public int Count
        {
            get { return _items.Count; }
        }

        public bool IsEmpty
        {
            get { return _items.Count == 0; }
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            _position++;
            return (_position < _items.Count);
        }

        public void Reset()
        {
            _position = -1;
        }

        public object Current
        {
            get
            {
                try
                {
                    return _items[_position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public void Dispose()
        {
            Reset();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue queue = new PriorityQueue();

            queue.Enqueue(3);
            queue.Enqueue(1);
            queue.Enqueue(2);

            Console.WriteLine("First Element: " + queue.Peek());

            Console.WriteLine("Contains 2?: " + queue.Contains(2));

            Console.WriteLine("Priority items:");
            while (queue.GetEnumerator().MoveNext())
            {
                Console.WriteLine(queue.Dequeue());
            }

            Console.WriteLine("Number of elements in queue: " + queue.Count);

            Console.WriteLine("Queue empty?: " + queue.IsEmpty);

            queue.Clear();

            Console.WriteLine("Queue empty after cleaning?: " + queue.IsEmpty);
        }
    }
}

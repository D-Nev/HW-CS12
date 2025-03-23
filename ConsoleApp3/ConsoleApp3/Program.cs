namespace ConsoleApp3
{
    internal class Program
    {

        public class Value<K, V>
        {
            public K Key { get; set; }
            public V ValueD { get; set; }

            public Value(K key, V value)
            {
                Key = key;
                ValueD = value;
            }

            public override string ToString()
            {
                return $"{Key}: {ValueD}";
            }
        }

        public class Contr<K, V>
        {
            List<Value<K, V>> items;

            public Contr()
            {
                items = new List<Value<K, V>>();
            }

            public void Add(K key, V value)
            {
                items.Add(new Value<K, V>(key, value));
            }

            public void Instr(int index, K key, V value)
            {
                if (index < 0 || index >= items.Count)
                {
                    throw new IndexOutOfRangeException();
                }
                items[index] = new Value<K, V>(key, value);
            }

            public Value<K, V> this[int index]
            {
                get
                {
                    if (index < 0 || index >= items.Count)
                    {
                        throw new IndexOutOfRangeException();
                    }
                    return items[index];
                }
            }

            public override string ToString()
            {
                return string.Join(", ", items);
            }
        }
        class Programs
        {
            static void Main(string[] args)
            {
                var container = new Contr<int, string>();

                container.Add(1, "One");
                container.Add(2, "Two");
                container.Add(3, "Three");

                Console.WriteLine(container.ToString()); 
                Console.WriteLine(container[1]); 

                container.Instr(1, 4, "Four"); 
                Console.WriteLine(container.ToString());
            }
        }
    }
}

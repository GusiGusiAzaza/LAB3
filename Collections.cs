using System;
using System.Collections.Generic;
using System.Collections;

namespace LAB3
{
     public class StoreCollection : IEnumerable, IEnumerator
     {
        private static StoreCollection instance;

        private StoreCollection()
        { }

        public static StoreCollection getInstance()
        {
            if (instance == null)
                instance = new StoreCollection();
            return instance;
        }

        readonly List<Store> stores = new List<Store>();
        private int size = 0;   
        public Store this[int index]
        {
            get
            {
                if (index <= this.size && index >= 0) return stores[index];
                Console.WriteLine($"Введён некорректный индекс({index})");
                return null;
            }
            set { stores[index] = value;}
        }
        private int _position = -1;
        bool IEnumerator.MoveNext()
        {
            if (_position < stores.Count - 1)
            {
                _position++;
                return true;
            }
            return false;
        }
        void IEnumerator.Reset()
        {
            _position = -1;
        }
        object IEnumerator.Current => stores[_position];
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)this;
        }

        public void Add(Store store)
        {
            if (this.IsThere(store.name))
            {
                Console.WriteLine($"Магазин с именем \"{store.name}\" уже находится в коллекции");
                return;
            }
            stores.Add(store);
            size++;
        }
        public void Remove(Store store)
        {
            stores.Remove(store);
            size--;
        }
        public void FindWithName(string name)
        {
            //name = name.ToLower();
            for (int i = 0; i < stores.Count; i++)
            {
                if (stores[i].name == name) 
                { 
                    Console.WriteLine($"\nМагазин по запросу \'{name}\':\n{stores[i]}\n");
                    return;
                };
            }
             Console.WriteLine($"Магазин с именем \'{name}\' не найден\n");
        }
        public bool IsThere(string name)
        {
            //name = name.ToLower();
            foreach (Store t in this.stores)
            {
                if (t.name == name)
                {
                    return true;
                };
            }
            return false;
        }
        public StoreCollection Unite(StoreCollection coll)
        {
            StoreCollection united = new StoreCollection();
            foreach (Store item in this)
            {
                united.Add(item);
            }
            foreach (Store item in coll)
            {
                if (!this.IsThere(item.name))
                    united.Add(item);
            }
            return united;
        }


        public override string ToString()
        {
            string str = $"\nСписок магазинов в коллекции:\n";
            foreach (var item in stores) str += $"-{item.name}\n";
            return str;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if ((obj == null) || this.GetType() != obj.GetType())
            {
                return false;
            }
            var s = (StoreCollection)obj;
            if (s.stores.Count != stores.Count) return false;
            else
            {
                int x1=0;
                int x2=0;
                for (int i = 0; i < stores.Count; i++)
                {
                    x1 += s.stores[i].name.GetHashCode();
                    x2 += stores[i].name.GetHashCode();
                }
                return (x1 == x2);
            }
        }
     }
}

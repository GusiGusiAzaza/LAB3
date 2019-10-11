using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB3
{
     public class StoreCollection : IEnumerable, IEnumerator
    {
        readonly List<Store> stores = new List<Store>();
        private int size = 0;
       
        public Store this[int index]
        {
            get { return stores[index]; }
            set { stores[index] = value;}
        }
        private int position = -1;
        bool IEnumerator.MoveNext()
        {
            if (position < stores.Count - 1)
            {
                position++;
                return true;
            }
            return false;
        }
        void IEnumerator.Reset()
        {
            position = -1;
        }
        object IEnumerator.Current => stores[position];
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)this;
        }
        

        public void Add(Store store)
        {
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
            for (int i = 0; i < stores.Count; i++)
            {
                if (stores[i].name == name)
                {
                    return true;
                };
            }
            return false;
        }


        public override string ToString()
        {
            string str = "Список магазинов:\n";
            foreach (var item in stores) str += $"-{item.name}\n";
            return str;
        }
        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            StoreCollection s = (StoreCollection)obj;
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

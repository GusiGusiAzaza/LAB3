using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LAB3
{
    internal class Program
    {
        private static void Main()
        {
            //var vollection = new StoreCollection();
            var collection = StoreCollection.getInstance();
            var ugusya = new Store("У Гуся", true, 10000, 50000, 2780, 2000);
            collection.Add(ugusya);

            Info.GetInfo(ugusya);
            var paket = new Store(ugusya);
            collection.Add(paket);

            Console.WriteLine(ugusya.Equals(paket));
            paket.name = "Пакет Ашана";
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(ugusya, new ValidationContext(ugusya), results, true))
            {
                foreach (var error in results)
                    Console.WriteLine(error.ErrorMessage);
            }
            Console.WriteLine("HashCode - " + ugusya.GetHashCode());

            var badVegies = 100;
            ugusya.ThrowVegies(ref badVegies);
            Console.WriteLine($"{ugusya.Vegetables}, {badVegies}");
            Store.RevDiff(paket.Revenue);

            var fakeStore = new { name = "Аппле", isOpen = true, stock = 100000000, revenue = 666, fruits = 0, vegetables = 0 };
            Console.WriteLine(fakeStore.GetType().Name);

            collection.FindWithName("Пакет Ашана");
            collection.FindWithName("Пакет Гуся");

            Console.WriteLine(collection.ToString());

            //var coll2 = new StoreCollection();
            var coll2 = StoreCollection.getInstance();
            var hh = new Store("У Гуся", true, 10000, 50000, 2780, 2000);
            var hhh = new Store("Пакет Ашана", true, 10000, 50000, 2780, 2000);
            var hhhh = new Store("Семёрочка", true, 10000, 50000, 2780, 2000);
            coll2.Add(hh);
            coll2.Add(hhh);
            coll2.Add(hhhh);
            Console.WriteLine("Equals - " + collection.Equals(coll2));
            Console.WriteLine($"У Гуся - {collection.IsThere("У Гуся")}");

            var unitedColl = collection.Unite(coll2);
            Console.WriteLine("\n" + unitedColl.Equals(coll2));
            Console.WriteLine(unitedColl);
        }
    }
}

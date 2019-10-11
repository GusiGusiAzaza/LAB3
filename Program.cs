using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LAB3
{
    class Program
    {
     
        static void Main(string[] args)
        {
            var collection = new StoreCollection();
            Store Ugusya = new Store("У Гуся",true, 10000, 50000, 2780, 2000);
            collection.Add(Ugusya);
            
            Info.GetInfo(Ugusya);
            Store Paket = new Store(Ugusya);
            collection.Add(Paket);
            
            Console.WriteLine(Ugusya.Equals(Paket));
            Paket.name = "Пакет Ашана";
            Info.GetInfo(Paket);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(Ugusya, new ValidationContext(Ugusya), results, true))
            {
                foreach (var error in results)
                    Console.WriteLine(error.ErrorMessage);
            }
            Console.WriteLine("HashCode - " + Ugusya.GetHashCode());
            
            int badVegies = 100;
            Ugusya.ThrowVegies(ref badVegies);
            Console.WriteLine($"{Ugusya.vegetables}, {badVegies}");
            Store.RevDiff(Paket.Revenue);

            var fakeStore = new { name = "Аппле", isOpen = true, stock = 100000000, revenue = 666, fruits = 0, vegetables = 0 };
            Console.WriteLine(fakeStore.GetType().Name);

            collection.FindWithName("Пакет Ашана");
            collection.FindWithName("Пакет Гуся");

            Console.WriteLine(collection.ToString());

            var coll2 = new StoreCollection();
            Store hh = new Store("У Гуся", true, 10000, 50000, 2780, 2000);
            Store hhh = new Store("Пакет Ашана", true, 10000, 50000, 2780, 2000);
            coll2.Add(hh);
            coll2.Add(hhh);
            Console.WriteLine("Equals - " + collection.Equals(coll2));

            Console.WriteLine($"У Гуся - {collection.IsThere("У Гуся")}");
        }
    }
}

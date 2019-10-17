using System;

namespace LAB3
{
    public partial class Store
    {
        public Store()
        {
            this.isOpen = false;
        }
        public Store(string name, bool isOpen, int stock, int revenue, int fruits, int vegetables)
        {
            this.name = name;
            this.isOpen = isOpen;
            this.Stock = stock;
            this.revenue = revenue;
            this.Fruits = fruits;
            this.Vegetables = vegetables;
        }
        static Store()
        {
            location = "Minsk";
        }
        public Store(Store previousStore)
        {
            isOpen = previousStore.isOpen;
            Stock = previousStore.Stock;
            revenue = previousStore.revenue;
            Fruits = previousStore.Fruits;
            Vegetables = previousStore.Vegetables;
        }


        public override string ToString()
        {
            return $"---------------------------\nStore: {name}\nLocation: {Store.location}.\nThe store is open: {isOpen}.\nThere are {Stock} units in stock.\n" +
                $"Fruits: {Fruits}.\nVegetables: {Vegetables}\nThe revenue: {revenue}$ \n---------------------------\n";
        }
        public override int GetHashCode()
        {
            return ((Fruits * 27) + (Vegetables * 12) + (Stock * 13));
        }
        public override bool Equals(object obj)
        {
            if ((obj == null) || this.GetType() != obj.GetType())
            {
                return false;
            }
            else
            {
                var s = (Store)obj;
                return (isOpen == s.isOpen) && (Stock == s.Stock) && (Fruits == s.Fruits) && (Vegetables == s.Vegetables) && (isOpen == s.isOpen);
            }
        }


        ~Store() => Console.WriteLine("////The destructor of Store is executing.////");
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LAB3
{
    public partial class Store
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(15, MinimumLength = 2)]
        public string name;
        public bool isOpen;
        private int revenue { get; set; }
        [Required(ErrorMessage = "Stock space is required")]
        [Range(0, 10000000)]
        public int stock { get; set; }
        [Range(0, 5000)]
        public int fruits { get; set; }
        [Range(0, 10000)]
        public int vegetables { get; set; }
        public static string location;
        private static int minRevenue = 1000;
        
        public Store()
        {
            this.isOpen = false;
        }
        public Store(string name, bool isOpen, int stock, int revenue, int fruits, int vegetables)
        {
            this.name = name;
            this.isOpen = isOpen;
            this.stock = stock;
            this.revenue = revenue;      
            this.fruits = fruits;
            this.vegetables = vegetables;
        }
        static Store()
        {
            location = "Minsk";
        }
        public Store(Store previousStore)
        {
            isOpen = previousStore.isOpen;
            stock = previousStore.stock;
            revenue = previousStore.revenue;
            fruits = previousStore.fruits;
            vegetables = previousStore.vegetables;
        }

        public override string ToString()
        {
            return $"---------------------------\nStore: {name}\nLocation: {Store.location}.\nThe store is open: {isOpen}.\nThere are {stock} units in stock.\n" +
                $"Fruits: {fruits}.\nVegetables: {vegetables}\nThe revenue: {revenue}$ \n---------------------------\n";
        }
        public override int GetHashCode()
        {
            return ((fruits * 27) + (vegetables * 12) + (stock * 13));
        }
        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Store s = (Store)obj;
                return (isOpen == s.isOpen) && (stock == s.stock) && (fruits == s.fruits) && (vegetables == s.vegetables) && (isOpen == s.isOpen);
            }
        }


 
    }
}

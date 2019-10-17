using System;
using System.ComponentModel.DataAnnotations;

namespace LAB3
{
    public partial class Store
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(15, MinimumLength = 2)]
        public string name;
        
        public bool isOpen;
        private int revenue;
        
        [Required(ErrorMessage = "Stock space is required")]
        [Range(0, 10000000)]
        public int Stock { get; set; }
        
        [Range(0, 5000)]
        public int Fruits { get; }
        
        [Range(0, 10000)]
        public int Vegetables { get; set; }
        public static string location;
        private static int minRevenue = 1000;
        

        public static int RevDiff(int rev)
        {
            if (rev < minRevenue) Console.WriteLine($"You need to increase revenue by {minRevenue - rev} $!!!");
            else Console.WriteLine($"{rev - minRevenue}$ till you're bankrupt :)");
            return (rev - minRevenue);
        }
        public int Revenue
        {
            set
            {
                if (value < minRevenue)
                {
                    Console.WriteLine("Экономически не выгодно(выручка меньше 1000)");
                }
                else
                {
                    revenue = value;
                }
            }
            get { return revenue; }
        }
        public int MinRevenue
        {
            get { return minRevenue; }
        }
        public void ThrowVegies(ref int x)
        {
            Vegetables = Vegetables - x;
            x = 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB3
{
    public partial class Store
    {
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
            vegetables = vegetables - x;
            x = 0;
        }


        ~Store() => Console.WriteLine("////The destructor of Store is executing.////");
    }
}

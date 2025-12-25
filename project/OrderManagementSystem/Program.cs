using System;

namespace OrderManagementSystem
{
    class Program
    {
        static void Main()
        {
            Order order = new Order();

            order.AddProduct(new RegularProduct("Milk", 40));
            order.AddProduct(new DiscountProduct("Phone", 10000, 10));
            order.AddProduct(new DiscountProduct("TV", 20000, 15));

            Console.WriteLine(order.GetTotalPrice());
        }
    }
}
    
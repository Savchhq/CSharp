namespace OrderManagementSystem
{
    public interface IProduct
    {
        string Name {get;}
        double Price {get;}
        double FinalyPrice();
    }
    public abstract class Product : IProduct 
    {
        public string Name { get; }
        public double Price { get;}
        protected Product(string name, double price)
        {
            Name = name;
            Price = price;
        }
        public abstract double FinalyPrice();
    }
    public class RegularProduct : Product
    {
        public RegularProduct(string name, double price) : base(name, price) { }
        public override double FinalyPrice()
        {
            return Price;
        }
    }
    public class DiscountProduct : Product
    {
        public readonly double _discount;
        public DiscountProduct(string name, double price, double discount) : base(name, price)
        {
            _discount = discount;
        }
        public override double FinalyPrice()
        {
            return Price - (Price * (_discount/100));
        }
    }
    
    public class Order
    {
        private List<IProduct> products;

        public Order()
        {
            products = new List<IProduct>();
        }
        public void AddProduct(IProduct product)
        {
            products.Add(product);
        }
        public double GetTotalPrice()
        {
            double total =0;
            foreach (var product in products)
            {
                total += product.FinalyPrice();
            }
           return total;
           
        }
    }

}

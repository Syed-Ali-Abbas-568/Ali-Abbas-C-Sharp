using System;
using System.Collections.Generic;
using System.Threading;

namespace StoreNotificationApp
{
    // Product class
    public class Product
    {
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
        public int DaysUntilAvailable { get; set; }
    }

    // Event arguments to pass product information
    public class ProductEventArgs : EventArgs
    {
        public Product Product { get; private set; }

        public ProductEventArgs(Product product)
        {
            Product = product;
        }
    }

    // Customer class
    public class Customer
    {
        public string Name { get; set; }

        public void OnProductAvailable(object sender, ProductEventArgs e)
        {
            Console.WriteLine($"Hello {Name}, the product '{e.Product.Name}' is now available in the store!");
        }

        public void OnProductDaysLeft(object sender, ProductEventArgs e)
        {
            if (e.Product.DaysUntilAvailable > 0)
            {
                Console.WriteLine($"Hello {Name}, the product '{e.Product.Name}' will be available in {e.Product.DaysUntilAvailable} days.");
            }
        }
    }

    // Store class
    public class Store
    {
        public string Name { get; set; }
        public event EventHandler<ProductEventArgs> ProductAvailable;
        public event EventHandler<ProductEventArgs> ProductDaysLeft;

        private List<Product> products = new List<Product>();

        public void AddProduct(Product product)
        {
            products.Add(product);
            if (product.IsAvailable)
            {
                OnProductAvailable(new ProductEventArgs(product));
            }
        }

        public void UpdateProductAvailability(string productName, int daysUntilAvailable)
        {
            var product = products.Find(p => p.Name == productName);
            if (product != null)
            {
                product.DaysUntilAvailable = daysUntilAvailable;

                while (product.DaysUntilAvailable > 0)
                {
                    OnProductDaysLeft(new ProductEventArgs(product));
                    Thread.Sleep(1000); // Simulate a day passing
                    product.DaysUntilAvailable--;
                }

                product.IsAvailable = true;
                OnProductAvailable(new ProductEventArgs(product));
            }
        }

        protected virtual void OnProductAvailable(ProductEventArgs e)
        {
            ProductAvailable?.Invoke(this, e);
        }

        protected virtual void OnProductDaysLeft(ProductEventArgs e)
        {
            ProductDaysLeft?.Invoke(this, e);
        }

        public List<Product> GetProducts()
        {
            return products;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create store and products
            Store store = new Store { Name = "Tech Store" };
            Product iPhone = new Product { Name = "iPhone", IsAvailable = false };
            Product laptop = new Product { Name = "Laptop", IsAvailable = false };
            Product tablet = new Product { Name = "Tablet", IsAvailable = false };

            store.AddProduct(iPhone);
            store.AddProduct(laptop);
            store.AddProduct(tablet);

            // Get customer details
            Console.Write("Enter your name: ");
            string customerName = Console.ReadLine();

            Console.WriteLine("Available products:");
            List<Product> products = store.GetProducts();
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i].Name}");
            }

            Console.Write("Choose a product by entering the number: ");
            int productChoice = Convert.ToInt32(Console.ReadLine()) - 1;

            if (productChoice < 0 || productChoice >= products.Count)
            {
                Console.WriteLine("Invalid choice. Exiting.");
                return;
            }

            Product chosenProduct = products[productChoice];

            // Create customer and subscribe to notifications for the chosen product
            Customer customer = new Customer { Name = customerName };
            store.ProductAvailable += customer.OnProductAvailable;
            store.ProductDaysLeft += customer.OnProductDaysLeft;

            Console.WriteLine($"You have subscribed to notifications for {chosenProduct.Name}.");

            // Simulate product availability update with days left
            Console.Write("Enter the number of days until the product is available: ");
            int daysUntilAvailable = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Updating product availability...");
            store.UpdateProductAvailability(chosenProduct.Name, daysUntilAvailable);

        
        }
    }

}

using System;
using System.Collections.Generic;

namespace StoreNotificationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Store store = Store.Instance;
            store.Name = "Tech Store";
            
            Product iPhone = new Product { Name = "iPhone", IsAvailable = false };
            Product laptop = new Product { Name = "Laptop", IsAvailable = false };
            Product tablet = new Product { Name = "Tablet", IsAvailable = false };

            store.AddProduct(iPhone);
            store.AddProduct(laptop);
            store.AddProduct(tablet);

            Console.Write("Enter your name: ");
            string customerName = Console.ReadLine();

            Console.WriteLine("Available products:");
            List<Product> products = store.GetProducts();
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i].Name}");
            }

            int productChoice;
            while (true)
            {
                Console.Write("Choose a product by entering the number: ");
                if (int.TryParse(Console.ReadLine(), out productChoice) && productChoice > 0 && productChoice <= products.Count)
                {
                    productChoice--;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }

            Product chosenProduct = products[productChoice];

            Customer customer = new Customer { Name = customerName };
            store.ProductAvailable += customer.OnProductAvailable;
            store.ProductDaysLeft += customer.OnProductDaysLeft;

            Console.WriteLine($"You have subscribed to notifications for {chosenProduct.Name}.");

            int daysUntilAvailable;
            while (true)
            {
                Console.Write("Enter the number of days until the product is available: ");
                if (int.TryParse(Console.ReadLine(), out daysUntilAvailable) && daysUntilAvailable >= 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number of days.");
                }
            }

            Console.WriteLine("Updating product availability...");
            store.UpdateProductAvailability(chosenProduct.Name, daysUntilAvailable, customer);
        }
    }
}

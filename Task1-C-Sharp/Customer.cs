using System;

namespace StoreNotificationApp
{
    public class Customer
    {
        public string Name { get; set; }

        public void OnProductAvailable(object sender, ProductEventArgs e)
        {
            Console.WriteLine($"Hello {Name}, the product '{e.Product.Name}' is now available in the store!");
            PromptUnsubscribe(e);
        }

        public void OnProductDaysLeft(object sender, ProductEventArgs e)
        {
            if (e.Product.DaysUntilAvailable > 0)
            {
                Console.WriteLine($"Hello {Name}, the product '{e.Product.Name}' will be available in {e.Product.DaysUntilAvailable} days.");
                PromptUnsubscribe(e);
            }
        }

        private void PromptUnsubscribe(ProductEventArgs e)
        {
            Console.WriteLine("Do you want to unsubscribe from notifications for this product? (y/n)");
            string response = Console.ReadLine().ToLower();
            if (response == "y")
            {
                e.Customer.Unsubscribe(e.Product.Name);
            }
        }

        public void Unsubscribe(string productName)
        {
            Store.Instance.UnsubscribeProductAvailability(productName, this);
            Console.WriteLine($"You have unsubscribed from notifications for {productName}.");
        }
    }
}

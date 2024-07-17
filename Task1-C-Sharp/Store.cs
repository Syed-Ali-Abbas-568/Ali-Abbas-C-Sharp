using System;
using System.Collections.Generic;
using System.Threading;

namespace StoreNotificationApp
{
    public class Store
    {
        private static Store instance;
        public static Store Instance => instance ?? (instance = new Store());

        public string Name { get; set; }
        public event EventHandler<ProductEventArgs> ProductAvailable;
        public event EventHandler<ProductEventArgs> ProductDaysLeft;

        private List<Product> products = new List<Product>();

        public void AddProduct(Product product)
        {
            products.Add(product);
            if (product.IsAvailable)
            {
                OnProductAvailable(new ProductEventArgs(product, null));
            }
        }

        public void UpdateProductAvailability(string productName, int daysUntilAvailable, Customer customer)
        {
            var product = products.Find(p => p.Name == productName);
            if (product != null)
            {
                product.DaysUntilAvailable = daysUntilAvailable;
                product.ReleaseDate = DateTime.Now.AddDays(daysUntilAvailable);

                while (product.DaysUntilAvailable > 0)
                {
                    OnProductDaysLeft(new ProductEventArgs(product, customer));
                    Thread.Sleep(1000); // Simulate a day passing
                    product.DaysUntilAvailable--;
                }

                product.IsAvailable = true;
                OnProductAvailable(new ProductEventArgs(product, customer));
            }
        }

        public void UnsubscribeProductAvailability(string productName, Customer customer)
        {
            ProductAvailable -= customer.OnProductAvailable;
            ProductDaysLeft -= customer.OnProductDaysLeft;
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
}

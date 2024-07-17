using System;

namespace StoreNotificationApp
{
    public class ProductEventArgs : EventArgs
    {
        public Product Product { get; private set; }
        public Customer Customer { get; private set; }

        public ProductEventArgs(Product product, Customer customer)
        {
            Product = product;
            Customer = customer;
        }
    }
}

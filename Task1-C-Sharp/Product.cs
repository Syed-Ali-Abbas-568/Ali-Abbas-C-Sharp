using System;

namespace StoreNotificationApp
{
    public class Product
    {
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
        public int DaysUntilAvailable { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace TelerikTest02.Models
{
    public partial class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ValidFrom { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public int CategoryId { get; set; }

        public Categories CategoryNavigation { get; set; }
    }
}

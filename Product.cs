using System;
using System.Collections.Generic;

namespace WebTestApplication
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public bool? IsGstapplicable { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public DateTime? ExpiryDatetime { get; set; }
        public string Color { get; set; }
    }
}

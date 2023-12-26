using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace b161200020.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public double Price { get; set; }
        public int StockQuantity { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }

        public int CategoryId { get; set; }
    }
}
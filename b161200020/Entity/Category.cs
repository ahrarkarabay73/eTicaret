using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace b161200020.Entity
{
    public class Category
    {
        public int Id { get; set; }
        //data annotations
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Category Description")]
        public string Description { get; set; }
        public List<Product> Products { get; set; }
    }
}
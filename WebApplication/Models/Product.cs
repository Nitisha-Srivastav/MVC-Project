using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Product
    {

        public int Id { get; set; }

        [DisplayName("Product Name")]
        public string ProductName { get; set; }

        [DisplayName("Product Description")]
        public string ProductDescription { get; set; }

        [DisplayName("Product Image")]
        public string ProductImg { get; set; }

        [DisplayName("Product Price")]
        public Nullable<decimal> ProductPrice { get; set; }
    }
}
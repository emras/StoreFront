using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store_Front.Models
{
    public class ShoppingCartProductViewModel
    {

        public int ProductID { get; set; }

        public String ProductName { get; set; }

        public String ImageFile { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
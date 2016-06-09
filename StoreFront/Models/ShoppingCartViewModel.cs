using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store_Front.Models;

namespace Store_Front.Models
{
    public class ShoppingCartViewModel:CustomerBaseViewModel
    {
        public int ShoppingCartViewModelId { get; set; }
        public IEnumerable<spGetShoppingCartItems_Result> ShoppingCartItems { get; set; }

    }
}
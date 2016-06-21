using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store_Front.Models
{
    public class SearchResultsViewModel:CustomerBaseViewModel
    {
        [Display(Name ="Name")]
        public string ProductName { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name ="Image")]
        public string ImageFile { get; set; }

        public int ProductID { get; set; }
    }
}
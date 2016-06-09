using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store_Front.Models;
using System.ComponentModel.DataAnnotations;

namespace Store_Front.Models
{

    public class CustomerBaseViewModel
    {
        public string UserName
        {
            get { return "emras"; }
            set { }
        }
        [Key]
        public int UserID
        {
            get { return 15; }
            set { }
        }
    }
}
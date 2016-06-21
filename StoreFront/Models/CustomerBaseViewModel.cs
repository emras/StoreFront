using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Store_Front.Models
{

    public class CustomerBaseViewModel
    {

        public string Name { get; set; }

        public int UserID { get;set; }


        public string getUserName(int id)
        {
            using (var db = new StoreFrontDB())
            {
                this.Name = db.User.Find(id).UserName;
            }
           
            return this.Name;
        }
    }

}
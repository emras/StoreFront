using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;

namespace Store_Front.Models
{
    public class LoginViewModel : CustomerBaseViewModel
    {
        [Required(ErrorMessage = "Please enter a user name.")]
        [Display(Name = "User Name")]
        [StringLength(200)]
        public string  UserName { get; set; }

        [Required(ErrorMessage = "Please enter password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }



        public User IsValid()
        {
            User user = null;

            using (var db = new StoreFrontDB())
            {
                user = (from u in db.User
                        select u).Where(u => u.UserName.Equals(this.UserName)).FirstOrDefault();

                if (user != null)
                {
                    this.UserID = user.UserID;
                    byte[] pw = this.hashPassword();
                    byte[] upw = user.Password;
                    if (upw.SequenceEqual(pw))
                    {
                        return user;
                    }else
                    {
                        return null;
                    }
                }
            }
            return user;
        }

        public byte[] hashPassword()
        {
            SHA256 sha = new SHA256CryptoServiceProvider();

            string pw = this.Password + this.UserID;

            byte[] pwBytes = Encoding.ASCII.GetBytes(pw);
            byte[] hashedResult = sha.ComputeHash(pwBytes);

            return hashedResult;

        }


    }
}
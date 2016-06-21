using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store_Front.Models;
using System.ComponentModel.DataAnnotations;

namespace Store_Front.Models
{
    public class ShoppingCartViewModel : CustomerBaseViewModel
    {

        public int ShoppingCartID { get; set; }
        public string Message { get; set; }
        public int CartCount { get; set; }
        public int deleteID { get; set; }
        public List<ShoppingCartProductViewModel> ShoppingCartItems { get; set; }

        public string removeProduct(int id)
        {

            using (StoreFrontDB db = new StoreFrontDB())
            {
                ShoppingCartProduct cartproduct = (from p in db.ShoppingCartProduct
                                                   where (p.ProductID == id && p.ShoppingCartID == ShoppingCartID)
                                                   select p).First();

                db.ShoppingCartProduct.Remove(cartproduct);
                ShoppingCartItems.RemoveAll(product => product.ProductID == id);

                var scart = db.ShoppingCart.Find(ShoppingCartID);
                scart.ModifiedBy = this.Name;
                scart.DateModified = System.DateTime.Now;
                db.SaveChanges();

                return db.Product.Find(cartproduct.ProductID).ProductName + " has been removed from your cart.";
            }

        }

        public string AddShoppingCartItem(int productID)
        {
            StoreFrontDB db = new StoreFrontDB();
            this.ShoppingCartID = this.getCart();

            var productToAdd = db.ShoppingCartProduct.Find(getCartItem(productID));
            var Cart = db.ShoppingCart.Find(this.ShoppingCartID);
            Cart.ModifiedBy = this.Name;
            Cart.DateModified = System.DateTime.Now;

            if (productToAdd.Quantity == null)
            {
                productToAdd.Quantity = 1;
                productToAdd.Price = (from p in db.Product
                                      where p.ProductID == productID
                                      select p.Price).FirstOrDefault();
            }
            else
            {
                productToAdd.Quantity = productToAdd.Quantity + 1;
                productToAdd.Price = (from p in db.Product
                                      where p.ProductID == productID
                                      select p.Price).FirstOrDefault() * productToAdd.Quantity;
            }

            productToAdd.DateModified = System.DateTime.Now;
            productToAdd.ModifiedBy = this.Name;

            db.SaveChanges();

            return "Item added to cart.";
        }

        public int getCart()
        {
            StoreFrontDB db = new StoreFrontDB();
            int cartID = (from c in db.ShoppingCart
                          where c.UserID == UserID
                          select c.ShoppingCartID).FirstOrDefault();

            if (cartID < 1)
            {
                var newCart = db.ShoppingCart.Create();
                newCart.UserID = UserID;
                newCart.DateCreated = System.DateTime.Now;
                newCart.CreatedBy = Name;
                db.ShoppingCart.Add(newCart);
                db.SaveChanges();
            }


            cartID = (from c in db.ShoppingCart
                      where c.UserID == UserID
                      select c.ShoppingCartID).FirstOrDefault();
            ShoppingCartID = cartID;

            return cartID;
        }

        public int getCartItem(int productID)
        {

            StoreFrontDB db = new StoreFrontDB();
            int cartProductID = (from c in db.ShoppingCartProduct
                                 where c.ShoppingCartID == ShoppingCartID && c.ProductID == productID
                                 select c.ShoppingCartProductID).FirstOrDefault();

            if (cartProductID < 1)
            {
                ShoppingCartProduct newCartProduct = db.ShoppingCartProduct.Create();
                newCartProduct.ProductID = productID;
                newCartProduct.ShoppingCartID = this.ShoppingCartID;
                newCartProduct.DateCreated = System.DateTime.Now;
                newCartProduct.CreatedBy = this.Name;
                db.ShoppingCartProduct.Add(newCartProduct);
                db.SaveChanges();
            }

            cartProductID = (from c in db.ShoppingCartProduct
                             where c.ShoppingCartID == ShoppingCartID && c.ProductID == productID
                             select c.ShoppingCartProductID).FirstOrDefault();

            return cartProductID;

        }

        public int getCartCount()
        {
            this.CartCount = 0;
            foreach (var item in ShoppingCartItems)
            {
                CartCount += (int)item.Quantity;
            }
            return this.CartCount;
        }

        public void getProducts()
        {
            using (var db = new StoreFrontDB())
            {
                ShoppingCartItems = (from i in db.ShoppingCartProduct
                                              join p in db.Product on i.ProductID equals p.ProductID
                                              where i.ShoppingCartID == ShoppingCartID
                                              select new ShoppingCartProductViewModel
                                              {
                                                  ProductID = i.ProductID,
                                                  ProductName = p.ProductName,
                                                  ImageFile = p.ImageFile,
                                                  Quantity = i.Quantity ?? 0,
                                                  Price = i.Quantity * p.Price ?? 999999
                                              }).ToList();

                return;
            }
        }
    }

}
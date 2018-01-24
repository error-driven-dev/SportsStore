using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class Cart
    {
        private List<CartItem> CartContents = new List<CartItem>();

        public virtual IEnumerable<CartItem> Contents => CartContents;

        public virtual void AddItem(Product product, int quantity)
        {   
            //check to see if item already exists in cartcontents; byt checking if any match with one sent from route and ave to item
            CartItem item = CartContents.Where(p => p.Product.ProductID == product.ProductID).FirstOrDefault();

            if (item == null)
            {
                CartContents.Add(new CartItem{Product = product, Quantity = quantity}
                );
            }
            else
            {
                item.Quantity += quantity;
            }
        }

        public virtual void RemoveItem(Product product)
        {
            CartContents.RemoveAll(i => i.Product.ProductID == product.ProductID);
        }

        public virtual decimal ComputeTotal()
        {
            return CartContents.Sum(ci => ci.Product.Price * ci.Quantity);
        }

        public virtual void ClearCart()
        {
            CartContents.Clear();
        }
    }

    public class CartItem
    {
        public int CartItemID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    public class CartController: Controller
    {
        private IProductRepository _respository;

        public CartController(IProductRepository respository)
        {
            _respository = respository;
        }

        private Cart GetCart()
        {

            var cart = HttpContext.Session.GetJobj<Cart>("Cart") ?? new Cart();
            return cart;
        }

        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJobj("Cart", cart);
        }

        public IActionResult Index()
        {
            return View(GetCart());
        }
        public IActionResult AddToCart(int productId)
        {   //using where below returns I querable object, whereas FirstOrDefaul rtns a single item
            Product product = _respository.Products.FirstOrDefault(p => p.ProductID == productId);
            var cart = GetCart();
            cart.AddItem(product, 1);
            SaveCart(cart);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int productId)
        {
            var product = _respository.Products.FirstOrDefault(p => p.ProductID == productId);
            var cart = GetCart();
            cart.RemoveItem(product);
            SaveCart(cart);
            return RedirectToAction("Index");
        }
    }
}

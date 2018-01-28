using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class CartController: Controller
    {
        private IProductRepository _respository;
        private Cart _cart;
        
        //repo amd carServce objects are auto created according to config file when the MVC calls this controller ctor
        public CartController(IProductRepository respository, Cart cartService)
        {
            _respository = respository;
            _cart = cartService;
        }


        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel {
                Cart=_cart, ReturnUrl = returnUrl
            });
        }
        public RedirectToActionResult AddToCart(int productId, string returnUrl)
        {   //using where below returns I querable object, whereas FirstOrDefaul rtns a single item
            Product product = _respository.Products.FirstOrDefault(p => p.ProductID == productId);
            //*****provided by SessionCart service, no longer needed****
//        **var cart = GetCart();
            if (product != null)
            {
                _cart.AddItem(product, 1);
            }

//          **SaveCart(cart);
            return RedirectToAction("Index", new{returnUrl});
        }

        public RedirectToActionResult RemoveFromCart(int productId, string returnUrl)
        {
            var product = _respository.Products.FirstOrDefault(p => p.ProductID == productId);
//          **var cart = GetCart();
            if (product != null)
            {
                _cart.RemoveItem(product);
            }

//          **SaveCart(cart);
            return RedirectToAction("Index", new{returnUrl});
        }



   //**removed code pertaining to session storage and created a new SessionCart class (service) which inherits Cart class and adds session finctionality
//        private Cart GetCart()
//        {
//            var cart = HttpContext.Session.GetJobj<Cart>("Cart") ?? new Cart();
//            return cart;
//        }
//        private void SaveCart(Cart cart)
//        {
//            HttpContext.Session.SetJobj("Cart", cart);
//        }
    }
}

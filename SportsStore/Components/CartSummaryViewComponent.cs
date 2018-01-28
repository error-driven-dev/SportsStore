//model for cart wideget and subtotal on top right of page
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Components
{
    
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart _cart;

        public CartSummaryViewComponent(Cart cart)
        {
            _cart = cart;
        }

        public IViewComponentResult Invoke()
        {
            return View(_cart);
        }
    }

}


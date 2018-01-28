/*SERVICE:combines the cart class with functionality to save cart in session -- thereby removing the logic from the controller. inherits cart and adds the session storage
 capabilities to the base methods. Must be registered so that only single instance is used whereever cart is called in rest of program*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace SportsStore.Models
{
    public class SessionCart : Cart
    {
        public static Cart GetCart(IServiceProvider services)
        {
            //geting required service of an HttpContext accessor object then getting the HttpContext.Session components -- all this creates the ISession object
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            //gets contents of session at "Cart and if empty, creates one.    
            SessionCart cart = session?.GetJson<SessionCart>("Cart") ?? new SessionCart();
            cart.Session = session;
            return cart;
        }
        [JsonIgnore]
        public ISession Session { get; set; }

        //Following methods combine parent class and session. implements functionality of parent menthod and extends it to save to serialized object to cart
        public override void AddItem(Product product, int quantity)
        {   
           base.AddItem(product, quantity);
            Session.SetJson("Cart", this);
        }

        public override void RemoveItem(Product product)
        {
            base.RemoveItem(product);
            Session.SetJson("Cart",this);
        }

        public override void ClearCart()
        {
            base.ClearCart();
            Session.Remove("Cart");
        }
    }
}

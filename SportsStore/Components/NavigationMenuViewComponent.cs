//Navigation component: logic that queries all the available categories from the repository and sends them to the defualt view for the cartcontroller
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Components
{
    public class NavigationMenuViewComponent:ViewComponent
    {
        private  IProductRepository _repository;

        public NavigationMenuViewComponent(IProductRepository repository)
        {
            _repository = repository;
        }
// enter into html using @await Component.InvokeAsync("NavigationMenu")
//this builds the "defult" view (html component) in the components folder and plugs it in whereever the above method is called, typically on Layout

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(_repository.Products.Select(x => x.Category).Distinct().OrderBy(x => x));
        }

    }
}

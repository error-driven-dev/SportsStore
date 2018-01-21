using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        /*when default url is called by browser, MVC creates this controller -- it inits instance of IPR according to configuration file to pass to ctor and set to the Repository prop, which can be used by other
        actions in the class */
        public ProductController(IProductRepository repo)
        {
            this.repository = repo;
        }
        //default action -- method that returns the result of the View method and passing the vals of the products property of the repository field.
        public ViewResult List() => View(repository.Products);
    }
}

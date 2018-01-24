using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _repository;
        /*when default url is called by browser, MVC creates this controller -- it inits instance of IPR according to configuration file to pass to ctor and set to the Repository prop, which can be used by other
        actions in the class */
        public int PageSize = 4;
        
        public ProductController(IProductRepository repo)
        {
            _repository = repo;
        }
        //default action -- method that returns the result of the View method and passing the vals of the products property of the repository field.
        public ViewResult List(string category, int productPage = 1)
        {
            //passes a single object to the view...2 objects were combined into a single viewmodel for this purpose)
            return View( new ProductsListViewModel { 
                Products =_repository.Products.Where(p => category == null || p.Category== category).OrderBy(p => p.ProductID).Skip((productPage - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo{CurrentPage = productPage, ItemsPerPage = PageSize,
                    TotalItems = (category == null ?_repository.Products.Count(): _repository.Products.Count(p => p.Category == category))}, CurrentCategory = category});
        }

        public string Next()
        {
            return "next";
        }


    }
}

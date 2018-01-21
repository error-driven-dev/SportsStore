using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class FakeProductRepository : IProductRepository
    {   
        //a repo that implements the IProdRepo inerface requiring it to implement a IQuery collection of products
        public IQueryable<Product> Products => new List<Product>
        {   //creates a list using object init and sets to the Products property, then uses meth to convert to Querable as per return data type requirement
            new Product {Name = "Football", Price = 25},
            new Product {Name = "Surf board", Price = 179},
            new Product {Name = "Running shoes", Price = 95}
        }.AsQueryable<Product>();
    }
}

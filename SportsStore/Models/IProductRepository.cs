using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public interface IProductRepository
    {
        //creating a Repository interface that requires the implementation of a property called Products which is an Iquerable collection of product types
        
       IQueryable<Product> Products { get; }
        //register this service in ConfigSvces to allow controllers to get objects that implement this interface without specifying a specific class
    }
}

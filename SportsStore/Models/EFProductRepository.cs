using System.Linq;

namespace SportsStore.Models
{
    class EFProductRepository : IProductRepository
    {   //primarily maps the the Products property of the IRepo to the property in AppDBContext class

        private ApplicationDbContext _context;
        //??ctor, this is auto called when object is needed by controller and AppDbCont object is passed in (Products of DBset type which imple an IQuerable and therefore can be cast below and set to Products property)

        public EFProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        // taks the object set to _context and converts to IQuerable called Products
        public IQueryable<Product> Products => _context.Products;
    }
}
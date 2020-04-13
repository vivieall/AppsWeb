using Models;
using Persistence.Database;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class ProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context) 
        {
            _context = context;
        }

        public bool ExistsByName(string name)
        {
            return _context.Products
                           .Any(x => x.Name == name);
        }

        public IEnumerable<Product> GetAll(bool filterByAmp = false) 
        {
            return _context.Products
                           .Where(x =>
                                !filterByAmp || x.Name.StartsWith("Amplificador")
                            )
                           .ToList();
        }

        public IEnumerable<Product> GetPaged(int page, int take) 
        {
            return _context.Products
                           .OrderBy(x => x.Name)
                           .Skip(page * take)
                           .Take(take)
                           .ToList();
        }
    }
}

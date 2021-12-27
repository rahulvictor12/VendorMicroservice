using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using ProductMicroservice.Context;
using ProductMicroservice.Model;

namespace ProductMicroservice.Functions
{
    public class FunctionRepository:IFunctionRepository
    {
        private readonly ProductContext _dbContext;
        public FunctionRepository(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Product> GetAllProduct()
        {
            return _dbContext.Products.ToList();
        }
        public IEnumerable<Product> SearchProductByID(int Id)
        {

            IEnumerable<Product> p = _dbContext.Products.Where(p => p.Id == Id);
            return p;
        }

        public IEnumerable<Product> SearchProductByName(string name)
        {
            IEnumerable<Product> P = _dbContext.Products.Where(p => p.Name.Contains(name));
            return P;
        }

    }
}

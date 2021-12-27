using System;
using System.Collections.Generic;
using ProductMicroservice.Model;
using System.Linq;
using System.Threading.Tasks;
using ProductMicroservice.Model;

namespace ProductMicroservice
{
    public interface IFunctionRepository
    {
        public List<Product> GetAllProduct();
        public IEnumerable<Product> SearchProductByID(int Id);
        public IEnumerable<Product> SearchProductByName(string Name);

    }
}

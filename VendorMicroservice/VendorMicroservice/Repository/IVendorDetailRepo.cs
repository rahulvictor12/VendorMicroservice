using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorMicroservice.Models;

namespace VendorMicroservice.Repository
{
    public interface IVendorDetailRepo<T>
    {
        public IEnumerable<Vendor> GetAll();
        public IEnumerable<Vendor> GetVendor(int id);
        public void PostStock(VendorStock vs);
    }
}

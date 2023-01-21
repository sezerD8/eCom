using BusinnesLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Concrete
{
    public class BrandRepository : GenericRepository<Brand>
    {
        DataContext db = new DataContext();
        public List<Product> BrandDetails(int id)
        {
            return db.Products.Where(x => x.BrandId == id).ToList();
        }
    }
}

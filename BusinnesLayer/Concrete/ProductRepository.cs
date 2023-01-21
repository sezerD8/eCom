using BusinnesLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Concrete
{
    public class ProductRepository:GenericRepository<Product>
    {
        DataContext db = new DataContext();
        public List<Product> products()
        {
            return db.Products.Where(x => x.Popular == true).Take(6).ToList();
        }
    }
}

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
    public class GenderRepository: GenericRepository<Gender>
    {
        DataContext db = new DataContext();
        public List<Product> GenderDetails(int id)
        {
            return db.Products.Where(x => x.GenderId == id).ToList();
        }
    }
}

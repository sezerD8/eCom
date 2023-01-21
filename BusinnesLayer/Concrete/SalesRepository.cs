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
    public class SalesRepository:GenericRepository<Sales>
    {
        DataContext db = new DataContext();
        public List<Sales> SalesDetails(int id)
        {
            return db.Sales.Where(x => x.Id == id).ToList();
        }
    }
}

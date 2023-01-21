using EntityLayer;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{

    public class DataContext:DbContext
    {
        // protected override void OnConfiguring(DbContext)
        public DataContext() : base("name=connection") { }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}

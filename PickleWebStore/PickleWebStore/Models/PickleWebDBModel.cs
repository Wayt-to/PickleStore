using PickleWebStore.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace PickleWebStore
{
    public partial class PickleWebDBModel : DbContext
    {
        public PickleWebDBModel()
            : base("name=PickleWebDBModel")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Catalog> Catalogs { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}

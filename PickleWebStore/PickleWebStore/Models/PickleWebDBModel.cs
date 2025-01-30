using PickleWebStore.Models;
using System.Data.Entity;

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
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}

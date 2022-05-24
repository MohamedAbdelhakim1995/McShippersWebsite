using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace McShippersWebsite.Models
{
    public class Context:IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationUser> applicationUser { get; set; }
        public DbSet<Shipment> shipment { get; set; }
        public DbSet<Commodity> commodity{ get; set; }







        public Context() : base()
        {

        }


        public Context(DbContextOptions options) : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder ob)
        {
            ob.UseSqlServer(@"Data Source=DESKTOP-BFD20LM;Initial Catalog=McShippers;Integrated Security=True");

        }
    }
}

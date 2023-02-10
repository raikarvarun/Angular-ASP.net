using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{

    public class CardsDbContext : DbContext
    {
        public CardsDbContext(DbContextOptions options) : base(options)
        {

        }
        //Dbset

        public DbSet<Card> Cards { get; set; }
    }
}

using GreenBookWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenBookWeb.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }


    }
  
}

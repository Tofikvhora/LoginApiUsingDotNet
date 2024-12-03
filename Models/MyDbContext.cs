using Microsoft.EntityFrameworkCore;

namespace LoginApi.Models
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            
        }
        public DbSet<Users> Users { get; set; }
    }
}

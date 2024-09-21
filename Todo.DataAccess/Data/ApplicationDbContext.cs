using Microsoft.EntityFrameworkCore;
using Todo.Models;

namespace Todo.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Tasks> Tasks { get; set; }
    }
}

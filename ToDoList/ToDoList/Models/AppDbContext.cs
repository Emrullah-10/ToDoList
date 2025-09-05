using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}

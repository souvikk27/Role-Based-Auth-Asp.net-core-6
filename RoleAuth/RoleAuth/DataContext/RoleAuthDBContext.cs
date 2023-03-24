using Microsoft.EntityFrameworkCore;
using RoleAuth.Models;

namespace RoleAuth.DataContext
{
    public class RoleAuthDBContext : DbContext
    {
        public RoleAuthDBContext(DbContextOptions<RoleAuthDBContext> options) : base(options) 
        { 
        }
        public DbSet<Books> Book { get; set; }
        public DbSet<Roles> Role { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

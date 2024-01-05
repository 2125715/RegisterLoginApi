using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace RegisterLoginApi.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options):base(options) { }
        public DbSet<User> Users { get; set; }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebQueue.Models;

namespace WebQueue.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        DbSet<Message> Messages { get; set; }
        DbSet<Log> Logs { get; set; }
    }
}

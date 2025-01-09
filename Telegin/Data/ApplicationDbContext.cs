using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Telegin.UI.Models;
namespace Telegin.Data





{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<LocalUser> LocalUser {  get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }

}
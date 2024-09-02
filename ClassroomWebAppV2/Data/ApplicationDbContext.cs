using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ClassroomWebAppV2.Models;

namespace ClassroomWebAppV2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ClassroomWebAppV2.Models.Homework> Homework { get; set; } = default!;
    }
}

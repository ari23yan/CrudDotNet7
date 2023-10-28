using CrudDotNet7.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CrudDotNet7.Models.Context
{
    public class CrudDbContext : IdentityDbContext<User>
    {
        public CrudDbContext(DbContextOptions<CrudDbContext> options): base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}

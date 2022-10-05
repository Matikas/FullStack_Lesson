using FullStack.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStack.DAL
{
    public class FullStackDbContext : DbContext
    {
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<ContactDetail> ContactDetails { get; set; }

        public FullStackDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<ContactDetail>()
                .Property(p => p.Type)
                .HasConversion(
                    c => c.ToString(),
                    c => (ContactType)Enum.Parse(typeof(ContactType), c)
                );
        }
    }
}

using EF.demo.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.demo
{
    internal class SamuraiDbContext : DbContext
    {
        public SamuraiDbContext()
        {
                
        }
        public SamuraiDbContext(DbContextOptions options) :base(options)
        {
            
        }
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Battle> Battles { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=c:\\temp\\Samurai.db");
            optionsBuilder.LogTo(Console.WriteLine);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Quote>().HasKey(q => q.Id);
            modelBuilder.Entity<Samurai>().HasKey(s => s.Id);
            modelBuilder.Entity<Battle>().HasKey(b => b.Id);
            modelBuilder.Entity<Quote>().HasOne(q => q.Samurai).WithMany(s => s.Quotes).HasForeignKey(q => q.SamuraiId);
            modelBuilder.Entity<Samurai>().HasMany(s => s.Quotes).WithOne(q => q.Samurai).HasForeignKey(q => q.SamuraiId);  
        }
    }
}

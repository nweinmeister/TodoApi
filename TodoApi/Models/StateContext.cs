using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class StateContext : DbContext
    {
        public StateContext(DbContextOptions<StateContext> options)
            : base(options)
        {
        }

        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<State>()
                .HasOne(c => c.Country)
                .WithMany(s => s.States)
                .HasForeignKey(c => c.CountryId);
        }
    }
}
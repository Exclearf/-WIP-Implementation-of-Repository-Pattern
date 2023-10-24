using Microsoft.EntityFrameworkCore;
using RepoPatternApi.Models;

namespace RepoPatternApi.Context
{
    public class ExerciseContext : DbContext
    {
        public ExerciseContext(DbContextOptions<ExerciseContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\Exersices;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercise>()
                .Property(e => e.DateStart)
                .HasColumnType("datetime2");

            modelBuilder.Entity<Exercise>()
                .Property(e => e.DateEnd)
                .HasColumnType("datetime2");
        }

        public DbSet<Exercise> Exercises {get; set;}
    }
}

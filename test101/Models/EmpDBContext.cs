using Microsoft.EntityFrameworkCore;

namespace test101.Models
{
    public class EmpDBContext : DbContext
    {
        public EmpDBContext(DbContextOptions<EmpDBContext> options)
      : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<User>().ToTable("users");
        }


        public DbSet<Employee> Employee { get; set; }
        public DbSet<User> Users { get; set; }


    }
}

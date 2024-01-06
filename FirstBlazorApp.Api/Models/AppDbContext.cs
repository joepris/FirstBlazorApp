using FirstBlazorApp.Model;
using Microsoft.EntityFrameworkCore;

namespace FirstBlazorApp.Api.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed categories

            modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { JobCategoryId = 1, JobCategoryName = "Engineering" });
            modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { JobCategoryId = 2, JobCategoryName = "Sales" });
            modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { JobCategoryId = 3, JobCategoryName = "Management" });
            modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { JobCategoryId = 4, JobCategoryName = "Staff" });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 1,
                FirstName = "John",
                LastName = "Doe",
                Age = 12,
                Gender = Gender.Male,
                PhoneNumber = "587-123-4567",
                Email = "John.Doe@Email.com",
                MaritalStatus = MaritalStatus.Single

            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 2,
                FirstName = "Jane",
                LastName = "Doe",
                Age = 33,
                Gender = Gender.Female,
                PhoneNumber = "403-123-4567",
                Email = "Jane.Doe@Email.com",
                MaritalStatus = MaritalStatus.Married,

            });
        }
    }
}

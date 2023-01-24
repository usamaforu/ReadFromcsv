using DomainEntities;
using Microsoft.EntityFrameworkCore;

namespace DataAccesslayer.DataContext
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Employee2>Employee2s { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           

        }
    }



}


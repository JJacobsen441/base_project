using Base.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Base.Model
{
    public partial class BaseDB : DbContext
    {
        string CON = "DefaultConnection";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string con_string = BaseConfiguration.Get().GetConnectionString(CON);
            optionsBuilder
                .UseSqlite(con_string);

            //optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<Employee> employee { get; set; }
        public DbSet<Project> project { get; set; }
        public DbSet<Effort> effort { get; set; }
                
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Employee>().HasData(
            new Employee() { Id = 1, first_name = "John", last_name = "Doe" },
            new Employee() { Id = 2, first_name = "Kolton", last_name = "Sydnie" },
            new Employee() { Id = 3, first_name = "Joline", last_name = "Braelyn" },
            new Employee() { Id = 4, first_name = "Rusty", last_name = "Marjory" }
            );

            modelBuilder.Entity<Project>().HasData(
            new Project() { Id = 1, name = "Project 1" },
            new Project() { Id = 2, name = "Project 3" },
            new Project() { Id = 3, name = "Project 2" }
            );

            modelBuilder.Entity<Employee>().HasData(
            new Effort() { Id = 1, note = "Initial approach", hours = 4.5, day = 1648684800, employee_id = 1, project_id = 1 },
            new Effort() { Id = 1, note = "Random note 1", hours = 1.0, day = 1643673600, employee_id = 2, project_id = 3 },
            new Effort() { Id = 1, note = "Random note 2", hours = 3.25, day = 1643760000, employee_id = 2, project_id = 3 },
            new Effort() { Id = 1, note = "Random note 3", hours = 5.75, day = 1643932800, employee_id = 2, project_id = 3 },
            new Effort() { Id = 1, note = "Random note 4", hours = 2.0, day = 1644019200, employee_id = 2, project_id = 3 },
            new Effort() { Id = 1, note = "First day", hours = 5.5, day = 1646352000, employee_id = 1, project_id = 2 },
            new Effort() { Id = 1, note = "Second day", hours = 8.0, day = 1646524800, employee_id = 1, project_id = 2 }
            );/**/

            //modelBuilder.Entity<Efford>().Property(e => e.Id)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.effort)
                .WithOne(e => e.employee)
                //.WithOptional(e => e.employee)
                .HasForeignKey(e => e.employee_id);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.effort)
                .WithOne(e => e.project)
                //.WithOptional(e => e.employee)
                .HasForeignKey(e => e.project_id);
        }
    }
}/**/
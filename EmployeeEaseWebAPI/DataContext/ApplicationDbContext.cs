using EmployeesEaseWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeEaseWebAPI.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        public DbSet<EmployeesModel> Employees { get; set; }
    }
}


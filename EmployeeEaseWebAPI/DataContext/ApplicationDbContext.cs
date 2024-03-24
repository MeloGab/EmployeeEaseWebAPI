using EmployeesEaseWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeEaseWebAPI.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        #region Constructor

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        #endregion

        #region DbSet

        public DbSet<EmployeesModel> Employees { get; set; }

        #endregion

    }
}


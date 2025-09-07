using Microsoft.EntityFrameworkCore;
using MVCDay2.DAL.Entities;

namespace MVCDay2.DAL.Database
{
	public class ApplicationDbContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=.;Database=MVCDay2;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true	   ");
		}
		public DbSet<Employee> Employees { get; set; }
	}
}

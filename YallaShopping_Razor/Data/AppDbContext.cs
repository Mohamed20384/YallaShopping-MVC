using Microsoft.EntityFrameworkCore;
using YallaShopping_Razor.Models;

namespace YallaShopping_Razor.Data
{
	public class AppDbContext : DbContext
	{
		public DbSet<Category> Categories { get; set; }
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Category>().HasData
				(new Category { Id = 1, Name = "Electronics", DisplayOrder = 1 },
				new Category { Id = 2, Name = "Healthy Food", DisplayOrder = 2 },
				new Category { Id = 3, Name = "Kids", DisplayOrder = 3 },
				new Category { Id = 4, Name = "Food", DisplayOrder = 4 },
				new Category { Id = 5, Name = "Sweet", DisplayOrder = 5 }
				);


		}
	}
}
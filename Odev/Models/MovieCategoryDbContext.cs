using Microsoft.EntityFrameworkCore;

namespace Odev.Models
{
    public class MovieCategoryDbContext: DbContext
    {
        public DbSet<Movies> movies { get; set; }
        public DbSet<Category> category { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new MoviesConfiguration());  
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source= DESKTOP-Q56AEMU\\MSSQLKD14;Initial Catalog=MoviesCategoryDB;user id=sa;Password=Beste1998.");
            
        }
        //Category category1 = new Category()
        //{
        //    CategoryName = "Action",
        //    CategoryDescription = "Action Movies",
        //};
        //Category category2 = new Category()
        //{
        //    CategoryName = "Romance",
        //    CategoryDescription = "Romance Movies",
        //};
        //Category category3 = new Category()
        //{
        //    CategoryName = "Advanture",
        //    CategoryDescription = "Advanture Movies",
        //};
        //Category category4 = new Category()
        //{
        //    CategoryName = "Animated",
        //    CategoryDescription = "Animated Movies",
        //};
        //Category category5 = new Category()
        //{
        //    CategoryName = "Comedy",
        //    CategoryDescription = "Comedy Movies",
        //};
        //Movies movies1 = new Movies()
        //{
        //    MovieName = "Fast and Furious",
        //    IsVision = true,
        //    MovieDescription = "Fast & Furious is a media franchise centered on a series of action films that are largely concerned with family, heists, spies, and street racing.",
        //    ReleaseDate = DateTime.Now.AddDays(-20),
        //    CategoryID = 1,

        //};
        //Movies movies2 = new Movies()
        //{
        //    MovieName = "About Time",
        //    IsVision = false,
        //    MovieDescription = "Like all the men in his family, Tim Lake possesses the power to travel in time.",
        //    ReleaseDate = DateTime.Now.AddDays(-100),
        //    CategoryID = 2,

        //};
        //Movies movies3 = new Movies()
        //{
        //    MovieName = "Brave",
        //    IsVision = true,
        //    MovieDescription = "Merida, an independent archer, disobeys an ancient custom which unleashes a dark force.",
        //    ReleaseDate = DateTime.Now.AddDays(-10),
        //    CategoryID = 4,

        //};
    }
}

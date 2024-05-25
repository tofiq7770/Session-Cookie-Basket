using Fiorello.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderInfo> SliderInfos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Surprize> Surprizes { get; set; }
        public DbSet<SurprizeList> SurprizeLists { get; set; }
        public DbSet<Expert> Experts { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Instagram> Instagrams { get; set; }
        public DbSet<Setting> Settings { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Blog>()
        //                .HasData(
        //        new Blog
        //        {
        //            Id = 1,
        //            Title = "Flower Power",
        //            Description = "Class aptent taciti sociosqu ad litora torquent per conubia nostra, per",
        //            Date = DateTime.Now,
        //            Image = "blog-feature-img-1.jpg"

        //        },
        //        new Blog
        //        {
        //            Id = 2,
        //            Title = "Local Florists",
        //            Description = "Class aptent taciti sociosqu ad litora torquent per conubia nostra, per",
        //            Date = DateTime.Now,
        //            Image = "blog-feature-img-3.jpg"

        //        },
        //        new Blog
        //        {
        //            Id = 3,
        //            Title = "Flower Beauty",
        //            Description = "Class aptent taciti sociosqu ad litora torquent per conubia nostra, per",
        //            Date = DateTime.Now,
        //            Image = "blog-feature-img-4.jpg"

        //        }
        //        );
        //}

    }
}

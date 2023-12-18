using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.EntityFrameworkCore;
using project.Core.Models;
using Category = project.Core.Models.Category;

namespace project.data.DAL
{
   
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


      public DbSet<Category> Categories { get; set; }
      public DbSet<Portiofolio> Portiofolios { get; set; }



    }
}

using System.Data.Entity;

namespace AngularJSDemo.Models
{
    public class MovieDb : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
    }
}
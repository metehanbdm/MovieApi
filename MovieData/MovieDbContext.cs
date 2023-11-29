using Microsoft.EntityFrameworkCore;
using MovieData.Tables;
using System.Collections.Generic;

namespace MovieData
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
        }

        public DbSet<tb_Movie> tb_Movie { get; set; }
    }
}
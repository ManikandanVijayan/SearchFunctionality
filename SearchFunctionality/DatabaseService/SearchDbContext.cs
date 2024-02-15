using Microsoft.EntityFrameworkCore;
using SearchFunctionality.Models;
using System.Collections.Generic;


namespace SearchFunctionality.DatabaseService
{
    public class SearchDbContext : DbContext
    {
        public SearchDbContext(DbContextOptions<SearchDbContext> options)
            : base(options)
        {
        }
        public DbSet<SearchEntity> SearchItems { get; set; }
    }
}

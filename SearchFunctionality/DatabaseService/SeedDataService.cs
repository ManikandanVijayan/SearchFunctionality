using SearchFunctionality.Interfaces;
using SearchFunctionality.Models;

namespace SearchFunctionality.DatabaseService
{
    public class SeedDataService : ISeedDataService
    {
        public void Initialize(SearchDbContext context)
        {
            context.SearchItems.Add(new SearchEntity { Id = 1, Name = "Hari", Comment = "Hamlet" });
            context.SearchItems.Add(new SearchEntity { Id = 2, Name = "Das", Comment = "King Lear" });
            context.SearchItems.Add(new SearchEntity { Id = 3, Name = "James", Comment = "Othello" });

            context.SaveChanges();
        }
    }
}

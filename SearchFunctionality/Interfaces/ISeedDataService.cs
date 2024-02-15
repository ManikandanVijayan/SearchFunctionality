using SearchFunctionality.DatabaseService;

namespace SearchFunctionality.Interfaces
{
    public interface ISeedDataService
    {
        void Initialize(SearchDbContext context);
    }
}

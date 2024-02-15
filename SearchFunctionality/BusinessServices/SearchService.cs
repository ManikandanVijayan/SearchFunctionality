using SearchFunctionality.Interfaces;
using SearchFunctionality.Models;

namespace SearchFunctionality.BusinessServices
{
    /// <summary>
    /// Search Business logic service
    /// </summary>
    public class SearchService : ISearchService
    {
        private readonly ISearchDataService _searchDataService;

        /// <summary>
        /// Search the data based on the name
        /// </summary>
        /// <param name="searchDataService">searchDataService</param>
        public SearchService(ISearchDataService searchDataService)
        {
            _searchDataService = searchDataService;
         }

        /// <summary>
        /// Search the data based on the name
        /// </summary>
        /// <param name="searchValue">Search name</param>
        /// <param name="sortBy">Sorting order based on properties</param>
        /// <param name="sortType">Sorting type - asc or desc</param>
        /// <returns>The list of data.</returns>
        public List<SearchData> GetDataByFilter(string searchValue, string sortBy, string sortType)
        {
            return _searchDataService.GetDataByFilter(searchValue, sortBy, sortType);
        }
    }
}

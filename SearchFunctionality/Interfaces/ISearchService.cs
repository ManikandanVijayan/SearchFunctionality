using SearchFunctionality.Models;

namespace SearchFunctionality.Interfaces
{
    /// <summary>
    /// Search Interface service
    /// </summary>
    public interface ISearchService
    {
        /// <summary>
        /// Search the data based on the name
        /// </summary>
        /// <param name="searchValue">Search name</param>
        /// <param name="sortBy">Sorting order based on properties</param>
        /// <param name="sortType">Sorting type - asc or desc</param>
        /// <returns>The list of data.</returns>
        List<SearchData> GetDataByFilter(string searchValue, string sortBy, string sortType);
    }
}

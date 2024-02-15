using SearchFunctionality.Models;

namespace SearchFunctionality.Interfaces
{
    /// <summary>
    /// Search DataService interface
    /// </summary>
    public interface ISearchDataService
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

using AutoMapper;
using SearchFunctionality.Interfaces;
using SearchFunctionality.Models;
using System.Globalization;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SearchFunctionality.DatabaseService
{
    /// <summary>
    /// Search Data Service
    /// </summary>
    public class SearchDataService : ISearchDataService
    {
        private readonly SearchDbContext _searchDbContext;

        /// <summary>
        /// Search the data based on the name
        /// </summary>
        /// <param name="searchDbContext">searchDbContext</param>
        public SearchDataService(SearchDbContext searchDbContext)
        {
            _searchDbContext = searchDbContext;
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
            List<SearchData> searchDatas = new List<SearchData>();
            var searchData = _searchDbContext.SearchItems.Where(x => x.Name.ToLower().Contains(searchValue.ToLower()));
            if(searchData.Any())
            {
                switch (sortBy.ToLower())
                {
                    case "name":
                        if (sortType.ToLower() == "asc")
                        {
                            searchData = searchData.OrderBy(c => c.Name);
                        }
                        else
                        {
                            searchData = searchData.OrderByDescending(c => c.Name);
                        }

                        break;
                    case "comment":
                        if (sortType.ToLower() == "asc")
                        {
                            searchData = searchData.OrderBy(c => c.Comment);
                        }
                        else
                        {
                            searchData = searchData.OrderByDescending(c => c.Comment);
                        }
                        break;
                    case "id":
                        if (sortType.ToLower() == "asc")
                        {
                            searchData = searchData.OrderBy(c => c.Id);
                        }
                        else
                        {
                            searchData = searchData.OrderByDescending(c => c.Id);
                        }
                        break;
                }
                foreach(var s in searchData)
                {
                    var se = new SearchData();
                    se.Id = s.Id;
                    se.Name = s.Name;
                    se.Comment = s.Comment;
                    searchDatas.Add(se);
                }
            }
            return searchDatas;
        }
    }
}

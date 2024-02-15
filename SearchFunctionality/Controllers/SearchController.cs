using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SearchFunctionality.Interfaces;
using SearchFunctionality.Models;
using System.Linq;

namespace SearchFunctionality.Controllers
{
    /// <summary>
    /// Search Controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;
        private readonly ILogger<SearchController> _logger;

        /// <summary>
        /// Search the data based on the name
        /// </summary>
        /// <param name="logger">logger</param>
        /// <param name="searchService"></param>
        public SearchController(ILogger<SearchController> logger, ISearchService searchService)
        {
            _logger = logger;
            _searchService = searchService;
         }

        /// <summary>
        /// Search the data based on the name
        /// </summary>
        /// <param name="searchValue">Search name</param>
        /// <param name="sortBy">Sorting order based on properties</param>
        /// <param name="sortType">Sorting type - asc or desc</param>
        /// <returns>The list of data.</returns>
        // GET: api/Search
        [HttpGet]
        public ActionResult<List<SearchData>> Get([FromQuery] string searchValue, string sortBy, string sortType)
        {
            var data =  this._searchService.GetDataByFilter(searchValue, sortBy, sortType);
            return Ok(data);
        }
    }
}
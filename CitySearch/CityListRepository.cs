using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitySearch.Interfaces;

namespace CitySearch
{
    /// <summary>
    /// City repository. I guess this should be a database of cities or something.
    /// </summary>
    /// <seealso cref="CitySearch.Interfaces.ICityListRepository" />
    public class CityListRepository : ICityListRepository
    {
        /// <summary>
        /// Gets the cities.
        /// </summary>
        /// <returns>The list of cities.</returns>
        public IEnumerable<string> GetCities()
        {
        }
    }
}

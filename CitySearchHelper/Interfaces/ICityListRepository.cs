using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitySearch.Interfaces
{
    /// <summary>
    /// Interface for the city list repository.
    /// </summary>
    public interface ICityListRepository
    {
        /// <summary>
        /// Gets the cities.
        /// </summary>
        /// <returns>A list of all cities in the repository.</returns>
        IEnumerable<string> GetCities();
    }
}

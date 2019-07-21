using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CitySearch.Dtos;
using CitySearch.Interfaces;
using Newtonsoft.Json;

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
            var jsonData = File.ReadAllText("world-cities.json");
            var worldCities = JsonConvert.DeserializeObject<IEnumerable<WorldCitiesDto>>(jsonData);
            var citiesList = worldCities.Select(wc => wc.Name);
            return citiesList;
        }
    }
}

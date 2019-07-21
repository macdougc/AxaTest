using System;
using System.Collections.Generic;
using System.Configuration;
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
        /// The json file configuration key.
        /// </summary>
        private const string JsonFileConfigKey = "CitiesJsonFileName";

        /// <summary>
        /// The city list.
        /// </summary>
        private readonly IEnumerable<string> _cityList;

        /// <summary>
        /// Initializes a new instance of the <see cref="CityListRepository"/> class.
        /// </summary>
        public CityListRepository()
        {
            var filename = ConfigurationManager.AppSettings[JsonFileConfigKey];
            var jsonData = File.ReadAllText("world-cities.json");
            var worldCities = JsonConvert.DeserializeObject<IEnumerable<WorldCitiesDto>>(jsonData);
            _cityList = worldCities.Select(wc => wc.Name);
        }

        /// <summary>
        /// Gets the cities.
        /// </summary>
        /// <returns>The list of cities.</returns>
        public IEnumerable<string> GetCities()
        {
            return _cityList;
        }
    }
}

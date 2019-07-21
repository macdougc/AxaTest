using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitySearch.Dtos
{
    /// <summary>
    /// DTO for the cities JSON file.
    /// </summary>
    public class WorldCitiesDto
    {
        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the geo name identifier.
        /// </summary>
        /// <value>
        /// The geo name identifier.
        /// </value>
        public int GeoNameId { get; set; }

        /// <summary>
        /// Gets or sets the sub country.
        /// </summary>
        /// <value>
        /// The sub country.
        /// </value>
        public string SubCountry { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitySearch.Interfaces;

namespace CitySearch
{
    /// <summary>
    /// Contains the results of the city search. If no cities were found then both fields will be null.
    /// </summary>
    /// <seealso cref="CitySearch.Interfaces.ICityResult" />
    public class CityResult : ICityResult
    {
        /// <summary>
        /// Gets or sets the next letters.
        /// </summary>
        /// <value>
        /// The next letters.
        /// </value>
        public ICollection<string> NextLetters { get; set; }

        /// <summary>
        /// Gets or sets the next cities.
        /// </summary>
        /// <value>
        /// The next cities.
        /// </value>
        public ICollection<string> NextCities { get; set; }
    }
}

using System.Collections.Generic;
using System.Linq;
using CitySearch.Interfaces;

namespace CitySearch
{
    /// <summary>
    /// Gets the next letter for the list of given cities.
    /// </summary>
    /// <seealso cref="CitySearch.Interfaces.ICityNextLetterHelper" />
    public class CityNextLetterHelper : ICityNextLetterHelper
    {
        /// <summary>
        /// Gets the next letters.
        /// </summary>
        /// <param name="cities">The cities.</param>
        /// <param name="searchString">The search string.</param>
        /// <returns>The next letters for the list of given cities.</returns>
        public IEnumerable<string> GetNextLetters(IEnumerable<string> cities, string searchString)
        {
            return cities.Select(city => city.Substring(searchString.Length, 1));
        }
    }
}

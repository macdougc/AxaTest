using System;
using System.Collections.Generic;
using System.Linq;
using CitySearch.Interfaces;

namespace CitySearch
{
    /// <summary>
    /// Finds the matching cities.
    /// </summary>
    /// <seealso cref="CitySearch.Interfaces.ICityNameFinder" />
    public class CityNameFinder : ICityNameFinder
    {
        /// <summary>
        /// Finds all cities beginning with substring.
        /// </summary>
        /// <param name="cityList">The city list.</param>
        /// <param name="subString">The sub string.</param>
        /// <returns>The list of matching cities in the list based on the subString.</returns>
        public IEnumerable<string> FindAllCitiesBeginningWithSubstring(IEnumerable<string> cityList, string subString)
        {
            if (subString.Length == 0)
            {
                return cityList;
            }

            var matchingCities = cityList.Where(city => city.StartsWith(subString, StringComparison.InvariantCultureIgnoreCase));

            return matchingCities;
        }
    }
}

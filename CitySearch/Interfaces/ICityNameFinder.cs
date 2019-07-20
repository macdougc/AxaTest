using System.Collections.Generic;

namespace CitySearch.Interfaces
{
    /// <summary>
    /// Helper for finding strings.
    /// </summary>
    public interface ICityNameFinder
    {
        /// <summary>
        /// Finds all cities in the list beginning with substring.
        /// </summary>
        /// <param name="cityList">The city list.</param>
        /// <param name="subString">The sub string.</param>
        /// <returns>All strings beginning with the substring.</returns>
        IEnumerable<string> FindAllCitiesBeginningWithSubstring(IEnumerable<string> cityList, string subString);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitySearch.Interfaces
{
    /// <summary>
    /// Helper for finding strings.
    /// </summary>
    public interface IStringFinder
    {
        /// <summary>
        /// Finds all strings in the list beginning with substring.
        /// </summary>
        /// <param name="stringList">The string list.</param>
        /// <param name="subString">The sub string.</param>
        /// <returns>All strings beginning with the substring.</returns>
        IEnumerable<string> FindAllStringsBeginningWithSubstring(IEnumerable<string> stringList, string subString);
    }
}

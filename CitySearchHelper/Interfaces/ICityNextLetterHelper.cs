using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitySearchHelper.Interfaces
{
    /// <summary>
    /// String prefix helper.
    /// </summary>
    public interface ICityNextLetterHelper
    {
        /// <summary>
        /// Gets the next letter for each city in the list.
        /// </summary>
        /// <param name="cities">The cities.</param>
        /// <param name="searchString">The search string.</param>
        /// <returns>A list of next letters.</returns>
        IEnumerable<string> GetNextLetters(IEnumerable<string> cities, string searchString);
    }
}

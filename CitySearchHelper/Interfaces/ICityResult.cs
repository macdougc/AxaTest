using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitySearch.Interfaces
{
    /// <summary>
    /// City Result interface.
    /// </summary>
    public interface ICityResult
    {
        /// <summary>
        /// Gets or sets the next letters.
        /// </summary>
        /// <value>
        /// The next letters.
        /// </value>
        ICollection<string> NextLetters { get; set; }

        /// <summary>
        /// Gets or sets the next cities.
        /// </summary>
        /// <value>
        /// The next cities.
        /// </value>
        ICollection<string> NextCities { get; set; }
    }
}

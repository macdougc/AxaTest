using System.Collections.Generic;

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

using System.Text.RegularExpressions;
using CitySearch.Interfaces;

namespace CitySearch
{
    /// <summary>
    /// Validates the user input. Only letters, space and dash are allowed.
    /// </summary>
    /// <seealso cref="CitySearch.Interfaces.IValidator" />
    public class UserInputValidator : IValidator
    {
        /// <summary>
        /// Returns true if input is valid.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        ///   <c>true</c> if the specified input is valid; otherwise, <c>false</c>.
        /// </returns>
        public bool IsValid(string input)
        {
            // Search for a character other than the allowed ones, will return true if invalid, so negate it.
            var regex = new Regex("[^ A-Za-z-]$");
            return !regex.IsMatch(input);
        }
    }
}

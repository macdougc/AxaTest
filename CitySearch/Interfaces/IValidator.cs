namespace CitySearch.Interfaces
{
    /// <summary>
    /// Validator interface.
    /// </summary>
    public interface IValidator
    {
        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        ///   <c>true</c> if the specified input is valid; otherwise, <c>false</c>.
        /// </returns>
        bool IsValid(string input);
    }
}

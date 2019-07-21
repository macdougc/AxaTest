namespace CitySearch.Interfaces
{
    /// <summary>
    /// Interface for the city finder class.
    /// </summary>
    public interface ICityFinder
    {
        /// <summary>
        /// Searches the specified search string.
        /// </summary>
        /// <param name="searchString">The search string.</param>
        /// <returns>A city result that contains a list of all matching cities and a list of allowable next characters.</returns>
        ICityResult Search(string searchString);
    }
}

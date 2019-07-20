using Autofac;
using CitySearch;

namespace CitySearchTestApp
{
    /// <summary>
    /// The program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            var container = CitySearchContainer.Build();

            var cityFinder = container.Resolve<CityFinder>();
        }
    }
}

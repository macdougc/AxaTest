using System;
using System.Linq;
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

            Console.WriteLine("Enter a search string...");

            var searchString = Console.ReadLine();

            var cityResults = cityFinder.Search(searchString);

            Console.WriteLine("Next allowable characters would be...");
            cityResults.NextLetters.ToList().ForEach(Console.WriteLine);

            Console.WriteLine("Matching cities are...");
            cityResults.NextCities.ToList().ForEach(Console.WriteLine);

            Console.ReadLine();
        }
    }
}

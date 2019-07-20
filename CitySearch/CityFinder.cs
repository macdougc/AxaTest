using System;
using System.Linq;
using CitySearch.Interfaces;

namespace CitySearch
{
    /// <summary>
    /// Helper class for finding cities based on a partial user text string.
    /// </summary>
    public class CityFinder : ICityFinder
    {
        /// <summary>
        /// The invalid input error message.
        /// </summary>
        private const string InvalidInputErrorMessage = "The user input must only contain a-z, A-Z, ' ' and '-'";

        /// <summary>
        /// The validator.
        /// </summary>
        private readonly IValidator _validator;

        /// <summary>
        /// The string finder.
        /// </summary>
        private readonly ICityNameFinder _cityNameFinder;

        /// <summary>
        /// The city next letter helper.
        /// </summary>
        private readonly ICityNextLetterHelper _cityNextLetterHelper;

        /// <summary>
        /// The city list repository.
        /// </summary>
        private readonly ICityListRepository _cityListRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CityFinder"/> class.
        /// </summary>
        /// <param name="cityListRepository">The city list repository.</param>
        /// <param name="validator">The validator.</param>
        /// <param name="cityNameFinder">The string finder.</param>
        /// <param name="cityNextLetterHelper">The next letter helper.</param>
        /// <exception cref="System.ArgumentNullException">
        /// validator
        /// or
        /// cityNameFinder
        /// or
        /// cityListRepository.
        /// </exception>
        public CityFinder(
            ICityListRepository cityListRepository,
            IValidator validator,
            ICityNameFinder cityNameFinder,
            ICityNextLetterHelper cityNextLetterHelper)
        {
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
            _cityNameFinder = cityNameFinder ?? throw new ArgumentNullException(nameof(cityNameFinder));
            _cityNextLetterHelper = cityNextLetterHelper ?? throw new ArgumentNullException(nameof(cityNextLetterHelper));
            _cityListRepository = cityListRepository ?? throw new ArgumentNullException(nameof(cityListRepository));
        }

        /// <summary>
        /// Searches the specified search string.
        /// </summary>
        /// <param name="searchString">The search string.</param>
        /// <returns>
        /// A city result that contains a list of all matching cities and a list of allowable next characters.
        /// </returns>
        public ICityResult Search(string searchString)
        {
            if (!_validator.IsValid(searchString))
            {
                throw new ArgumentOutOfRangeException(nameof(searchString), InvalidInputErrorMessage);
            }

            var cityList = _cityListRepository.GetCities();
            var cities = _cityNameFinder.FindAllCitiesBeginningWithSubstring(cityList, searchString);
            var validNextLetters = _cityNextLetterHelper.GetNextLetters(cities, searchString);

            var cityResult = new CityResult
            {
                NextCities = cities.ToList(),
                NextLetters = validNextLetters.ToList(),
            };

            return cityResult;
        }
    }
}

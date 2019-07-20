using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitySearch;
using CitySearch.Interfaces;
using CitySearchHelper.Interfaces;

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
        private readonly IStringFinder _stringFinder;

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
        /// <param name="stringFinder">The string finder.</param>
        /// <param name="cityNextLetterHelper">The next letter helper.</param>
        /// <exception cref="System.ArgumentNullException">
        /// validator
        /// or
        /// stringFinder
        /// or
        /// cityListRepository.
        /// </exception>
        public CityFinder(
            ICityListRepository cityListRepository,
            IValidator validator,
            IStringFinder stringFinder,
            ICityNextLetterHelper cityNextLetterHelper)
        {
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
            _stringFinder = stringFinder ?? throw new ArgumentNullException(nameof(stringFinder));
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
            var cities = _stringFinder.FindAllStringsBeginningWithSubstring(cityList, searchString);
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

using System.Collections.Generic;
using System.Linq;
using CitySearch;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CitySearchTests
{
    /// <summary>
    /// Summary description for CityNameFinder
    /// </summary>
    [TestClass]
    public class CityNameFinderTests
    {
        private readonly CityNameFinder _underTest;

        public CityNameFinderTests()
        {
            _underTest = new CityNameFinder();
        }

        [TestMethod]
        public void FindAllCitiesBeginningWithSubstring_EnsureCorrect()
        {
            // Arrange
            var cities = new List<string>()
            {
                "ldkjsafghljkhf",
                "eWrwrewr",
                "afsdfasdf",
                "afsdfwerwr",
                "werewrew",
                "awerfasdf",
                "ewrdffsfdsf",
                "awerfasdf",
                "ewRsdfghsdf",
            };

            var searchString = "Ewr";

            // Act
            var matchedCities = _underTest.FindAllCitiesBeginningWithSubstring(cities, searchString).ToList();

            // Assert
            matchedCities.Count.Should().Be(3);
            matchedCities[0].Should().BeEquivalentTo("eWrwrewr");
            matchedCities[1].Should().BeEquivalentTo("ewrdffsfdsf");
            matchedCities[2].Should().BeEquivalentTo("ewRsdfghsdf");
        }

        [TestMethod]
        public void FindAllCitiesBeginningWithSubstring_GivenDuplicateNames_EnsureCorrect()
        {
            // Arrange
            var cities = new List<string>()
            {
                "ldkjsafghljkhf",
                "eWrwrewr",
                "afsdfasdf",
                "afsdfwerwr",
                "werewrew",
                "awerfasdf",
                "ewRsdfghsdf",
                "awerfasdf",
                "ewRsdfghsdf",
            };

            var searchString = "Ewr";

            // Act
            var matchedCities = _underTest.FindAllCitiesBeginningWithSubstring(cities, searchString).ToList();

            // Assert
            matchedCities.Count.Should().Be(2);
            matchedCities[0].Should().BeEquivalentTo("eWrwrewr");
            matchedCities[1].Should().BeEquivalentTo("ewRsdfghsdf");
        }

        [TestMethod]
        public void FindAllCitiesBeginningWithSubstring_GivenNoMatches_EnsureCorrect()
        {
            // Arrange
            var cities = new List<string>()
            {
                "ldkjsafghljkhf",
                "eWrwrewr",
                "afsdfasdf",
                "afsdfwerwr",
                "werewrew",
                "awerfasdf",
                "ewrdffsfdsf",
                "awerfasdf",
                "ewRsdfghsdf",
            };

            var searchString = "aaaa";

            // Act
            var matchedCities = _underTest.FindAllCitiesBeginningWithSubstring(cities, searchString).ToList();

            // Assert
            matchedCities.Count.Should().Be(0);
        }

        [TestMethod]
        public void FindAllCitiesBeginningWithSubstring_GivenEmptySearch_EnsureCorrect()
        {
            // Arrange
            var cities = new List<string>()
            {
                "ldkjsafghljkhf",
                "eWrwrewr",
                "afsdfasdf",
                "afsdfwerwr",
                "werewrew",
                "awerfasdf",
                "ewrdffsfdsf",
                "awerfasdf",
                "ewRsdfghsdf",
            };

            var searchString = "";

            // Act
            var matchedCities = _underTest.FindAllCitiesBeginningWithSubstring(cities, searchString).ToList();

            // Assert
            matchedCities.Should().BeEquivalentTo(cities);
        }
    }
}

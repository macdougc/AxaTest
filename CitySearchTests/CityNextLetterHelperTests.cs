using System.Collections.Generic;
using System.Linq;
using CitySearch;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CitySearchTests
{
    /// <summary>
    /// Summary description for CityNextLetterHelperTests
    /// </summary>
    [TestClass]
    public class CityNextLetterHelperTests
    {
        private readonly CityNextLetterHelper _underTest;

        public CityNextLetterHelperTests()
        {
            _underTest = new CityNextLetterHelper();
        }

        [TestMethod]
        public void GetNextLetters_EnsureCorrect()
        {
            // Arrange
            var cities = new List<string>()
            {
                "GLASGOW",
                "BELFAST",
                "EDINBURGH",
                "NEWCASTLE",
                "LONDON",
            };

            var searchString = "Abcd";

            // Act
            var nextLetters = _underTest.GetNextLetters(cities, searchString).ToList();

            // Assert
            nextLetters.Count().Should().Be(5);
            nextLetters[0].Should().BeEquivalentTo("G");
            nextLetters[1].Should().BeEquivalentTo("A");
            nextLetters[2].Should().BeEquivalentTo("B");
            nextLetters[3].Should().BeEquivalentTo("A");
            nextLetters[4].Should().BeEquivalentTo("O");
        }
    }
}

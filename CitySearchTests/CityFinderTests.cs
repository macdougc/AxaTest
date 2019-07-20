using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using CitySearch;
using CitySearch.Interfaces;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CitySearchTests
{
    [TestClass]
    public class CityFinderTests
    {
        private readonly CityFinder _underTest;
        private readonly IFixture _fixture;
        private readonly Mock<IValidator> _validatorMock;
        private readonly Mock<ICityNameFinder> _cityNameFinderMock;
        private readonly Mock<ICityNextLetterHelper> _cityNextLetterHelperMock;
        private readonly Mock<ICityListRepository> _cityListRepositoryMock;

        private const string InvalidInputErrorMessage = "The user input must only contain a-z, A-Z, ' ' and '-'";

        public CityFinderTests()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization() { ConfigureMembers = true });
            _cityListRepositoryMock = _fixture.Freeze<Mock<ICityListRepository>>();
            _cityNextLetterHelperMock = _fixture.Freeze<Mock<ICityNextLetterHelper>>();
            _cityNameFinderMock = _fixture.Freeze<Mock<ICityNameFinder>>();
            _validatorMock = _fixture.Freeze<Mock<IValidator>>();

            _underTest = _fixture.Create<CityFinder>();
        }

        [TestInitialize]
        public void Initialise()
        {
            _validatorMock.Invocations.Clear();
            _cityNameFinderMock.Invocations.Clear();
            _cityNextLetterHelperMock.Invocations.Clear();
            _cityListRepositoryMock.Invocations.Clear();
        }

        [TestMethod]
        public void CityFinder_GivenNullCityListRepository_ExpectException()
        {
            try
            {
                var underTest = new CityFinder(
                    null,
                    _validatorMock.Object,
                    _cityNameFinderMock.Object,
                    _cityNextLetterHelperMock.Object);

                Assert.Fail("Should have thrown an exception.");
            }
            catch (ArgumentNullException e)
            {
                e.ParamName.Should().BeEquivalentTo("cityListRepository");
            }
        }

        [TestMethod]
        public void CityFinder_GivenNullValidator_ExpectException()
        {
            try
            {
                var underTest = new CityFinder(
                    _cityListRepositoryMock.Object,
                    null,
                    _cityNameFinderMock.Object,
                    _cityNextLetterHelperMock.Object);

                Assert.Fail("Should have thrown an exception.");
            }
            catch (ArgumentNullException e)
            {
                e.ParamName.Should().BeEquivalentTo("validator");
            }
        }

        [TestMethod]
        public void CityFinder_GivenNullCityNameFinder_ExpectException()
        {
            try
            {
                var underTest = new CityFinder(
                    _cityListRepositoryMock.Object,
                    _validatorMock.Object,
                    null,
                    _cityNextLetterHelperMock.Object);

                Assert.Fail("Should have thrown an exception.");
            }
            catch (ArgumentNullException e)
            {
                e.ParamName.Should().BeEquivalentTo("cityNameFinder");
            }
        }

        [TestMethod]
        public void CityFinder_GivenNullCityNextLetterHelper_ExpectException()
        {
            try
            {
                var underTest = new CityFinder(
                    _cityListRepositoryMock.Object,
                    _validatorMock.Object,
                    _cityNameFinderMock.Object,
                    null);

                Assert.Fail("Should have thrown an exception.");
            }
            catch (ArgumentNullException e)
            {
                e.ParamName.Should().BeEquivalentTo("cityNextLetterHelper");
            }
        }

        
        public void Search_GivenInvalidInput_ExpectException()
        {
            var searchString = _fixture.Create<string>();

            try
            {
                // Arrange
                _validatorMock.Setup(v => v.IsValid(It.IsAny<string>())).Returns(false);

                // Act
                _underTest.Search(searchString);

                Assert.Fail("Should have thrown an exception.");
            }
            catch (ArgumentOutOfRangeException e)
            {
                e.ParamName.Should().BeEquivalentTo("searchString");
                e.Message.Should().BeEquivalentTo(InvalidInputErrorMessage);
                _validatorMock.Verify(v => v.IsValid(searchString), Times.Once);
            }
        }

        [TestMethod]
        public void Search_GivenValidInput_EnsureCorrect()
        {
            // Arrange
            var searchString = _fixture.Create<string>();
            var expectedCities = _fixture.CreateMany<string>(5);
            var expectedNextLetters = _fixture.CreateMany<string>(5);
            var cities = _fixture.CreateMany<string>(10);

            _cityListRepositoryMock.Setup(repo => repo.GetCities()).Returns(cities);
            _validatorMock.Setup(v => v.IsValid(It.IsAny<string>())).Returns(true);

            _cityNameFinderMock
                .Setup(s => s.FindAllCitiesBeginningWithSubstring(It.IsAny<IEnumerable<string>>(), It.IsAny<string>()))
                .Returns(expectedCities);

            _cityNextLetterHelperMock
                .Setup(c => c.GetNextLetters(It.IsAny<IEnumerable<string>>(), It.IsAny<string>()))
                .Returns(expectedNextLetters);

            // Act
            var cityResult = _underTest.Search(searchString);

            // Assert
            cityResult.Should().NotBeNull();
            cityResult.NextCities.Should().BeEquivalentTo(expectedCities);
            cityResult.NextLetters.Should().BeEquivalentTo(expectedNextLetters);

            _validatorMock.Verify(v => v.IsValid(searchString), Times.Once);
            _cityListRepositoryMock.Verify(repo => repo.GetCities(), Times.Once);
            _cityNextLetterHelperMock.Verify(c => c.GetNextLetters(expectedCities, searchString), Times.Once);
            _cityNameFinderMock.Verify(s => s.FindAllCitiesBeginningWithSubstring(cities, searchString), Times.Once);
        }
    }
}

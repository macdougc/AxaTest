using CitySearch;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CitySearchTests
{
    /// <summary>
    /// Summary description for UserInputValidatorTests
    /// </summary>
    [TestClass]
    public class UserInputValidatorTests
    {
        private readonly UserInputValidator _underTest;

        public UserInputValidatorTests()
        {
            _underTest = new UserInputValidator();
        }

        [DataTestMethod]
        [DataRow("fhfresdfdsf ", true)]
        [DataRow("fhfre sdfdsf ", true)]
        [DataRow(" fhfresd ", true)]
        [DataRow("-fhfresd ", true)]
        [DataRow("-fhfresd-", true)]
        [DataRow("-ANANA-", true)]
        [DataRow("fhf12", false)]
        [DataRow("2386475234", false)]
        [DataRow("121sdfdsf34", false)]
        [DataRow("gdgd!", false)]
        [DataRow("gfgf\"", false)]
        [DataRow("gdgd£", false)]
        [DataRow("gfgf$", false)]
        [DataRow("gfgf%", false)]
        [DataRow("gfgf^", false)]
        [DataRow("hghg&", false)]
        [DataRow("kgkg(", false)]
        [DataRow("ssdf)", false)]
        [DataRow("jdjd_", false)]
        public void IsValid_EnsureCorrect(string input, bool expectedResult)
        {
            // Arrange

            // Act
            var resultVal = _underTest.IsValid(input);

            // Assert
            resultVal.Should().Be(expectedResult);
        }
    }
}

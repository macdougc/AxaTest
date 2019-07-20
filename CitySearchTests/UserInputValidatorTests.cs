using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CitySearchTests
{
    /// <summary>
    /// Summary description for UserInputValidatorTests
    /// </summary>
    [TestClass]
    public class UserInputValidatorTests
    {
        public UserInputValidatorTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [DataTestMethod]
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
        [DataRow("fhf12", false)]
        public void IsValid_EnsureCorrect(string input, bool expectedResult)
        {
            //
            // TODO: Add test logic here
            //
        }
    }
}

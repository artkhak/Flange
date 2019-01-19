using System;
using Flange.Validators.Parameters;
using NUnit.Framework;

namespace Flange.Tests.Validators.Parameters
{
    [TestFixture]
    public class BaseDiameterValidatorTests
    {
        [Test]
        [TestCase(0, 0, 0, ExpectedResult = false)]
        [TestCase(3, 1, 1, ExpectedResult = true)]
        [TestCase(2, 1, 1, ExpectedResult = false)]
        [TestCase(1, 1, 1, ExpectedResult = false)]
        public bool Validate(double baseDiameterValue, double diameterForCentersValue, double boreDiameterValue)
        {
            var baseDiameter = new Parameter("") {Value = baseDiameterValue};
            var diameterForCenters = new Parameter("") {Value = diameterForCentersValue};
            var boreDiameter = new Parameter("") {Value = boreDiameterValue};

            var validator = new BaseDiameterValidator(baseDiameter, diameterForCenters, boreDiameter);

            return string.IsNullOrWhiteSpace(validator.Validate(null));
        }

        [Test]
        public void BaseDiameterValidator_NullParameter()
        {
            var existedParameter = new Parameter("");

            Assert.Throws<ArgumentNullException>(() =>
                new BaseDiameterValidator(null, existedParameter, existedParameter));

            Assert.Throws<ArgumentNullException>(() =>
                new BaseDiameterValidator(existedParameter, null, existedParameter));

            Assert.Throws<ArgumentNullException>(() =>
                new BaseDiameterValidator(existedParameter, existedParameter, null));
        }
    }
}
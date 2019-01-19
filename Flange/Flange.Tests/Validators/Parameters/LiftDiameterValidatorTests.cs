using System;
using Flange.Validators.Parameters;
using NUnit.Framework;

namespace Flange.Tests.Validators.Parameters
{
    [TestFixture]
    public class LiftDiameterValidatorTests
    {
        [Test]
        [TestCase(0, 0, 0, 0, ExpectedResult = true)]
        [TestCase(0, 0, 1, 0, ExpectedResult = true)]
        [TestCase(0, 1, 1, 0, ExpectedResult = false)]
        [TestCase(2, 1, 1, 0, ExpectedResult = true)]
        [TestCase(2, 1, 1, 2, ExpectedResult = false)]
        [TestCase(2, 1, 3, 0, ExpectedResult = false)]
        [TestCase(2, 1, 3, 2, ExpectedResult = false)]
        public bool Validate(double liftDiameterValue, double liftHeightValue, double centralHoleDiameterValue, double nominalDiameterValue)
        {
            var liftDiameter = new Parameter("") {Value = liftDiameterValue};
            var liftHeight = new Parameter("") {Value = liftHeightValue};
            var centralHoleDiameter = new Parameter("") {Value = centralHoleDiameterValue};
            var nominalDiameter = new Parameter("") {Value = nominalDiameterValue};

            var validator = new LiftDiameterValidator(liftDiameter, liftHeight, centralHoleDiameter, nominalDiameter);

            return string.IsNullOrWhiteSpace(validator.Validate(null));
        }

        [Test]
        public void LiftDiameterValidator_NullParameter()
        {
            var existedParameter = new Parameter("");

            Assert.Throws<ArgumentNullException>(() =>
                new LiftDiameterValidator(null, existedParameter, existedParameter, existedParameter));

            Assert.Throws<ArgumentNullException>(() =>
                new LiftDiameterValidator(existedParameter, null, existedParameter, existedParameter));

            Assert.Throws<ArgumentNullException>(() =>
                new LiftDiameterValidator(existedParameter, existedParameter, null, existedParameter));

            Assert.Throws<ArgumentNullException>(() =>
                new LiftDiameterValidator(existedParameter, existedParameter, existedParameter, null));
        }
    }
}
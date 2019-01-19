using System;
using Flange.Validators.Parameters;
using NUnit.Framework;

namespace Flange.Tests.Validators.Parameters
{
    [TestFixture]
    public class LiftHeightValidatorTests
    {
        [Test]
        [TestCase(0, 0, 0, ExpectedResult = true)]
        [TestCase(0, 0, 1, ExpectedResult = true)]
        [TestCase(0, 1, 1, ExpectedResult = false)]
        [TestCase(0.5, 2, 1, ExpectedResult = true)]
        [TestCase(1, 0, 0, ExpectedResult = false)]
        public bool Validate(double liftHeightValue, double liftDiameterValue, double centralHoleDiameterValue)
        {
            var liftHeight = new Parameter("") {Value = liftHeightValue};
            var liftDiameter = new Parameter("") {Value = liftDiameterValue};
            var centralHoleDiameter = new Parameter("") {Value = centralHoleDiameterValue};

            var validator = new LiftHeightValidator(liftHeight, liftDiameter, centralHoleDiameter);

            return string.IsNullOrWhiteSpace(validator.Validate(null));
        }

        [Test]
        public void LiftHeightValidator_NullParameter()
        {
            var existedParameter = new Parameter("");

            Assert.Throws<ArgumentNullException>(() =>
                new LiftHeightValidator(null, existedParameter, existedParameter));

            Assert.Throws<ArgumentNullException>(() =>
                new LiftHeightValidator(existedParameter, null, existedParameter));

            Assert.Throws<ArgumentNullException>(() =>
                new LiftHeightValidator(existedParameter, existedParameter, null));
        }
    }
}
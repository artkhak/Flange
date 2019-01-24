namespace Flange.Tests.Validators.Parameters
{
    using System;

    using Flange.Validators.Parameters;

    using NUnit.Framework;

    [TestFixture]
    public class NominalDiameterValidatorTests
    {
        [Test]
        public void NominalDiameterValidatorValidator_NullParameter()
        {
            var existedParameter = new Parameter("");

            Assert.Throws<ArgumentNullException>(() =>
                new NominalDiameterValidator(null, existedParameter));

            Assert.Throws<ArgumentNullException>(() =>
                new NominalDiameterValidator(existedParameter, null));
        }

        [Test]
        [TestCase(0, 0, ExpectedResult = true)]
        [TestCase(0, 1, ExpectedResult = true)]
        [TestCase(1, 1, ExpectedResult = false)]
        [TestCase(2, 1, ExpectedResult = true)]
        public bool Validate(double nomianlDiameterValue, double centralHoleDiameterValue)
        {
            var nomianlDiameter = new Parameter("") {Value = nomianlDiameterValue};
            var centralHoleDiameter = new Parameter("") {Value = centralHoleDiameterValue};

            var validator = new NominalDiameterValidator(nomianlDiameter, centralHoleDiameter);

            return string.IsNullOrWhiteSpace(validator.Validate(null));
        }
    }
}
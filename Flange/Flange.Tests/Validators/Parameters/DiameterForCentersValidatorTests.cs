namespace Flange.Tests.Validators.Parameters
{
    using System;

    using Flange.Validators.Parameters;

    using NUnit.Framework;

    [TestFixture]
    public class DiameterForCentersValidatorTests
    {
        [Test]
        public void DiameterForCentersValidator_NullParameter()
        {
            var existedParameter = new Parameter("");

            Assert.Throws<ArgumentNullException>(() =>
                new DiameterForCentersValidator(null, existedParameter, existedParameter, existedParameter));

            Assert.Throws<ArgumentNullException>(() =>
                new DiameterForCentersValidator(existedParameter, null, existedParameter, existedParameter));

            Assert.Throws<ArgumentNullException>(() =>
                new DiameterForCentersValidator(existedParameter, existedParameter, null, existedParameter));

            Assert.Throws<ArgumentNullException>(() =>
                new DiameterForCentersValidator(existedParameter, existedParameter, existedParameter, null));
        }

        [Test]
        [TestCase(0, 0, 0, 0, ExpectedResult = false)]
        [TestCase(3, 1, 1, 1, ExpectedResult = true)]
        [TestCase(3, 2, 1, 1, ExpectedResult = false)]
        [TestCase(3, 0, 2, 1, ExpectedResult = false)]
        public bool Validate(double diameterForCentersValue, double liftDiameterValue, double centralHoleDiameterValue,
            double boreDiameterValue)
        {
            var diameterForCenters = new Parameter("") {Value = diameterForCentersValue};
            var liftDiameter = new Parameter("") {Value = liftDiameterValue};
            var centralHoleDiameter = new Parameter("") {Value = centralHoleDiameterValue};
            var boreDiameter = new Parameter("") {Value = boreDiameterValue};

            var validator =
                new DiameterForCentersValidator(diameterForCenters, liftDiameter, centralHoleDiameter, boreDiameter);

            return string.IsNullOrWhiteSpace(validator.Validate(null));
        }
    }
}
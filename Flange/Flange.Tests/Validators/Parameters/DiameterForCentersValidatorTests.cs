using Flange.Validators.Parameters;
using NUnit.Framework;

namespace Flange.Tests.Validators.Parameters
{
    [TestFixture]
    public class DiameterForCentersValidatorTests
    {
        [Test]
        public void Validate()
        {
            var diameterForCenters = new Parameter("");
            var liftDiameter = new Parameter("");
            var centralHoleDiameter = new Parameter("");
            var boreDiameter = new Parameter("");

            var validator = new DiameterForCentersValidator(diameterForCenters, liftDiameter, centralHoleDiameter, boreDiameter);

            Assert.IsFalse(string.IsNullOrWhiteSpace(validator.Validate(null)));

            diameterForCenters.Value = 3;
            liftDiameter.Value = 1;
            centralHoleDiameter.Value = 1;
            boreDiameter.Value = 1;

            Assert.IsTrue(string.IsNullOrWhiteSpace(validator.Validate(null)));

            liftDiameter.Value = 2;

            Assert.IsFalse(string.IsNullOrWhiteSpace(validator.Validate(null)));

            liftDiameter.Value = 0;
            centralHoleDiameter.Value = 2;

            Assert.IsFalse(string.IsNullOrWhiteSpace(validator.Validate(null)));

        }
    }
}
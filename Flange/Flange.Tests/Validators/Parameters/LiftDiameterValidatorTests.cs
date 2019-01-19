using Flange.Validators.Parameters;
using NUnit.Framework;

namespace Flange.Tests.Validators.Parameters
{
    [TestFixture]
    public class LiftDiameterValidatorTests
    {
        [Test]
        public void Validate()
        {
            var liftDiameter = new Parameter("");
            var liftHeight = new Parameter("");
            var centralHoleDiameter = new Parameter("");

            var validator = new LiftDiameterValidator(liftDiameter, liftHeight, centralHoleDiameter);

            Assert.IsTrue(string.IsNullOrWhiteSpace(validator.Validate(null)));

            liftDiameter.Value = 0;
            liftHeight.Value = 0;
            centralHoleDiameter.Value = 1;

            Assert.IsTrue(string.IsNullOrWhiteSpace(validator.Validate(null)));

            liftHeight.Value = 1;

            Assert.IsFalse(string.IsNullOrWhiteSpace(validator.Validate(null)));

            liftDiameter.Value = 2;

            Assert.IsTrue(string.IsNullOrWhiteSpace(validator.Validate(null)));

            centralHoleDiameter.Value = 3;

            Assert.IsFalse(string.IsNullOrWhiteSpace(validator.Validate(null)));

        }
    }
}
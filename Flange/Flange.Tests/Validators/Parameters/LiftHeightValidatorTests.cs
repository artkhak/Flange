using Flange.Validators.Parameters;
using NUnit.Framework;

namespace Flange.Tests.Validators.Parameters
{
    [TestFixture]
    public class LiftHeightValidatorTests
    {
        [Test]
        public void Validate()
        {
            var liftHeight = new Parameter("");
            var liftDiameter = new Parameter("");
            var centralHoleDiameter = new Parameter("");

            var validator = new LiftHeightValidator(liftHeight, liftDiameter, centralHoleDiameter);

            Assert.IsTrue(string.IsNullOrWhiteSpace(validator.Validate(null)));

            liftDiameter.Value = 0;
            liftHeight.Value = 0;
            centralHoleDiameter.Value = 1;

            Assert.IsTrue(string.IsNullOrWhiteSpace(validator.Validate(null)));

            liftDiameter.Value = 1;

            Assert.IsFalse(string.IsNullOrWhiteSpace(validator.Validate(null)));

            liftDiameter.Value = 2;
            liftHeight.Value = 0.5;

            Assert.IsTrue(string.IsNullOrWhiteSpace(validator.Validate(null)));

            liftHeight.Value = 1;

            Assert.IsFalse(string.IsNullOrWhiteSpace(validator.Validate(null)));

        }
    }
}
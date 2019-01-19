using Flange.Validators.Parameters;
using NUnit.Framework;

namespace Flange.Tests.Validators.Parameters
{
    [TestFixture]
    public class BaseDiameterValidatorTests
    {
        [Test]
        public void Validate()
        {
            var baseDiameter = new Parameter("");
            var diameterForCenters = new Parameter("");
            var boreDiameter = new Parameter("");

            var validator = new BaseDiameterValidator(baseDiameter, diameterForCenters, boreDiameter);

            Assert.IsFalse(string.IsNullOrWhiteSpace(validator.Validate(null)));

            baseDiameter.Value = 3;
            diameterForCenters.Value = 1;
            boreDiameter.Value = 1;

            Assert.IsTrue(string.IsNullOrWhiteSpace(validator.Validate(null)));

            baseDiameter.Value = 2;

            Assert.IsFalse(string.IsNullOrWhiteSpace(validator.Validate(null)));

            baseDiameter.Value = 1;

            Assert.IsFalse(string.IsNullOrWhiteSpace(validator.Validate(null)));

        }
    }
}
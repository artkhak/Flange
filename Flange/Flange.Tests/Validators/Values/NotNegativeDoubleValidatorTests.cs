using Flange.Validators.Values;
using NUnit.Framework;

namespace Flange.Tests.Validators.Values
{
    [TestFixture]
    public class NotNegativeDoubleValidatorTests
    {
        [Test]
        public void Validate()
        {
            var validator = new NotNegativeDoubleValidator();

            Assert.IsTrue(string.IsNullOrWhiteSpace(validator.Validate(3)));
            Assert.IsTrue(string.IsNullOrWhiteSpace(validator.Validate(1)));
            Assert.IsTrue(string.IsNullOrWhiteSpace(validator.Validate(0)));
            Assert.IsFalse(string.IsNullOrWhiteSpace(validator.Validate(-1)));
            Assert.IsFalse(string.IsNullOrWhiteSpace(validator.Validate(-3)));
        }
    }
}
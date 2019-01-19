using Flange.Validators.Values;
using NUnit.Framework;

namespace Flange.Tests.Validators.Values
{
    [TestFixture]
    public class PositiveDoubleVolidatorTests
    {
        [Test]
        [TestCase(3, ExpectedResult = true)]
        [TestCase(1, ExpectedResult = true)]
        [TestCase(0, ExpectedResult = false)]
        [TestCase(-1, ExpectedResult = false)]
        [TestCase(-3, ExpectedResult = false)]
        public bool Validate(double value)
        {
            var validator = new PositiveDoubleValidator();

            return string.IsNullOrWhiteSpace(validator.Validate(value)); ;
        }
    }
}
using System;
using System.Collections.Generic;
using Flange.Validators.Values;
using NUnit.Framework;

namespace Flange.Tests
{
    [TestFixture]
    public class ParameterTests
    {
        [Test]
        public void Parameter()
        {
            const string name = "name";

            var parameter = new Parameter(name);

            Assert.AreEqual(name, parameter.Name);
        }

        [Test]
        public void Parameter_Error()
        {
            var parameter = new Parameter("", new NotNegativeDoubleValidator());

            parameter.Value = 0;

            Assert.IsTrue(string.IsNullOrWhiteSpace(parameter.Error));

            parameter.Value = -1;

            Assert.IsFalse(string.IsNullOrWhiteSpace(parameter.Error));
        }

        [Test]
        public void Patameter_WithoutPossibleValues()
        {
            var parameter = new Parameter("");

            Assert.IsNull(parameter.PossibleValues);

            Assert.DoesNotThrow(() => parameter.Value = 12085);

            Assert.AreEqual(12085, parameter.Value);
        }

        [Test]
        public void Patameter_WithPossibleValues()
        {
            var correctTestValue = 1;
            var possibleValues = new List<double> {1, correctTestValue, 3};

            var parameter = new Parameter("", null, possibleValues);

            CollectionAssert.AreEqual(possibleValues, parameter.PossibleValues);

            Assert.DoesNotThrow(() => parameter.Value = correctTestValue);

            Assert.Throws<ArgumentException>(() => parameter.Value = 100);
        }
    }
}
using NUnit.Framework;

namespace Flange.Tests
{
    [TestFixture]
    public class FlangeParametersTests
    {
        [Test]
        public void FlangeParameters()
        {
            var flangeParameters = new FlangeParameters();

            CollectionAssert.IsNotEmpty(flangeParameters.Parameters);
        }
    }
}
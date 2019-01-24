namespace Flange.Tests
{
    using NUnit.Framework;

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
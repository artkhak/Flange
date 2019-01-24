namespace Flange.Tests.Kompas
{
    using System;

    using Flange.Kompas;

    using NUnit.Framework;

    [TestFixture]
    public class FlangeBuilderTests
    {
        [Test]
        public void FlangeBuilder()
        {
            var kompas = KompasApp.Start();

            Assert.DoesNotThrow(() => new FlangeBuilder(kompas));

            kompas.Quit();
        }

        [Test]
        public void FlangeBuilder_KompasIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new FlangeBuilder(null));
        }
    }
}
namespace Flange.Tests.Kompas
{
    using System;

    using Flange.Kompas;

    using NUnit.Framework;

    [TestFixture]
    public class KompasAppTests
    {
        [Test]
        public void CreateDocument3D()
        {
            var kompas = KompasApp.Start();
            var document3D = kompas.CreateDocument3D();

            Assert.NotNull(document3D);

            kompas.Quit();
        }

        [Test]
        public void GetActive()
        {
            KompasApp.Start();

            var kompas = KompasApp.GetActive();

            Assert.NotNull(kompas);

            kompas.Quit();
        }

        [Test]
        [Ignore("Ломается из-за паралельного запуска тестов.")]
        public void GetActive_NotStarted()
        {
            var kompas = KompasApp.GetActive();

            Assert.IsNull(kompas);
        }

        [Test]
        //[Ignore("Если не установлена совместимая версия КОМПАС-3D")]
        public void Quit()
        {
            var kompas = KompasApp.Start();

            Assert.DoesNotThrow(() => kompas.Quit());
        }

        [Test]
        //[Ignore("Если не установлена совместимая версия КОМПАС-3D")]
        public void Start()
        {
            var kompas = KompasApp.Start();

            Assert.NotNull(kompas);

            kompas.Quit();
        }

        [Test]
        [Ignore("Если установлена совместимая версия КОМПАС-3D")]
        public void Start_NotInstalled()
        {
            Assert.Throws<Exception>(() => KompasApp.Start());
        }
    }
}
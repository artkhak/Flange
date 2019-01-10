using System;
using Kompas6API5;

namespace Flange.Model.Kompas
{
    public class Kompas
    {
        /// <summary>
        /// Экземпляр программы КОМПАС-3D.
        /// </summary>
        private readonly KompasObject _kompasInstance;

        public Kompas(KompasObject kompasInstance)
        {
            _kompasInstance = kompasInstance;
        }

        /// <summary>
        /// Создает 3D документ.
        /// </summary>
        /// <returns>3D документ.</returns>
        public Document3D CreateDocument3D()
        {
            var document3D = _kompasInstance.Document3D();

            if (!document3D.Create(false, false)) throw new Exception("Не удалось создать 3D документ");

            return document3D;
        }
    }
}
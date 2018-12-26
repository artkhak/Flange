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

        public ksDocument2D CreateDocument2D()
        {
            return _kompasInstance.Document2D();
        }
    }
}
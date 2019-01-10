using System;
using System.Runtime.InteropServices;
using Kompas6API5;

namespace Flange.Model.Kompas
{
    /// <summary>
    /// Менеджер приложения КОМПАС-3D.
    /// </summary>
    public static class KompasAppManager
    {
        /// <summary>
        /// ProgId для совместимой версии КОМПАС-3D.
        /// </summary>
        private const string ProgId = "KOMPAS.Application.5";

        /// <summary>
        /// Получает объект <see cref="Kompas" /> с запущенным КОМПАС-3D.
        /// </summary>
        /// <returns>Объект <see cref="Kompas" /> с экзкмпляром запущеного КОМПАС-3D.</returns>
        public static Kompas GetActive()
        {
            try
            {
                var kompasInstance = (KompasObject) Marshal.GetActiveObject(ProgId);
                return PrepareAndPackKompas(kompasInstance);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Запустить КОМПАС-3D.
        /// </summary>
        /// <returns>Объект <see cref="Kompas" /> с экзкмпляром запущеного КОМПАС-3D.</returns>
        public static Kompas Start()
        {
            var appType = Type.GetTypeFromProgID(ProgId);

            if (appType == null)
                throw new Exception("Не обнаружена совместимая версия программы КОМПАС-3D");

            var kompasInstance = (KompasObject) Activator.CreateInstance(appType);
            return PrepareAndPackKompas(kompasInstance);
        }

        /// <summary>
        /// Подготавливает экземпляр <see cref="KompasObject" /> и упаковывает его в <see cref="Kompas" />.
        /// </summary>
        /// <param name="kompasInstance">Экземпляр <see cref="KompasObject" />.</param>
        /// <returns>Объект <see cref="Kompas" />.</returns>
        private static Kompas PrepareAndPackKompas(KompasObject kompasInstance)
        {
            kompasInstance.Visible = true;
            kompasInstance.ActivateControllerAPI();

            return new Kompas(kompasInstance);
        }
    }
}
namespace Flange.Kompas
{
    using System;
    using System.Runtime.InteropServices;

    using Kompas6API5;

    /// <summary>
    /// Оболочка для КОМПАС-3D.
    /// </summary>
    public class KompasApp
    {
        /// <summary>
        /// ProgId для совместимой версии КОМПАС-3D.
        /// </summary>
        private const string ProgId = "KOMPAS.Application.5";

        /// <summary>
        /// Экземпляр программы КОМПАС-3D.
        /// </summary>
        private readonly KompasObject _kompasInstance;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="kompasInstance">Экземпляр программы КОМПАС-3D.</param>
        private KompasApp(KompasObject kompasInstance)
        {
            _kompasInstance = kompasInstance ?? throw new ArgumentNullException(nameof(kompasInstance));
        }

        /// <summary>
        /// Создает 3D документ.
        /// </summary>
        /// <returns>3D документ.</returns>
        public Document3D CreateDocument3D()
        {
            Document3D document3D = _kompasInstance.Document3D();

            if (!document3D.Create(false, false))
                throw new Exception("Не удалось создать 3D документ");

            return document3D;
        }

        /// <summary>
        /// Закрывает КОМПАС-3D.
        /// </summary>
        public void Quit()
        {
            _kompasInstance.Quit();
        }

        /// <summary>
        /// Получает объект <see cref="KompasApp" /> с запущенным КОМПАС-3D.
        /// </summary>
        /// <returns>Объект <see cref="KompasApp" /> с экзкмпляром запущеного КОМПАС-3D.</returns>
        public static KompasApp GetActive()
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
        /// <returns>Объект <see cref="KompasApp" /> с экзкмпляром запущеного КОМПАС-3D.</returns>
        public static KompasApp Start()
        {
            var appType = Type.GetTypeFromProgID(ProgId);

            if (appType == null)
                throw new Exception("Не обнаружена совместимая версия программы КОМПАС-3D");

            var kompasInstance = (KompasObject) Activator.CreateInstance(appType);
            return PrepareAndPackKompas(kompasInstance);
        }

        /// <summary>
        /// Подготавливает экземпляр <see cref="KompasObject" /> и упаковывает его в <see cref="KompasApp" />.
        /// </summary>
        /// <param name="kompasInstance">Экземпляр <see cref="KompasObject" />.</param>
        /// <returns>Объект <see cref="KompasApp" />.</returns>
        private static KompasApp PrepareAndPackKompas(KompasObject kompasInstance)
        {
            kompasInstance.Visible = true;
            kompasInstance.ActivateControllerAPI();

            return new KompasApp(kompasInstance);
        }
    }
}
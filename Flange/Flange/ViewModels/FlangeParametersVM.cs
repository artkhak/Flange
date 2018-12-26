using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Flange.Model.Flange;

namespace Flange.ViewModels
{
    /// <summary>
    /// Вью-модель для параметров фланца.
    /// </summary>
    public class FlangeParametersVM : DataVM
    {
        /// <summary>
        /// Параметры фланца.
        /// </summary>
        public FlangeParameters FlangeParameters { get; }

        /// <summary>
        /// Вью-модели параметров.
        /// </summary>
        public List<ParameterVM> ParameterVMs { get; }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="flangeParameters">Параметры фланца.</param>
        public FlangeParametersVM(FlangeParameters flangeParameters)
        {
            FlangeParameters = flangeParameters;
            ParameterVMs = FlangeParameters.Parameters.Select(p => new ParameterVM(p)).ToList();
        }

        /// <summary>
        /// Указывает, что в данных есть ошибка.
        /// </summary>
        public override bool HasErrors => FlangeParameters.Errors.Any();

        /// <summary>
        /// Получает список ошибок.
        /// </summary>
        /// <param name="propertyName">Название свойства.</param>
        /// <returns>Список ошибок.</returns>
        public override IEnumerable GetErrors(string propertyName)
        {
            return FlangeParameters.Errors;
        }
    }
}
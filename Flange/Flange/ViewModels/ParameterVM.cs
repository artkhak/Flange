using System.Collections;
using System.Linq;
using Flange.Model;

namespace Flange.ViewModels
{
    /// <summary>
    /// Вью-модель параметра.
    /// </summary>
    public class ParameterVM : DataVM
    {
        /// <summary>
        /// Параметер.
        /// </summary>
        private readonly Parameter _parameter;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="parameter">Парамтеер.</param>
        public ParameterVM(Parameter parameter)
        {
            _parameter = parameter;
        }

        /// <summary>
        /// Название.
        /// </summary>
        public string Name => _parameter.Name;

        /// <summary>
        /// Значение.
        /// </summary>
        public double Value
        {
            get => _parameter.Value;
            set
            {
                _parameter.Value = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Получает список ошибок.
        /// </summary>
        /// <param name="propertyName">Название свойства.</param>
        /// <returns>Список ошибок.</returns>
        public override IEnumerable GetErrors(string propertyName)
        {
            return _parameter.Errors;
        }

        /// <summary>
        /// Указывает, что в данных есть ошибка.
        /// </summary>
        public override bool HasErrors => _parameter.Errors.Any();
    }
}
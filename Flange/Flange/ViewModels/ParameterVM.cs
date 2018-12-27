using System.Collections;
using System.Globalization;
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
        /// Отображаемое значение.
        /// </summary>
        private string _displayedValue;

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
        /// Отображаемое значение.
        /// </summary>
        public string DisplayedValue
        {
            get => _displayedValue;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _parameter.Value = 0;
                    _displayedValue = value;
                }
                else if (double.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out var doubleValue))
                {
                    _parameter.Value = doubleValue;
                    _displayedValue = value.Last().ToString()
                        .Equals(CultureInfo.InvariantCulture.NumberFormat.CurrencyDecimalSeparator)
                        ? value
                        : _parameter.Value.ToString(CultureInfo.InvariantCulture);
                }

                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Указывает, что в данных есть ошибка.
        /// </summary>
        public override bool HasErrors => _parameter.Errors.Any();

        /// <summary>
        /// Получает список ошибок.
        /// </summary>
        /// <param name="propertyName">Название свойства.</param>
        /// <returns>Список ошибок.</returns>
        public override IEnumerable GetErrors(string propertyName)
        {
            if (propertyName == nameof(DisplayedValue))
                return _parameter.Errors;

            return string.Empty;
        }
    }
}
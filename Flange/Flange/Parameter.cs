using System.Collections.Generic;
using System.Linq;
using Flange.Validators;

namespace Flange
{
    /// <summary>
    /// Параметер.
    /// </summary>
    public class Parameter
    {
        /// <summary>
        /// Список валидаторов.
        /// </summary>
        private readonly List<IValidator<double>> _validators;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="name">Название.</param>
        /// <param name="validators">Список валидаторов.</param>
        /// <param name="possibleValues">Возможные значения.</param>
        public Parameter(string name, List<IValidator<double>> validators, List<double> possibleValues = null)
        {
            Name = name;
            _validators = validators;
            PossibleValues = possibleValues;
        }

        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Значение.
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Возможные значения.
        /// </summary>
        public List<double> PossibleValues { get; }

        /// <summary>
        /// Список ошибок.
        /// </summary>
        public List<string> Errors => _validators?.Select(validator => validator?.Validate(Value))
            .Where(error => !string.IsNullOrWhiteSpace(error))
            .ToList();
    }
}
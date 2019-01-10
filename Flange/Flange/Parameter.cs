using System.Collections.Generic;
using System.Linq;
using Flange.Model.Validators;

namespace Flange.Model
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
        public Parameter(string name, List<IValidator<double>> validators)
        {
            Name = name;
            _validators = validators;
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
        /// Список ошибок.
        /// </summary>
        public List<string> Errors => _validators?.SelectMany(v => v?.Validate(Value)).ToList();
    }
}
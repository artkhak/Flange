namespace Flange
{
    using System;
    using System.Collections.Generic;

    using Flange.Validators;

    /// <summary>
    /// Параметер.
    /// </summary>
    public class Parameter
    {
        /// <summary>
        /// Список валидаторов.
        /// </summary>
        private readonly IValidator<double> _validator;

        private double _value;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="name">Название.</param>
        /// <param name="validator">Валидатор.</param>
        /// <param name="possibleValues">Возможные значения.</param>
        public Parameter(string name, IValidator<double> validator = null, List<double> possibleValues = null)
        {
            Name = name;
            _validator = validator;
            PossibleValues = possibleValues;
        }

        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Значение.
        /// </summary>
        public double Value
        {
            get => _value;
            set
            {
                if (PossibleValues != null && !PossibleValues.Contains(value))
                    throw new ArgumentException("Значение не входит в список возможных.");

                _value = value;
            }
        }

        /// <summary>
        /// Возможные значения.
        /// </summary>
        public List<double> PossibleValues { get; }

        /// <summary>
        /// Список ошибок.
        /// </summary>
        public string Error => _validator?.Validate(Value);
    }
}
using System.Collections.Generic;

namespace Flange.Model.Validators
{
    /// <summary>
    /// Валидатор параметров фланца.
    /// </summary>
    public class FlangeParametersValidator : IValidator<List<Parameter>>
    {
        /// <summary>
        /// Проверяет значение.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <returns>Список ошибок.</returns>
        public IEnumerable<string> Validate(List<Parameter> value)
        {
           // throw new System.NotImplementedException();
            return new List<string>();
        }
    }
}
namespace Flange.UI.ViewModels
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using Flange.UI.Properties;

    /// <summary>
    /// Базовая вью-модель.
    /// </summary>
    public abstract class DataVM : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        /// <summary>
        /// Получает список ошибок.
        /// </summary>
        /// <param name="propertyName">Название свойства.</param>
        /// <returns>Список ошибок.</returns>
        public abstract IEnumerable GetErrors(string propertyName);

        /// <summary>
        /// Указывает, что в данных есть ошибка.
        /// </summary>
        public abstract bool HasErrors { get; }

        /// <summary>
        /// Событие об изменении ошибок.
        /// </summary>
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        /// <summary>
        /// Происходит при изменении свойств.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Вызывает событие <see cref="PropertyChanged" />.
        /// </summary>
        /// <param name="propertyName">Название свойства.</param>
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}
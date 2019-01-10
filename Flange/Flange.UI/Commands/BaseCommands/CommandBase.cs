using System;
using System.Windows.Input;

namespace Flange.UI.Commands.BaseCommands
{
    /// <summary>
    /// База команды.
    /// </summary>
    public abstract class CommandBase : ICommand
    {
        /// <summary>
        /// Название команды.
        /// </summary>
        protected readonly string CommandName;

        /// <summary>
        /// Конструктор, устанавливающий название команды.
        /// </summary>
        /// <param name="commandName">Название команды.</param>
        protected CommandBase(string commandName)
        {
            CommandName = commandName;
        }

        /// <summary>
        /// Получает значение, указывающее на возможность вызова команды.
        /// </summary>
        /// <param name="parameter">Параметр.</param>
        /// <returns>Значение, указывающее на возможность вызова команды.</returns>
        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Вызывает выполнение команды.
        /// </summary>
        /// <param name="parameter">Параметр.</param>
        public abstract void Execute(object parameter);

        /// <summary>
        /// Событие, которое происходит циклически для обновления результатат <see cref="CanExecute" />.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
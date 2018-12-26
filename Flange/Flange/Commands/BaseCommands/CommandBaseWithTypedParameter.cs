using System;

namespace Flange.Commands.BaseCommands
{
    /// <summary>
    /// База команды с типизированным параметром.
    /// </summary>
    /// <typeparam name="T">Тип параметра.</typeparam>
    public abstract class CommandBaseWithTypedParameter<T> : CommandBase
    {
        /// <summary>
        /// Конструктор, устанавливающий название команды.
        /// </summary>
        /// <param name="commandName">Название команды.</param>
        protected CommandBaseWithTypedParameter(string commandName) : base(commandName)
        {
        }

        /// <summary>
        /// Получает значение, указывающее на возможность вызова команды.
        /// </summary>
        /// <param name="parameter">Параметр.</param>
        /// <returns>Значение, указывающее на возможность вызова команды.</returns>
        public sealed override bool CanExecute(object parameter)
        {
            if (!(parameter is T typedParameter))
                throw new NotSupportedException($"Параметр должен иметь тип {nameof(T)}");

            return CanExecute(typedParameter);
        }

        /// <summary>
        /// Получает значение, указывающее на возможность вызова команды.
        /// </summary>
        /// <param name="typedParameter">Типизированный параметр.</param>
        /// <returns>Значение, указывающее на возможность вызова команды.</returns>
        protected virtual bool CanExecute(T typedParameter)
        {
            return true;
        }

        /// <summary>
        /// Вызывает выполнение команды.
        /// </summary>
        /// <param name="parameter">Параметр.</param>
        public sealed override void Execute(object parameter)
        {
            if (!(parameter is T typedParameter))
                throw new NotSupportedException($"Параметр должен иметь тип {nameof(T)}");

            try
            {
                Execute(typedParameter);
            }
            catch (Exception ex)
            {
                MessageViewer.Error(CommandName, ex.Message);
            }
        }

        /// <summary>
        /// Вызывает выполнение команды с типизированным параметром.
        /// </summary>
        /// <param name="typedParameter">Типизированный параметр.</param>
        protected abstract void Execute(T typedParameter);
    }
}
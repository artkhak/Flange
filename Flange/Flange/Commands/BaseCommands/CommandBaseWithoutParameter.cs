using System;

namespace Flange.Commands.BaseCommands
{
    /// <summary>
    /// База команды без параметра.
    /// </summary>
    public abstract class CommandBaseWithoutParameter : CommandBase
    {
        /// <summary>
        /// Конструктор, устанавливающий название команды.
        /// </summary>
        /// <param name="commandName">Название команды.</param>
        protected CommandBaseWithoutParameter(string commandName) : base(commandName)
        {
        }

        /// <summary>
        /// Получает значение, указывающее на возможность вызова команды.
        /// </summary>
        /// <param name="parameter">Параметр.</param>
        /// <returns>Значение, указывающее на возможность вызова команды.</returns>
        public sealed override bool CanExecute(object parameter)
        {
            return CanExecute();
        }

        /// <summary>
        /// Получает значение, указывающее на возможность вызова команды.
        /// </summary>
        /// <returns>Значение, указывающее на возможность вызова команды.</returns>
        protected virtual bool CanExecute()
        {
            return true;
        }

        /// <summary>
        /// Вызывает выполнение команды.
        /// </summary>
        /// <param name="parameter">Параметр.</param>
        public sealed override void Execute(object parameter)
        {
            try
            {
                Execute();
            }
            catch (Exception ex)
            {
                MessageViewer.Error(CommandName, ex.Message);
            }
        }

        /// <summary>
        /// Вызывает выполнение команды с типизированным параметром.
        /// </summary>
        protected abstract void Execute();
    }
}
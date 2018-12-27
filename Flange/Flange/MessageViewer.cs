using System.Windows;

namespace Flange
{
    /// <summary>
    /// Используется для отображения сообщений пользователю с помощью <see cref="MessageBox" />.
    /// </summary>
    public class MessageViewer
    {
        /// <summary>
        /// Отображает сообщение.
        /// </summary>
        /// <param name="title">Название.</param>
        /// <param name="message">Сообщение.</param>
        public static void Message(string title, string message)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK);
        }

        /// <summary>
        /// Отображает ошибку.
        /// </summary>
        /// <param name="title">Название.</param>
        /// <param name="errorMessage">Сообщение об ошибка.</param>
        public static void Error(string title, string errorMessage)
        {
            MessageBox.Show(errorMessage, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
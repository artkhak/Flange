using System.Windows;

namespace Flange.UI
{
    /// <summary>
    /// Используется для отображения сообщений пользователю с помощью <see cref="MessageBox" />.
    /// </summary>
    public static class MessageViewer
    {
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SportRecords
{
    /// <summary>
    /// Логика взаимодействия для AthletProfile.xaml
    /// </summary>
    public partial class AthletProfile : Window
    {

        private ddUser _currentUser;

        public AthletProfile(ddUser user)
        {
            InitializeComponent();
            _currentUser = user;
            LoadUserData();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void LoadUserData()
        {
            FullNameLabel.Content = $"{_currentUser.lastname} {_currentUser.firstname} {_currentUser.patronymic}";
            LoginTextBox.Text = _currentUser.login;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string newPassword = NewPasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("Введите новый пароль.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Пароли не совпадают. Повторите попытку.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            using (var context = new user30_dbEntities())
            {
                var userToUpdate = context.ddUser.Find(_currentUser.id);
                if (userToUpdate != null)
                {
                    userToUpdate.password = newPassword;
                    context.SaveChanges();
                    MessageBox.Show("Пароль успешно изменён.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Очищаем поля с паролями
                    NewPasswordBox.Password = string.Empty;
                    ConfirmPasswordBox.Password = string.Empty;
                }
                else
                {
                    MessageBox.Show("Ошибка при изменении пароля. Попробуйте снова.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var form = new Athlet();
            form.Show();
            this.Hide();
        }
    }
}

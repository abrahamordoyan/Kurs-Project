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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;

namespace SportRecords
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int UserID;

        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordTextBox.Password;

            // Проверка на пустые поля
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Пожалуйста, заполните все поля");
                return; // Прерывание выполнения, если поля пусты
            }

            // Использование вашего контекста базы данных
            using (var context = new user30_dbEntities())
            {
                // Здесь используем правильные названия таблиц и полей
                var user = context.ddUser.Include(u => u.ddRole)
                                  .FirstOrDefault(u => u.login == login && u.password == password);

                if (user != null)
                {
                    UserID = user.id;
                    if (user.ddRole.name == "Администратор")
                    {
                        var form = new AdminWindow();
                        form.Show();
                        this.Hide();
                    }
                    else if (user.ddRole.name == "Пользователь")
                    {
                        var form = new User();
                        form.Show();
                        this.Hide();
                    }
                    else
                    {
                        var form = new Athlet();
                        form.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
        }
    }
}

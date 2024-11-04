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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            LoadUserLabel(FILabel);
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        public static void LoadUserLabel(Label lbl)
        {
            using (var context = new user30_dbEntities()) // Используем ваш контекст базы данных
            {
                var user = context.ddUser.FirstOrDefault(u => u.id == MainWindow.UserID); // Предположим, что "id" — это идентификатор пользователя

                if (user != null)
                {
                    lbl.Content = user.firstname + " " + user.lastname; // Предполагаем, что есть поля firstname и lastname
                }
                else
                {
                    lbl.Content = "Пользователь не найден"; // В случае, если пользователь не найден
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var form = new MainWindow();
            form.Show();
            this.Hide();
        }

        private void UserButton_Click(object sender, RoutedEventArgs e)
        {
            var form = new AddUser();
            form.Show();
            this.Hide();
        }

        private void AchievementButton_Click(object sender, RoutedEventArgs e)
        {
            var form = new AddAchievement();
            form.Show();
            this.Hide();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var form = new AddTournament();
            form.Show();
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var form = new AddTeam();
            form.Show();
            this.Hide();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var form = new AddAchievementType();
            form.Show();
            this.Hide();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var form = new AddSport();
            form.Show();
            this.Hide();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var form = new AddAchievementName();
            form.Show();
            this.Hide();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            var form = new AddRole();
            form.Show();
            this.Hide();
        }
    }
}

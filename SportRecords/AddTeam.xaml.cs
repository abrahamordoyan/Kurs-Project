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
    /// Логика взаимодействия для AddTeam.xaml
    /// </summary>
    public partial class AddTeam : Window
    {
        private user30_dbEntities _context;

        public AddTeam()
        {
            InitializeComponent();
            LoadTeams();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        private void LoadTeams()
        {
            using (var context = new user30_dbEntities())
            {
                // Загружаем данные команд
                var teams = context.ddTeam
                    .Select(t => new
                    {
                        t.id,
                        t.name,
                        t.sport_name
                    })
                    .ToList();

                // Привязываем данные к DataGrid
                TeamDataGrid.ItemsSource = teams;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var form = new AdminWindow();
            form.Show();
            this.Hide();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Открываем AddTeamDialog как диалоговое окно
            var addTeamDialog = new AddTeamDialog();
            if (addTeamDialog.ShowDialog() == true)
            {
                // Обновляем DataGrid после добавления новой команды
                LoadTeams();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (TeamDataGrid.SelectedItem != null)
            {
                // Получаем ID выбранной команды
                var selectedTeam = TeamDataGrid.SelectedItem;

                // Извлекаем ID из анонимного типа
                var teamId = (int)selectedTeam.GetType().GetProperty("id").GetValue(selectedTeam, null);

                using (var context = new user30_dbEntities())
                {
                    // Загружаем команду из базы данных по ID
                    var teamToEdit = context.ddTeam.FirstOrDefault(t => t.id == teamId);

                    if (teamToEdit != null)
                    {
                        // Открываем диалоговое окно редактирования и передаем данные
                        var editDialog = new AddTeamDialog(teamToEdit); // Передаем команду в конструктор
                        if (editDialog.ShowDialog() == true)
                        {
                            // Обновляем DataGrid после редактирования
                            LoadTeams();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите команду для редактирования.");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (TeamDataGrid.SelectedItem != null)
            {
                // Получаем ID выбранной команды
                var selectedTeam = TeamDataGrid.SelectedItem;

                // Извлекаем ID из анонимного типа
                var teamId = (int)selectedTeam.GetType().GetProperty("id").GetValue(selectedTeam, null);

                // Подтверждение удаления
                MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить команду?",
                                                          "Подтверждение удаления",
                                                          MessageBoxButton.YesNo,
                                                          MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    using (var context = new user30_dbEntities())
                    {
                        // Загружаем команду из базы данных по ID
                        var teamToDelete = context.ddTeam.FirstOrDefault(t => t.id == teamId);

                        if (teamToDelete != null)
                        {
                            context.ddTeam.Remove(teamToDelete);
                            context.SaveChanges();

                            // Обновляем DataGrid после удаления
                            LoadTeams();
                            MessageBox.Show("Команда успешно удалена.");
                        }
                        else
                        {
                            MessageBox.Show("Не удалось найти команду в базе данных.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите команду для удаления.");
            }
        }
    }
}

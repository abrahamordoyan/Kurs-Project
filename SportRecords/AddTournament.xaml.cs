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
    /// Логика взаимодействия для AddTournament.xaml
    /// </summary>
    public partial class AddTournament : Window
    {
        private user30_dbEntities _context;
        public AddTournament()
        {
            InitializeComponent();
            LoadTournaments();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void LoadTournaments()
        {
            using (var context = new user30_dbEntities())
            {
                // Загружаем данные турниров
                var tournaments = context.ddTournament
                    .Select(t => new
                    {
                        t.id,
                        t.name,
                        t.start_date,
                        t.end_date,
                        t.location
                    })
                    .ToList();

                // Привязываем данные к DataGrid
                TournamentDataGrid.ItemsSource = tournaments;
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
            // Открываем AddTournamentDialog как диалоговое окно
            var addTournamentDialog = new AddTournamentDialog();
            if (addTournamentDialog.ShowDialog() == true)
            {
                // Обновляем DataGrid после добавления
                LoadTournaments();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (TournamentDataGrid.SelectedItem != null)
            {
                // Получаем ID выбранного турнира
                var selectedTournament = TournamentDataGrid.SelectedItem;

                // Извлекаем ID из анонимного типа
                var tournamentId = (int)selectedTournament.GetType().GetProperty("id").GetValue(selectedTournament, null);

                using (var context = new user30_dbEntities())
                {
                    // Загружаем турнир из базы данных по ID
                    var tournamentToEdit = context.ddTournament.FirstOrDefault(t => t.id == tournamentId);

                    if (tournamentToEdit != null)
                    {
                        // Открываем диалоговое окно редактирования и передаем данные
                        var editDialog = new AddTournamentDialog(tournamentToEdit);
                        if (editDialog.ShowDialog() == true)
                        {
                            // После редактирования обновляем DataGrid
                            LoadTournaments();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите турнир для редактирования.");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (TournamentDataGrid.SelectedItem != null)
            {
                // Получаем ID выбранного турнира
                var selectedTournament = TournamentDataGrid.SelectedItem;

                // Извлекаем ID из анонимного типа
                var tournamentId = (int)selectedTournament.GetType().GetProperty("id").GetValue(selectedTournament, null);

                // Подтверждение удаления
                MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить турнир?",
                                                          "Подтверждение удаления",
                                                          MessageBoxButton.YesNo,
                                                          MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    using (var context = new user30_dbEntities())
                    {
                        // Загружаем турнир из базы данных по ID
                        var tournamentToDelete = context.ddTournament.FirstOrDefault(t => t.id == tournamentId);

                        if (tournamentToDelete != null)
                        {
                            context.ddTournament.Remove(tournamentToDelete);
                            context.SaveChanges();

                            // Обновляем DataGrid после удаления
                            LoadTournaments();
                            MessageBox.Show("Турнир успешно удален.");
                        }
                        else
                        {
                            MessageBox.Show("Не удалось найти турнир в базе данных.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите турнир для удаления.");
            }
        }
    }
}

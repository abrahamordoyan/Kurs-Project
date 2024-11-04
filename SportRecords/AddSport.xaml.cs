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
    /// Логика взаимодействия для AddSport.xaml
    /// </summary>
    public partial class AddSport : Window
    {
        private user30_dbEntities _context;
        public AddSport()
        {
            InitializeComponent();
            LoadSports();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        private void LoadSports()
        {
            using (var context = new user30_dbEntities())
            {
                var sports = context.ddSport.Select(s => new
                {
                    s.id,
                    s.name
                }).ToList();

                SportDataGrid.ItemsSource = sports;
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
            var addSportDialog = new AddSportDialog();
            if (addSportDialog.ShowDialog() == true)
            {
                LoadSports();  // Обновляем таблицу после добавления
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (SportDataGrid.SelectedItem != null)
            {
                // Получаем выбранный элемент из DataGrid
                var selectedSport = SportDataGrid.SelectedItem;

                // Извлекаем ID выбранного вида спорта
                var sportId = (int)selectedSport.GetType().GetProperty("id").GetValue(selectedSport, null);

                using (var context = new user30_dbEntities())
                {
                    // Загружаем вид спорта для редактирования по ID
                    var sportToEdit = context.ddSport.FirstOrDefault(s => s.id == sportId);
                    if (sportToEdit != null)
                    {
                        // Открываем диалоговое окно редактирования и передаем данные
                        var editDialog = new AddSportDialog(sportToEdit);
                        if (editDialog.ShowDialog() == true)
                        {
                            // Обновляем таблицу после успешного редактирования
                            LoadSports();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите вид спорта для редактирования.");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (SportDataGrid.SelectedItem != null)
            {
                var selectedSport = SportDataGrid.SelectedItem;
                var sportId = (int)selectedSport.GetType().GetProperty("id").GetValue(selectedSport, null);

                var result = MessageBox.Show("Вы действительно хотите удалить запись?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    using (var context = new user30_dbEntities())
                    {
                        var sportToDelete = context.ddSport.FirstOrDefault(s => s.id == sportId);
                        if (sportToDelete != null)
                        {
                            context.ddSport.Remove(sportToDelete);
                            context.SaveChanges();
                            LoadSports();  // Обновляем таблицу после удаления
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите вид спорта для удаления.");
            }
        }
    }
}

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
    /// Логика взаимодействия для AddAchievementName.xaml
    /// </summary>
    public partial class AddAchievementName : Window
    {
        private user30_dbEntities _context;
        public AddAchievementName()
        {
            InitializeComponent();
            LoadAchievementNames();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        private void LoadAchievementNames()
        {
            using (var context = new user30_dbEntities())
            {
                // Загружаем данные достижений
                var achievementNames = context.ddAchievementName
                    .Select(a => new
                    {
                        a.id,
                        a.name
                    })
                    .ToList();

                // Привязываем данные к DataGrid
                AchievementNameDataGrid.ItemsSource = achievementNames;
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
            // Открываем AddAchievementNameDialog как диалоговое окно
            var addAchievementNameDialog = new AddAchievementNameDialog();
            if (addAchievementNameDialog.ShowDialog() == true)
            {
                // Обновляем DataGrid после добавления
                LoadAchievementNames();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (AchievementNameDataGrid.SelectedItem != null)
            {
                // Получаем выбранное достижение
                var selectedAchievement = AchievementNameDataGrid.SelectedItem;

                // Извлекаем ID достижения
                var achievementId = (int)selectedAchievement.GetType().GetProperty("id").GetValue(selectedAchievement, null);

                using (var context = new user30_dbEntities())
                {
                    // Находим запись для редактирования
                    var achievementToEdit = context.ddAchievementName.FirstOrDefault(a => a.id == achievementId);
                    if (achievementToEdit != null)
                    {
                        // Открываем окно редактирования и передаем данные
                        var editDialog = new AddAchievementNameDialog(achievementToEdit);
                        if (editDialog.ShowDialog() == true)
                        {
                            // После редактирования обновляем данные
                            LoadAchievementNames();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите достижение для редактирования.");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (AchievementNameDataGrid.SelectedItem != null)
            {
                var selectedAchievement = AchievementNameDataGrid.SelectedItem;
                var achievementId = (int)selectedAchievement.GetType().GetProperty("id").GetValue(selectedAchievement, null);

                MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить достижение?",
                                                          "Подтверждение удаления",
                                                          MessageBoxButton.YesNo,
                                                          MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    using (var context = new user30_dbEntities())
                    {
                        var achievementToDelete = context.ddAchievementName.FirstOrDefault(a => a.id == achievementId);
                        if (achievementToDelete != null)
                        {
                            context.ddAchievementName.Remove(achievementToDelete);
                            context.SaveChanges();

                            // Обновляем DataGrid после удаления
                            LoadAchievementNames();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите достижение для удаления.");
            }
        }
    }
}

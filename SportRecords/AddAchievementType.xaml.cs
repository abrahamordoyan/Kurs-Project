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
    /// Логика взаимодействия для AddAchievementType.xaml
    /// </summary>
    public partial class AddAchievementType : Window
    {
        public AddAchievementType()
        {
            InitializeComponent();
            LoadAchievementTypes();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        private void LoadAchievementTypes()
        {
            using (var context = new user30_dbEntities())
            {
                var achievementTypes = context.ddAchievementType
                    .Select(t => new
                    {
                        t.id,
                        t.name
                    })
                    .ToList();

                AchievementTypeDataGrid.ItemsSource = achievementTypes;
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
            var addDialog = new AddAchievementTypeDialog();
            if (addDialog.ShowDialog() == true)
            {
                LoadAchievementTypes(); // Обновляем данные после добавления
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (AchievementTypeDataGrid.SelectedItem != null)
            {
                var selectedType = AchievementTypeDataGrid.SelectedItem;
                var typeId = (int)selectedType.GetType().GetProperty("id").GetValue(selectedType, null);  // Получаем ID выбранного типа достижения

                using (var context = new user30_dbEntities())
                {
                    var achievementTypeToEdit = context.ddAchievementType.FirstOrDefault(t => t.id == typeId);  // Находим объект по ID

                    if (achievementTypeToEdit != null)
                    {
                        var editDialog = new AddAchievementTypeDialog(achievementTypeToEdit);  // Передаем объект в диалоговое окно
                        if (editDialog.ShowDialog() == true)
                        {
                            LoadAchievementTypes();  // Обновляем данные после редактирования
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите тип достижения для редактирования.");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (AchievementTypeDataGrid.SelectedItem != null)
            {
                var selectedType = AchievementTypeDataGrid.SelectedItem;
                var typeId = (int)selectedType.GetType().GetProperty("id").GetValue(selectedType, null);

                MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить запись?",
                                                          "Подтверждение удаления",
                                                          MessageBoxButton.YesNo,
                                                          MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    using (var context = new user30_dbEntities())
                    {
                        var achievementTypeToDelete = context.ddAchievementType.FirstOrDefault(t => t.id == typeId);

                        if (achievementTypeToDelete != null)
                        {
                            context.ddAchievementType.Remove(achievementTypeToDelete);
                            context.SaveChanges();
                            LoadAchievementTypes(); // Обновляем данные после удаления
                            MessageBox.Show("Запись успешно удалена.");
                        }
                        else
                        {
                            MessageBox.Show("Не удалось найти запись в базе данных.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите тип достижения для удаления.");
            }
        }
    }
}

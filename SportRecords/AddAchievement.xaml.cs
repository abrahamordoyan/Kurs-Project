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
using System.Data.Entity;

namespace SportRecords
{
    /// <summary>
    /// Логика взаимодействия для AddAchievement.xaml
    /// </summary>
    public partial class AddAchievement : Window
    {
    
        private List<ddAchievement> _achievements;
        public AddAchievement()
        {
            InitializeComponent();
            LoadAchievements();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void LoadAchievements()
        {
            using (var context = new user30_dbEntities())
            {
                // Загружаем данные из таблицы достижений вместе с навигационными свойствами
                _achievements = context.ddAchievement
                    .Include(a => a.ddUser)  // Подключаем таблицу пользователей (спортсменов)
                    .Include(a => a.ddTournament)  // Подключаем турниры
                    .Include(a => a.ddAchievementName)  // Названия достижений
                    .Include(a => a.ddAchievementType)  // Типы достижений
                    .Include(a => a.ddSport)  // Виды спорта
                    .ToList();  // Загружаем данные в память

                // Подготавливаем данные для отображения в DataGrid
                var achievementDisplayList = _achievements.Select(a => new
                {
                    a.id,
                    a.date,
                    a.@event,
                    // Формируем ФИО спортсмена
                    AthleteFullName = a.ddUser != null
                        ? $"{a.ddUser.lastname} {a.ddUser.firstname} {a.ddUser.patronymic}"
                        : "Не указан",
                    // Название турнира
                    TournamentName = a.ddTournament != null ? a.ddTournament.name : "Не указан",
                    // Название достижения
                    AchievementName = a.ddAchievementName != null ? a.ddAchievementName.name : "Не указано",
                    // Тип достижения
                    AchievementTypeName = a.ddAchievementType != null ? a.ddAchievementType.name : "Не указан",
                    // Вид спорта
                    SportName = a.ddSport != null ? a.ddSport.name : "Не указан"
                }).ToList();

                // Привязываем данные к DataGrid для отображения
                AchievementDataGrid.ItemsSource = achievementDisplayList;
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
            var addAchievementDialog = new AddAchievementDialog();
            if (addAchievementDialog.ShowDialog() == true)
            {
                LoadAchievements();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (AchievementDataGrid.SelectedItem != null)
            {
                // Получаем индекс выбранной записи
                int selectedIndex = AchievementDataGrid.SelectedIndex;

                // Получаем оригинальный объект ddAchievement из коллекции _achievements
                var achievementToDelete = _achievements[selectedIndex];

                // Запрашиваем у пользователя подтверждение удаления
                MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить запись?",
                                                          "Подтверждение удаления",
                                                          MessageBoxButton.YesNo,
                                                          MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    using (var context = new user30_dbEntities())
                    {
                        // Находим объект в контексте базы данных
                        var achievement = context.ddAchievement.Find(achievementToDelete.id);

                        if (achievement != null)
                        {
                            // Удаляем объект из базы данных
                            context.ddAchievement.Remove(achievement);
                            context.SaveChanges();

                            // Обновляем DataGrid после удаления
                            LoadAchievements();
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
                MessageBox.Show("Выберите запись для удаления.");
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (AchievementDataGrid.SelectedItem != null)
            {
                // Получаем индекс выбранной записи
                int selectedIndex = AchievementDataGrid.SelectedIndex;

                // Используем оригинальный объект из _achievements для редактирования
                var achievementToEdit = _achievements[selectedIndex];

                // Открываем диалог редактирования
                var editDialog = new AddAchievementDialog(achievementToEdit);
                if (editDialog.ShowDialog() == true)
                {
                    // Перезагружаем данные после успешного редактирования
                    LoadAchievements();
                }
            }
            else
            {
                MessageBox.Show("Выберите запись для редактирования.");
            }
        }
    }
   
}
    


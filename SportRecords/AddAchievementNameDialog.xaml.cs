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
    /// Логика взаимодействия для AddAchievementNameDialog.xaml
    /// </summary>
    public partial class AddAchievementNameDialog : Window
    {
        private ddAchievementName _achievementNameToEdit;
        public AddAchievementNameDialog()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            TitleLabel.Content = "Добавление";
        }
        // Конструктор для редактирования достижения
        public AddAchievementNameDialog(ddAchievementName achievementNameToEdit) : this()
        {
            _achievementNameToEdit = achievementNameToEdit;

            // Устанавливаем заголовок "Редактирование"
            TitleLabel.Content = "Редактирование достижения";

            // Подгружаем данные для редактирования
            LoadAchievementNameData();
        }

        // Метод для загрузки данных в форму
        private void LoadAchievementNameData()
        {
            if (_achievementNameToEdit != null)
            {
                AchievementNameTextBox.Text = _achievementNameToEdit.name;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string achievementName = AchievementNameTextBox.Text;

            // Проверка, что все обязательные поля заполнены
            if (string.IsNullOrWhiteSpace(achievementName))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            using (var context = new user30_dbEntities())
            {
                if (_achievementNameToEdit == null)  // Добавление нового достижения
                {
                    var newAchievementName = new ddAchievementName
                    {
                        name = achievementName
                    };
                    context.ddAchievementName.Add(newAchievementName);
                }
                else  // Редактирование существующего достижения
                {
                    var achievementToUpdate = context.ddAchievementName.Find(_achievementNameToEdit.id);
                    if (achievementToUpdate != null)
                    {
                        achievementToUpdate.name = achievementName;
                    }
                }

                context.SaveChanges();
            }

            this.DialogResult = true;
            this.Close();
        }
    }
}

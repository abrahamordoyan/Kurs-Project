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
    /// Логика взаимодействия для AddAchievementTypeDialog.xaml
    /// </summary>
    public partial class AddAchievementTypeDialog : Window
    {
        private ddAchievementType _achievementTypeToEdit;
        public AddAchievementTypeDialog()
        {
            InitializeComponent();
            TitleLabel.Content = "Добавление";
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        public AddAchievementTypeDialog(ddAchievementType achievementTypeToEdit) : this()
        {
            _achievementTypeToEdit = achievementTypeToEdit;
            TitleLabel.Content = "Редактирование типа достижения";

            // Заполняем поля данными для редактирования
            LoadAchievementTypeData();
        }

        private void LoadAchievementTypeData()
        {
            if (_achievementTypeToEdit != null)
            {
                AchievementTypeNameTextBox.Text = _achievementTypeToEdit.name;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string achievementTypeName = AchievementTypeNameTextBox.Text;

            // Проверка на заполненность обязательных полей
            if (string.IsNullOrWhiteSpace(achievementTypeName))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            using (var context = new user30_dbEntities())
            {
                if (_achievementTypeToEdit == null)  // Если это новый тип достижения
                {
                    var newAchievementType = new ddAchievementType
                    {
                        name = achievementTypeName
                    };
                    context.ddAchievementType.Add(newAchievementType);
                }
                else  // Если редактируем существующий тип
                {
                    var achievementTypeToUpdate = context.ddAchievementType.Find(_achievementTypeToEdit.id);

                    if (achievementTypeToUpdate != null)
                    {
                        achievementTypeToUpdate.name = achievementTypeName;
                    }
                }

                context.SaveChanges();
            }

            this.DialogResult = true;
            this.Close();
        }
    }
}

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
    /// Логика взаимодействия для AddTeamDialog.xaml
    /// </summary>
    public partial class AddTeamDialog : Window
    {
        private ddTeam _teamToEdit;
        public AddTeamDialog()
        {
            InitializeComponent();
            TitleLabel.Content = "Добавление";
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        public AddTeamDialog(ddTeam teamToEdit) : this()
        {
            _teamToEdit = teamToEdit;
            TitleLabel.Content = "Редактирование команды";

            // Загружаем данные команды для редактирования
            LoadTeamData();
        }

        private void LoadTeamData()
        {
            if (_teamToEdit != null)
            {
                NameTextBox.Text = _teamToEdit.name;
                SportNameTextBox.Text = _teamToEdit.sport_name;
            }
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string sportName = SportNameTextBox.Text;

            // Проверка на заполненность обязательных полей
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(sportName))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            using (var context = new user30_dbEntities())
            {
                if (_teamToEdit == null)  // Если это новая команда
                {
                    var newTeam = new ddTeam
                    {
                        name = name,
                        sport_name = sportName
                    };
                    context.ddTeam.Add(newTeam);
                }
                else  // Если редактируем существующую команду
                {
                    var teamToUpdate = context.ddTeam.Find(_teamToEdit.id);

                    if (teamToUpdate != null)
                    {
                        teamToUpdate.name = name;
                        teamToUpdate.sport_name = sportName;
                    }
                }

                context.SaveChanges();
            }

            this.DialogResult = true;
            this.Close();
        }
    }
}

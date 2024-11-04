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
    /// Логика взаимодействия для AddTournamentDialog.xaml
    /// </summary>
    public partial class AddTournamentDialog : Window
    {
        private ddTournament _tournamentToEdit;
        public AddTournamentDialog()
        {
            InitializeComponent();
            TitleLabel.Content = "Добавление";
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        public AddTournamentDialog(ddTournament tournamentToEdit) : this()
        {
            _tournamentToEdit = tournamentToEdit;
            TitleLabel.Content = "Редактирование";

            // Заполняем поля данными турнира
            if (_tournamentToEdit != null)
            {
                NameTextBox.Text = _tournamentToEdit.name;
                StartDatePicker.SelectedDate = _tournamentToEdit.start_date;
                EndDatePicker.SelectedDate = _tournamentToEdit.end_date;
                LocationTextBox.Text = _tournamentToEdit.location;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            DateTime? startDate = StartDatePicker.SelectedDate;
            DateTime? endDate = EndDatePicker.SelectedDate;
            string location = LocationTextBox.Text;

            // Проверка на заполненность обязательных полей
            if (string.IsNullOrWhiteSpace(name) || startDate == null || endDate == null || string.IsNullOrWhiteSpace(location))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            using (var context = new user30_dbEntities())
            {
                if (_tournamentToEdit == null)  // Если это новый турнир
                {
                    var newTournament = new ddTournament
                    {
                        name = name,
                        start_date = startDate,
                        end_date = endDate,
                        location = location
                    };
                    context.ddTournament.Add(newTournament);
                }
                else  // Если редактируем существующий турнир
                {
                    var tournamentToUpdate = context.ddTournament.Find(_tournamentToEdit.id);

                    if (tournamentToUpdate != null)
                    {
                        tournamentToUpdate.name = name;
                        tournamentToUpdate.start_date = startDate;
                        tournamentToUpdate.end_date = endDate;
                        tournamentToUpdate.location = location;
                    }
                }

                context.SaveChanges();
            }

            this.DialogResult = true;
            this.Close();
        }
    }
}

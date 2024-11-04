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
    /// Логика взаимодействия для AddAchievementDialog.xaml
    /// </summary>
    public partial class AddAchievementDialog : Window
    {
        private ddAchievement _achievementToEdit;

        public AddAchievementDialog()
        {
            InitializeComponent();
            LoadDropdowns();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            TitleLabel.Content = "Добавление";  // Устанавливаем надпись
        }
        public AddAchievementDialog(ddAchievement achievementToEdit) : this()
        {
            _achievementToEdit = achievementToEdit;

            TitleLabel.Content = "Редактирование";

            // Заполняем поля для редактирования
            EventTextBox.Text = _achievementToEdit.@event;
            AchievementDatePicker.SelectedDate = _achievementToEdit.date;
            AthleteComboBox.SelectedValue = _achievementToEdit.id_athlete;
            TournamentComboBox.SelectedValue = _achievementToEdit.id_tournament;
            AchievementNameComboBox.SelectedValue = _achievementToEdit.id_achievementName;
            AchievementTypeComboBox.SelectedValue = _achievementToEdit.id_achievementType;
            SportComboBox.SelectedValue = _achievementToEdit.id_sport;
        }

        private void LoadDropdowns()
        {
            using (var context = new user30_dbEntities())
            {
                AthleteComboBox.ItemsSource = context.ddUser.ToList();
                AthleteComboBox.DisplayMemberPath = "patronymic";
                AthleteComboBox.SelectedValuePath = "id";

                TournamentComboBox.ItemsSource = context.ddTournament.ToList();
                TournamentComboBox.DisplayMemberPath = "name";
                TournamentComboBox.SelectedValuePath = "id";

                AchievementNameComboBox.ItemsSource = context.ddAchievementName.ToList();
                AchievementNameComboBox.DisplayMemberPath = "name";
                AchievementNameComboBox.SelectedValuePath = "id";

                AchievementTypeComboBox.ItemsSource = context.ddAchievementType.ToList();
                AchievementTypeComboBox.DisplayMemberPath = "name";
                AchievementTypeComboBox.SelectedValuePath = "id";

                SportComboBox.ItemsSource = context.ddSport.ToList();
                SportComboBox.DisplayMemberPath = "name";
                SportComboBox.SelectedValuePath = "id";
            }
        }



        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Получаем значения полей
            string eventName = EventTextBox.Text;
            DateTime? achievementDate = AchievementDatePicker.SelectedDate;
            int? athleteId = (int?)AthleteComboBox.SelectedValue;
            int? tournamentId = (int?)TournamentComboBox.SelectedValue;
            int? achievementNameId = (int?)AchievementNameComboBox.SelectedValue;
            int? achievementTypeId = (int?)AchievementTypeComboBox.SelectedValue;
            int? sportId = (int?)SportComboBox.SelectedValue;

            // Проверка обязательных полей
            if (string.IsNullOrWhiteSpace(eventName) ||
                !achievementDate.HasValue ||
                athleteId == null ||
                tournamentId == null ||
                achievementNameId == null ||
                achievementTypeId == null ||
                sportId == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля перед сохранением.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            using (var context = new user30_dbEntities())
            {
                if (_achievementToEdit == null)  // Если это новое достижение
                {
                    var newAchievement = new ddAchievement
                    {
                        @event = eventName,
                        date = achievementDate,
                        id_athlete = athleteId,
                        id_tournament = tournamentId,
                        id_achievementName = achievementNameId,
                        id_achievementType = achievementTypeId,
                        id_sport = sportId
                    };

                    context.ddAchievement.Add(newAchievement);
                }
                else  // Если редактируем существующее достижение
                {
                    var achievementToUpdate = context.ddAchievement.Find(_achievementToEdit.id);

                    if (achievementToUpdate != null)
                    {
                        achievementToUpdate.@event = eventName;
                        achievementToUpdate.date = achievementDate;
                        achievementToUpdate.id_athlete = athleteId;
                        achievementToUpdate.id_tournament = tournamentId;
                        achievementToUpdate.id_achievementName = achievementNameId;
                        achievementToUpdate.id_achievementType = achievementTypeId;
                        achievementToUpdate.id_sport = sportId;
                    }
                }

                context.SaveChanges();
            }

            this.DialogResult = true;
            this.Close();
        }
    }
}
        
    


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
    /// Логика взаимодействия для AddUserDialog.xaml
    /// </summary>
    public partial class AddUserDialog : Window
    {
        private ddUser _userToEdit;
        public AddUserDialog()
        {
            InitializeComponent();
            LoadTeamsAndRoles();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            TitleLabel.Content = "Добавление";  // Устанавливаем надпись
        }

        // Конструктор для редактирования пользователя
        public AddUserDialog(ddUser userToEdit) : this()
        {
            _userToEdit = userToEdit;
            TitleLabel.Content = "Редактирование";

            // Заполняем поля данными пользователя
            FirstnameTextBox.Text = _userToEdit.firstname;
            LastnameTextBox.Text = _userToEdit.lastname;
            PatronymicTextBox.Text = _userToEdit.patronymic;
            BirthDatePicker.SelectedDate = _userToEdit.birth_date;
            TeamComboBox.SelectedValue = _userToEdit.id_team;
            RoleComboBox.SelectedValue = _userToEdit.id_role;
            LoginTextBox.Text = _userToEdit.login;
            PasswordTextBox.Password = _userToEdit.password;
            PhotoPathTextBox.Text = _userToEdit.photoPath ?? "Нет фото";  // Отображаем путь к фото или "Нет фото"

            // Устанавливаем значение пола
            if (_userToEdit.gender == "Мужской")
            {
                GenderComboBox.SelectedIndex = 0;
            }
            else if (_userToEdit.gender == "Женский")
            {
                GenderComboBox.SelectedIndex = 1;
            }
        }

        private void LoadTeamsAndRoles()
        {
            using (var context = new user30_dbEntities())
            {
                // Загружаем команды
                var teams = context.ddTeam.ToList();
                TeamComboBox.ItemsSource = teams;
                TeamComboBox.DisplayMemberPath = "name";  // Отображаем название команды
                TeamComboBox.SelectedValuePath = "id";    // ID сохраняется как SelectedValue

                // Загружаем роли
                var roles = context.ddRole.ToList();
                RoleComboBox.ItemsSource = roles;
                RoleComboBox.DisplayMemberPath = "name";  // Отображаем название роли
                RoleComboBox.SelectedValuePath = "id";    // ID сохраняется как SelectedValue
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Получаем значения полей
            string firstname = FirstnameTextBox.Text;
            string lastname = LastnameTextBox.Text;
            string patronymic = PatronymicTextBox.Text;
            DateTime? birthDate = BirthDatePicker.SelectedDate;
            int? selectedTeamId = (int?)TeamComboBox.SelectedValue;
            int? selectedRoleId = (int?)RoleComboBox.SelectedValue;
            string login = LoginTextBox.Text;
            string password = PasswordTextBox.Password;
            string photoPath = string.IsNullOrWhiteSpace(PhotoPathTextBox.Text) ? null : PhotoPathTextBox.Text;

            // Проверка обязательных полей
            if (string.IsNullOrWhiteSpace(firstname) ||
                string.IsNullOrWhiteSpace(lastname) ||
                !birthDate.HasValue ||
                selectedRoleId == null ||
                string.IsNullOrWhiteSpace(login) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля.\nПоля 'Фото' и 'Команда' являются необязательными.",
                                "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            using (var context = new user30_dbEntities())
            {
                if (_userToEdit == null)  // Если это новый пользователь
                {
                    var newUser = new ddUser
                    {
                        firstname = firstname,
                        lastname = lastname,
                        patronymic = patronymic,
                        birth_date = birthDate,
                        id_team = selectedTeamId,   // Команда может быть пустой
                        id_role = selectedRoleId,
                        login = login,
                        password = password,
                        photoPath = photoPath       // Фото может быть пустым
                    };

                    context.ddUser.Add(newUser);
                }
                else  // Если редактируем существующего пользователя
                {
                    var userToUpdate = context.ddUser.Find(_userToEdit.id);

                    if (userToUpdate != null)
                    {
                        userToUpdate.firstname = firstname;
                        userToUpdate.lastname = lastname;
                        userToUpdate.patronymic = patronymic;
                        userToUpdate.birth_date = birthDate;
                        userToUpdate.id_team = selectedTeamId;   // Команда может быть пустой
                        userToUpdate.id_role = selectedRoleId;
                        userToUpdate.login = login;
                        userToUpdate.password = password;
                        userToUpdate.photoPath = photoPath;      // Фото может быть пустым
                    }
                }

                context.SaveChanges();
            }

            this.DialogResult = true;
            this.Close();
        }
    }
}

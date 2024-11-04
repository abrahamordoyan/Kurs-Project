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
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        private user30_dbEntities _context;
        public AddUser()
        {
            InitializeComponent();
            LoadUsers();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        private void LoadUsers()
        {
            using (var context = new user30_dbEntities())
            {
                // Загружаем данные пользователей вместе с их командами и ролями
                var users = context.ddUser
                    .Include(u => u.ddTeam)  // Загружаем связанную таблицу команд
                    .Include(u => u.ddRole)  // Загружаем связанную таблицу ролей
                    .Select(u => new
                    {
                        u.id,
                        u.firstname,
                        u.lastname,
                        u.patronymic,
                        u.gender,
                        u.birth_date,
                        Photo = string.IsNullOrEmpty(u.photoPath) ? "Нет фото" : u.photoPath, // Проверка photoPath
                        Team = u.ddTeam != null ? u.ddTeam.name : "Нет команды", // Если команда не указана
                        Role = u.ddRole != null ? u.ddRole.name : "Нет роли",    // Если роль не указана
                        u.login,
                        u.password
                    })
                    .ToList();

                foreach (var user in users)
                {
                    Console.WriteLine($"ID: {user.id}, Фото: {user.Photo}");
                }

                // Привязываем данные к DataGrid
                UserDataGrid.ItemsSource = users;
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
            // Открываем AddUserDialog как диалоговое окно
            var addUserDialog = new AddUserDialog();
            if (addUserDialog.ShowDialog() == true)
            {
                // Здесь обновляем DataGrid, если пользователь был успешно добавлен
                LoadUsers();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (UserDataGrid.SelectedItem != null)
            {
                // Получаем ID выбранного пользователя
                var selectedUser = UserDataGrid.SelectedItem;

                // Извлекаем ID из анонимного типа
                var userId = (int)selectedUser.GetType().GetProperty("id").GetValue(selectedUser, null);

                using (var context = new user30_dbEntities())
                {
                    // Загружаем пользователя из базы данных по ID
                    var userToEdit = context.ddUser.FirstOrDefault(u => u.id == userId);

                    if (userToEdit != null)
                    {
                        // Открываем диалоговое окно редактирования и передаем данные
                        var editDialog = new AddUserDialog(userToEdit);
                        if (editDialog.ShowDialog() == true)
                        {
                            // После редактирования обновляем DataGrid
                            LoadUsers();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите запись для редактирования.");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (UserDataGrid.SelectedItem != null)
            {
                // Получаем ID выбранного пользователя
                var selectedUser = UserDataGrid.SelectedItem;

                // Извлекаем ID из анонимного типа
                var userId = (int)selectedUser.GetType().GetProperty("id").GetValue(selectedUser, null);

                // Подтверждение удаления
                MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить запись?",
                                                          "Подтверждение удаления",
                                                          MessageBoxButton.YesNo,
                                                          MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    using (var context = new user30_dbEntities())
                    {
                        // Загружаем пользователя из базы данных по ID
                        var userToDelete = context.ddUser.FirstOrDefault(u => u.id == userId);

                        if (userToDelete != null)
                        {
                            context.ddUser.Remove(userToDelete);
                            context.SaveChanges();

                            // Обновляем DataGrid после удаления
                            LoadUsers();
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
    }
}

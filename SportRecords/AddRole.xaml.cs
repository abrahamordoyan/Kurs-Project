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
    /// Логика взаимодействия для AddRole.xaml
    /// </summary>
    public partial class AddRole : Window
    {
        public AddRole()
        {
            InitializeComponent();
            LoadRoles();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        private void LoadRoles()
        {
            using (var context = new user30_dbEntities())
            {
                var roles = context.ddRole.ToList();
                RoleDataGrid.ItemsSource = roles;
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
            var addRoleDialog = new AddRoleDialog();
            if (addRoleDialog.ShowDialog() == true)
            {
                LoadRoles();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (RoleDataGrid.SelectedItem != null)
            {
                var selectedRole = (ddRole)RoleDataGrid.SelectedItem;

                var editDialog = new AddRoleDialog(selectedRole);
                if (editDialog.ShowDialog() == true)
                {
                    LoadRoles();  // Обновляем данные после редактирования
                }
            }
            else
            {
                MessageBox.Show("Выберите роль для редактирования.");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (RoleDataGrid.SelectedItem != null)
            {
                var selectedRole = (ddRole)RoleDataGrid.SelectedItem;

                MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить эту роль?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    using (var context = new user30_dbEntities())
                    {
                        var roleToDelete = context.ddRole.FirstOrDefault(r => r.id == selectedRole.id);
                        if (roleToDelete != null)
                        {
                            context.ddRole.Remove(roleToDelete);
                            context.SaveChanges();
                            LoadRoles();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите роль для удаления.");
            }
        }
    }
}

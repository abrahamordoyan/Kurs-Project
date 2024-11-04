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
    /// Логика взаимодействия для AddRoleDialog.xaml
    /// </summary>
    public partial class AddRoleDialog : Window
    {
        private ddRole _roleToEdit;
        public AddRoleDialog()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            TitleLabel.Content = "Добавление";
        }

        // Конструктор для редактирования роли
        public AddRoleDialog(ddRole roleToEdit) : this()
        {
            _roleToEdit = roleToEdit;
            TitleLabel.Content = "Редактирование роли";
            LoadRoleData();
        }

        private void LoadRoleData()
        {
            if (_roleToEdit != null)
            {
                RoleNameTextBox.Text = _roleToEdit.name;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string roleName = RoleNameTextBox.Text;

            // Проверка на заполненность обязательного поля
            if (string.IsNullOrWhiteSpace(roleName))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            using (var context = new user30_dbEntities())
            {
                if (_roleToEdit == null)  // Добавление новой роли
                {
                    var newRole = new ddRole
                    {
                        name = roleName
                    };
                    context.ddRole.Add(newRole);
                }
                else  // Редактирование существующей роли
                {
                    var roleToUpdate = context.ddRole.Find(_roleToEdit.id);
                    if (roleToUpdate != null)
                    {
                        roleToUpdate.name = roleName;
                    }
                }

                context.SaveChanges();
            }

            this.DialogResult = true;
            this.Close();
        }
    }
}

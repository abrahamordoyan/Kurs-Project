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
    /// Логика взаимодействия для AddSportDialog.xaml
    /// </summary>
    public partial class AddSportDialog : Window
    {
        private ddSport _sportToEdit;
        public AddSportDialog()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            TitleLabel.Content = "Добавление";
        }
        public AddSportDialog(ddSport sportToEdit) : this()
        {
            _sportToEdit = sportToEdit;
            TitleLabel.Content = "Редактирование";
            LoadSportData();
        }

        // Загрузка данных для редактирования
        private void LoadSportData()
        {
            if (_sportToEdit != null)
            {
                SportNameTextBox.Text = _sportToEdit.name;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string sportName = SportNameTextBox.Text;

            // Проверка на заполненность обязательного поля
            if (string.IsNullOrWhiteSpace(sportName))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            using (var context = new user30_dbEntities())
            {
                if (_sportToEdit == null)  // Если это добавление нового вида спорта
                {
                    var newSport = new ddSport
                    {
                        name = sportName
                    };
                    context.ddSport.Add(newSport);
                }
                else  // Если это редактирование существующего вида спорта
                {
                    var sportToUpdate = context.ddSport.Find(_sportToEdit.id);
                    if (sportToUpdate != null)
                    {
                        sportToUpdate.name = sportName;
                    }
                }

                context.SaveChanges();
            }

            this.DialogResult = true;
            this.Close();
        }
    }
}

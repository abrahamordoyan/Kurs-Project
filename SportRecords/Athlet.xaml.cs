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
    /// Логика взаимодействия для Athlet.xaml
    /// </summary>
    public partial class Athlet : Window
    {
        private user30_dbEntities _context;
        private int _currentPage = 1;
        private int _pageSize = 3; // Устанавливаем количество записей на странице
        private int _totalPages;
        private int _totalItems; // Общее количество записей

        public Athlet()
        {
            InitializeComponent();
            GenderCB.SelectedIndex = 2; // Устанавливаем значение "все" по умолчанию
            LoadData();
            LoadUserLabel(FILabel);
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            GenderCB.SelectionChanged += GenderCB_SelectionChanged;
            SortCB.SelectionChanged += SortCB_SelectionChanged;
            SearchBox.TextChanged += SearchBox_TextChanged;
            PagesCB.SelectionChanged += PagesCB_SelectionChanged; // Подписка на изменение количества записей
        }

        public static void LoadUserLabel(Label lbl)
        {
            using (var context = new user30_dbEntities()) // Используем ваш контекст базы данных
            {
                var user = context.ddUser.FirstOrDefault(u => u.id == MainWindow.UserID); // Предположим, что "id" — это идентификатор пользователя

                if (user != null)
                {
                    lbl.Content = user.firstname + " " + user.lastname; // Предполагаем, что есть поля firstname и lastname
                }
                else
                {
                    lbl.Content = "Пользователь не найден"; // В случае, если пользователь не найден
                }
            }
        }

        private void LoadData()
        {
            using (var context = new user30_dbEntities())
            {
                string searchText = SearchBox.Text?.ToLower().Trim();
                string selectedGender = GenderCB.SelectedValue?.ToString().ToLower();

                var query = context.ddUser
                    .Join(context.ddAchievement,
                        user => user.id,
                        achievement => achievement.id_athlete,
                        (user, achievement) => new
                        {
                            user.id,
                            user.firstname,
                            user.lastname,
                            user.patronymic,
                            user.birth_date,
                            user.gender,
                            user.photoPath,
                            achievement.date,
                            achievement.@event,
                            TournamentName = achievement.ddTournament != null ? achievement.ddTournament.name : "Не указан",
                            TournamentLocation = achievement.ddTournament != null ? achievement.ddTournament.location : "Не указано",
                            SportType = achievement.ddSport != null ? achievement.ddSport.name : "Не указан",
                            TeamName = user.ddTeam != null ? user.ddTeam.name : "Не указана",
                            AchievementName = achievement.ddAchievementName != null ? achievement.ddAchievementName.name : "Не указано",
                            AchievementTypeName = achievement.ddAchievementType != null ? achievement.ddAchievementType.name : "Не указан"
                        }).ToList();

                if (selectedGender == "мужской" || selectedGender == "женский")
                {
                    query = query.Where(item => item.gender?.ToLower() == selectedGender).ToList();
                }

                string selectedSort = SortCB.SelectedValue?.ToString();
                if (selectedSort == "По фамилии")
                {
                    query = query.OrderBy(item => item.lastname).ToList();
                }
                else if (selectedSort == "По дате рождения")
                {
                    query = query.OrderByDescending(item => item.birth_date).ToList();
                }

                if (!string.IsNullOrEmpty(searchText))
                {
                    query = query.Where(item =>
                        $"{item.lastname} {item.firstname} {item.patronymic}".ToLower().Contains(searchText) ||
                        item.SportType.ToLower().Contains(searchText)).ToList();
                }

                _totalItems = query.Count;
                _totalPages = (int)Math.Ceiling((double)_totalItems / _pageSize);

                var paginatedData = query
                    .Skip((_currentPage - 1) * _pageSize)
                    .Take(_pageSize)
                    .Select(item => new
                    {
                        item.id,
                        Fullname = $"{item.lastname} {item.firstname} {item.patronymic}",
                        Gender = string.IsNullOrEmpty(item.gender) ? "Не указан" : item.gender,
                        Birthday = item.birth_date?.ToString("dd.MM.yyyy") ?? "Не указана",
                        AchievementDate = item.date?.ToString("dd.MM.yyyy") ?? "Не указана",
                        AchievementEvent = item.@event,
                        TournamentName = item.TournamentName,
                        TournamentLocation = item.TournamentLocation,
                        SportType = item.SportType,
                        TeamName = item.TeamName,
                        AchievementName = item.AchievementName,
                        AchievementTypeName = item.AchievementTypeName,
                        PhotoImage = LoadImageFromResources(item.photoPath)
                    })
                    .ToList();

                listView.ItemsSource = paginatedData;
                NumberPage.Text = _currentPage.ToString();
                PrevButton.IsEnabled = _currentPage > 1;
                NextButton.IsEnabled = _currentPage < _totalPages;
            }
        }

        // Метод для загрузки изображения
        private BitmapImage LoadImageFromResources(string photoPath)
        {
            var bitmap = new BitmapImage();
            try
            {
                if (!string.IsNullOrEmpty(photoPath))
                {
                    var uri = new Uri($"pack://application:,,,/{photoPath}", UriKind.Absolute);
                    bitmap.BeginInit();
                    bitmap.UriSource = uri;
                    bitmap.EndInit();
                }
                else
                {
                    // Указываем путь к изображению по умолчанию
                    var defaultUri = new Uri("pack://application:,,,/Resources/Спортсмены/default.png", UriKind.Absolute);
                    bitmap.BeginInit();
                    bitmap.UriSource = defaultUri;
                    bitmap.EndInit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки изображения: {ex.Message}");
            }
            return bitmap;
        }

        private void GenderCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _currentPage = 1;
            LoadData();
        }

        private void SortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _currentPage = 1;
            LoadData();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _currentPage = 1;
            LoadData();
        }

        private void PagesCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = (ComboBoxItem)PagesCB.SelectedItem;
            string selectedValue = selectedItem?.Content?.ToString();
            _currentPage = 1;

            // Устанавливаем _pageSize в зависимости от выбора
            if (selectedValue == "Все")
            {
                _pageSize = _totalItems; // Показываем все записи
            }
            else if (int.TryParse(selectedValue, out int parsedSize))
            {
                _pageSize = parsedSize;
            }

            LoadData();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var form = new MainWindow();
            form.Show();
            this.Hide();
        }

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                LoadData();
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                LoadData();
            }
        }

        private void LKButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new user30_dbEntities())
            {
                // Получаем текущего пользователя по его ID
                var currentUser = context.ddUser.Find(MainWindow.UserID);

                if (currentUser != null)
                {
                    var form = new AthletProfile(currentUser); // Передаем currentUser в конструктор
                    form.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Пользователь не найден.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}

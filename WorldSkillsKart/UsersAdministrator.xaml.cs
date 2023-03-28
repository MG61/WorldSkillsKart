using WorldSkillsKart.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WorldSkillsKart
{
    /// <summary>
    /// Логика взаимодействия для UsersAdministrator.xaml
    /// </summary>
    public partial class UsersAdministrator : Window
    {
        DataSet1 DataSet1 = new DataSet1();
        UserTableAdapter userTableAdapter = new UserTableAdapter();
        //View_UserTableAdapter View_UserTableAdapter = new View_UserTableAdapter();

        public UsersAdministrator()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            userTableAdapter.Fill(DataSet1.User);

            UsersGrid.ItemsSource = DataSet1.User.DefaultView;
            UsersGrid.SelectionMode = DataGridSelectionMode.Single;
            UsersGrid.SelectedValuePath = "Email";
            UsersGrid.CanUserAddRows = false;
            UsersGrid.CanUserDeleteRows = false;
            UsersGrid.IsReadOnly = true;
            Thread th = new Thread(TimerStart);
            th.Start();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            UsersGrid.Columns[5].MinWidth = 160;
            UsersGrid.Columns[1].MinWidth = 220;
            UsersGrid.Columns[3].MinWidth = 110;
            UsersGrid.Columns[4].MinWidth = 130;
            UsersGrid.Columns[2].Visibility = Visibility.Hidden;
            UsersGrid.Columns[3].Header = "Имя";
            UsersGrid.Columns[4].Header = "Фамилия";
            UsersGrid.Columns[5].Header = "Роль";
            UsersGrid.Columns[0].DisplayIndex = 5;
            UsersGrid.Columns[1].DisplayIndex = 3;
            UsersGrid.Columns[3].DisplayIndex = 0;
            UsersGrid.Columns[4].DisplayIndex = 1;
        }


        void TimerStart()
        {
            DispatcherTimer _timer;
            TimeSpan _time;
            _time = TimeSpan.FromHours(24);

            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                DateTime date1 = new DateTime(2022, 2, 15, 15, 29, 59);
                DateTime dateNow = DateTime.Now;
                int yearsLeft = (int)date1.Year - (int)dateNow.Year;
                int monthsLeft = (int)date1.Month - (int)dateNow.Month;
                int daysLeft = (int)date1.Day - (int)dateNow.Day;
                int hoursLeft;

                if ((int)date1.Day == (int)dateNow.Day)
                {
                    hoursLeft = (int)date1.Hour - (int)dateNow.Hour;
                }
                else { hoursLeft = 24 - (int)dateNow.Hour; }
                int minutesLeft;
                if ((int)date1.Hour == (int)dateNow.Hour)
                {
                    minutesLeft = (int)date1.Minute - (int)dateNow.Minute;

                }
                else { minutesLeft = 60 - (int)dateNow.Minute; }

                int secondsLeft;
                if ((int)date1.Minute == (int)dateNow.Minute)
                {
                    secondsLeft = (int)date1.Second - (int)dateNow.Second;
                }
                else { secondsLeft = 60 - (int)dateNow.Second; }

                TextTimer.Text = $"До события: {yearsLeft} Лет {monthsLeft} Месяцев {daysLeft} Дней {hoursLeft} Часов {minutesLeft} Минут {secondsLeft} Секунд";

                if (dateNow >= date1)
                {
                    TextTimer.Text = "Событие началось!";
                }
                _time = _time.Add(TimeSpan.FromSeconds(-1));
            },
            Application.Current.Dispatcher);
            _timer.Start();
        }


        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AdministratorMenu administratorMenu = new AdministratorMenu();
            administratorMenu.Show();
            this.Close();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow back = new MainWindow();
            back.Show();
            this.Close();
        }

        private void Add_Users_Click(object sender, RoutedEventArgs e)
        {
            AddUsersAdministrator addUsersAdministrator = new AddUsersAdministrator();
            addUsersAdministrator.Show();
            this.Close();
        }

        private void EditUsers(object sender, RoutedEventArgs e)
        {
            AddUsersAdministrator addUsersAdministrator = new AddUsersAdministrator();
            addUsersAdministrator.Show();
            this.Close();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            userTableAdapter.Fill(DataSet1.User);
            UsersGrid.ItemsSource = DataSet1.User.DefaultView;
            MessageBox.Show("Успешное обновление!");
        }
    }
}

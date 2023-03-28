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
    public partial class VolontyersAdministrator : Window
    {

        DataSet1 DataSet1 = new DataSet1();
        VolunteerTableAdapter VolunteerTableAdapter = new VolunteerTableAdapter();

        public VolontyersAdministrator()
        {
            InitializeComponent();

            Thread th = new Thread(TimerStart);
            th.Start();

            VolunteerTableAdapter.Fill(DataSet1.Volunteer);


            this.Loaded += MainWindow_Loaded;
            VolunteerGrid.ItemsSource = DataSet1.Volunteer.DefaultView;
            VolunteerGrid.SelectionMode = DataGridSelectionMode.Single;
            VolunteerGrid.SelectedValuePath = "Email";
            VolunteerGrid.CanUserAddRows = false;
            VolunteerGrid.CanUserDeleteRows = false;
            VolunteerGrid.IsReadOnly = true;


        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

            VolunteerGrid.Columns[0].Visibility = Visibility.Hidden;
            VolunteerGrid.Columns[1].Header = "Имя";
            VolunteerGrid.Columns[2].Header = "Фамилия";
            VolunteerGrid.Columns[3].Header = "Страна";
            VolunteerGrid.Columns[4].Header = "Пол";
            VolunteerGrid.Columns[1].DisplayIndex = 1;
            VolunteerGrid.Columns[2].DisplayIndex = 0;

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


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            VolonteeerDownload volonteeerDownload = new VolonteeerDownload();
            volonteeerDownload.Show();
            this.Close();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow back = new MainWindow();
            back.Show();
            this.Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
           AdministratorMenu back = new AdministratorMenu();
            back.Show();
            this.Close();
        }
    }
}

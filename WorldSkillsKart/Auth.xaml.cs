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
using WorldSkillsKart.DataSet1TableAdapters;

namespace WorldSkillsKart
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        DataSet1 dataSet = new DataSet1();
        UserTableAdapter UTA = new UserTableAdapter();
        
        public Auth()
        {
            InitializeComponent();
            Thread th = new Thread(TimerStart);
            th.Start();
            UTA.Fill(dataSet.User);
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

                Timer.Text = $"До события: {yearsLeft} Лет {monthsLeft} Месяцев {daysLeft} Дней {hoursLeft} Часов {minutesLeft} Минут {secondsLeft} Секунд";

                if (dateNow >= date1)
                {
                    Timer.Text = "Событие началось!";
                }
                _time = _time.Add(TimeSpan.FromSeconds(-1));
            },
            Application.Current.Dispatcher);
            _timer.Start();
        }


        private void Back(object sender, RoutedEventArgs e)
        {
            MainWindow back = new MainWindow();
            back.Show();
            this.Close();
        }

        private void auth(object sender, RoutedEventArgs e)
        {
            string log = email.Text;
            string pass = password.Text;
            RacerAuth(log, pass);
            AdminAuth(log, pass);
            CordAuth(log, pass);
        }

        private void RacerAuth(string adminlog, string adminpass)
        {
            try
            {
                for (int i = 0; i < dataSet.User.Rows.Count; i++)
                {
                    if (i > dataSet.User.Rows.Count)
                    {
                        return;
                    }
                    else if (adminlog == dataSet.User.Rows[i][0].ToString() && adminpass == dataSet.User.Rows[i][1].ToString() && "R" == dataSet.User.Rows[i][4].ToString())
                    {
                        MenuKart adm = new MenuKart();
                        adm.Show();
                        this.Close();
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private void AdminAuth(string adminlog, string adminpass)
        {
            try
            {
                for (int i = 0; i < dataSet.User.Rows.Count; i++)
                {
                    if (i > dataSet.User.Rows.Count)
                    {
                        return;
                    }
                    else if (adminlog == dataSet.User.Rows[i][0].ToString() && adminpass == dataSet.User.Rows[i][1].ToString() && "A" == dataSet.User.Rows[i][4].ToString())
                    {
                        AdministratorMenu adm = new AdministratorMenu();
                        adm.Show();
                        this.Close();
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private void CordAuth(string adminlog, string adminpass)
        {
            try
            {
                for (int i = 0; i < dataSet.User.Rows.Count; i++)
                {
                    if (i > dataSet.User.Rows.Count)
                    {
                        return;
                    }
                    else if (adminlog == dataSet.User.Rows[i][0].ToString() && adminpass == dataSet.User.Rows[i][1].ToString() && "C" == dataSet.User.Rows[i][4].ToString())
                    {
                        Koordinmenu adm = new Koordinmenu();
                        adm.Show();
                        this.Close();
                    }
                }
            }
            catch
            {
                return;
            }
        }
    }
}

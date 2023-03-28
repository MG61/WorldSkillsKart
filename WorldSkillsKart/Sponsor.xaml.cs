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
    /// Логика взаимодействия для Sponsor.xaml
    /// </summary>
    public partial class Sponsor : Window
    {
        public Sponsor()
        {
            InitializeComponent();
            Thread th = new Thread(TimerStart);
            th.Start();
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

        private void Pozhertvminus(object sender, RoutedEventArgs e)
        {
            int Poz1 = Convert.ToInt32(Pozhertv.Text);
            if (Poz1 > 50)
            {
                int Poz = Convert.ToInt32(Pozhertv.Text);
                Poz -= 10;
                Pozhertv.Text = Poz.ToString();
                BigPrice.Text = ("$ " + Poz.ToString());
            }   
        }

        private void Pozhertvplus(object sender, RoutedEventArgs e)
        {
            int Poz = Convert.ToInt32(Pozhertv.Text);
            Poz += 10;
            Pozhertv.Text = Poz.ToString();
            BigPrice.Text = ("$ " + Poz.ToString());
        }

        private void Pay(object sender, RoutedEventArgs e)
        {
            if (name.Text != "Ваше имя" && name_card.Text != "Владелец карты" && date.Text != "01/17" && CVC.Text != "CVC")
            {
                if (!String.IsNullOrWhiteSpace(name.Text) && !String.IsNullOrWhiteSpace(name_card.Text) && !String.IsNullOrWhiteSpace(num_card.Text) && !String.IsNullOrWhiteSpace(date.Text) && !String.IsNullOrWhiteSpace(CVC.Text))
                {
                    PaySponsor go = new PaySponsor();
                    go.Show();
                    this.Close();
                }
                else { MessageBox.Show("Заполните данные!"); }
            }
            else { MessageBox.Show("Заполните данные!"); }
        }
    }
}

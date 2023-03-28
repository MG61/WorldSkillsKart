using WorldSkillsKart.DataSet1TableAdapters;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WorldSkillsKart
{
    public partial class AddCharityExcpence : Window
    {
        string NamFile;

        DataSet1 DataSet1 = new DataSet1();
        BitmapImage ImageSource = new BitmapImage();
        CharityTableAdapter CharityTableAdapter = new CharityTableAdapter();
        public AddCharityExcpence()
        {

            Thread th = new Thread(TimerStart);
            th.Start();
            InitializeComponent();


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

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (!Name.Text.Equals(""))
            {
                var data = File.ReadAllBytes(NamFile);
                CharityTableAdapter.Insert(Name.Text, About.Text, data);
                var image = new BitmapImage();
                using (var mem = new MemoryStream(data))
                {
                    mem.Position = 0;
                    image.BeginInit();
                    image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.UriSource = null;
                    image.StreamSource = mem;
                    image.EndInit();
                }
                image.Freeze();
                DownloadImage.Source = image;
                MessageBox.Show("Успешное создание!");
                Name.Text = "";
                About.Text = "";
                FileNameBox.Text = "";
                DownloadImage.Source = null;
            }


        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            CharityAdministrator charityAdministrator = new CharityAdministrator();
            charityAdministrator.Show();
            this.Close();
        }

        private void View_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файл логотипа (*.jpg)|*.jpg";

            if (openFileDialog.ShowDialog() == true)
            {
                string FileName;
                NamFile = openFileDialog.FileName;
                string path = NamFile;



                FileName = openFileDialog.SafeFileName;
                if (NamFile.Contains(".jpg"))
                {
                    MessageBox.Show("Успешное открытие!");

                    FileNameBox.Text = FileName;
                    DownloadImage.Source = new BitmapImage(new Uri(NamFile));

                }
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            CharityAdministrator charityAdministrator = new CharityAdministrator();
            charityAdministrator.Show();
            this.Close();
        }
    }
}

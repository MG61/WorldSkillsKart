using WorldSkillsKart.DataSet1TableAdapters;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Data;

namespace WorldSkillsKart
{
    /// <summary>
    /// Логика взаимодействия для CharityAdministrator.xaml
    /// </summary>
    public class MyDataObject
    {
        public BitmapImage ImageFilePath { get; set; }
    }

    public partial class CharityAdministrator : Window
    {

        DataSet1 DataSet1 = new DataSet1();
        CharityTableAdapter CharityTableAdapter = new CharityTableAdapter();
        BitmapImage ImageSource = new BitmapImage();
        public CharityAdministrator()
        {
            InitializeComponent();
            CharityTableAdapter.Fill(DataSet1.Charity);
            DataTable dt = new DataTable("CharTable");
            dt.Columns.Add("Image", typeof(Image));
            dt.Rows.Add();
            List<MyDataObject> list = new List<MyDataObject>();
            for (int i = 0; i < DataSet1.Charity.Rows.Count; i++)
            {
                var data = (byte[])DataSet1.Charity.Rows[i].ItemArray[3];
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
                list.Add(new MyDataObject() { ImageFilePath = image });

            }
            GridCharity.ItemsSource = list;
            this.Loaded += MainWindow_Loaded;
            //GridCharity.ItemsSource = DataSet1.Charity.DefaultView;
            GridCharity.SelectionMode = DataGridSelectionMode.Single;
            GridCharity.SelectedValuePath = "ID_Сharity";
            GridCharity.CanUserAddRows = false;
            GridCharity.CanUserDeleteRows = false;
            GridCharity.IsReadOnly = true;


            Thread th = new Thread(TimerStart);
            th.Start();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            GridCharity.Columns[0].MaxWidth = 80;


        }

        private void Edit(object sender, RoutedEventArgs e)
        {

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

        private void GridCharity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddCharityExcpence addCharityExcpence = new AddCharityExcpence();
            addCharityExcpence.Show();
            this.Close();
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
    }
}

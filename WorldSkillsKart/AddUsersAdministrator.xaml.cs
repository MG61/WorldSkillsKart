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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using WorldSkillsKart.DataSet1TableAdapters;
using System.Windows.Threading;
using System.Threading;

namespace WorldSkillsKart
{
    public partial class AddUsersAdministrator : Window
    {
        DataSet1 DataSet1 = new DataSet1();
        UserTableAdapter userTableAdapter = new UserTableAdapter();
        //View_UserTableAdapter View_UserTableAdapter = new View_UserTableAdapter();

        RoleTableAdapter RoleTableAdapter = new RoleTableAdapter();
        //View_RoleTableAdapter View_RoleTableAdapter = new View_RoleTableAdapter();

        public AddUsersAdministrator()
        {
            Thread th = new Thread(TimerStart);
            th.Start();

            InitializeComponent();
            userTableAdapter.Fill(DataSet1.User);

            RoleTableAdapter.Fill(DataSet1.Role);

            RoleBox.ItemsSource = DataSet1.Role.DefaultView;
            RoleBox.DisplayMemberPath = "Role_Name";
            RoleBox.SelectedValuePath = "ID_Role";
            RoleBox.SelectedIndex = 0;
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
            UsersAdministrator usersAdministrator = new UsersAdministrator();
            usersAdministrator.Show();
            this.Close();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (Password.Text == RePasssword.Text)
            {
                if (!_maskedTextBox.Text.Equals("") & (!Name.Text.Equals("")) & (!Last_Name.Text.Equals("")) & (!Password.Text.Equals("")) & (!RePasssword.Text.Equals("")))
                {
                    userTableAdapter.Insert(_maskedTextBox.Text, Password.Text, Name.Text, Last_Name.Text, (string)RoleBox.SelectedValue);
                    MessageBox.Show("Вы успешно добавили пользователя!");
                    AdministratorMenu back = new AdministratorMenu();
                    back.Show();
                    this.Close();
                }
            }
            else { MessageBox.Show("Пароли не совпадают!"); }
        }

        private void Out_Click(object sender, RoutedEventArgs e)
        {
            UsersAdministrator usersAdministrator = new UsersAdministrator();
            usersAdministrator.Show();
            this.Close();
        }
    }
}

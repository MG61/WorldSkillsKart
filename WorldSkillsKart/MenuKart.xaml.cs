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

namespace WorldSkillsKart
{
    public partial class MenuKart : Window
    {
        public MenuKart()
        {
            InitializeComponent();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            MainWindow back = new MainWindow();
            back.Show();
            this.Close();
        }

        private void RegGonka_Click(object sender, RoutedEventArgs e)
        {
            RegisterKart go = new RegisterKart();
            go.Show();
            this.Close();
        }  

        private void MyResults_Click(object sender, RoutedEventArgs e)
        {
        }

        private void EditProfile_Click(object sender, RoutedEventArgs e)
        {
            UpdateRegisterKart go = new UpdateRegisterKart();
            go.Show();
            this.Close();
        }

        private void MySponsor_Click(object sender, RoutedEventArgs e)
        {
            MySponsor con = new MySponsor();
            con.Show();
            this.Close();
        }

        private void Contacts_Click(object sender, RoutedEventArgs e)
        {
            Contacts con = new Contacts();
            con.Show();
            this.Close();
        }
    }
}

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
    /// <summary>
    /// Логика взаимодействия для Contacts.xaml
    /// </summary>
    public partial class Contacts : Window
    {
        public Contacts()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TelephoneTB.Text = "+7(977)-377-34-22";
            EmailTB.Text = "abramenko0431@gmail.com";
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            MenuKart back = new MenuKart();
            back.Show();
            this.Close();
        }
    }
}

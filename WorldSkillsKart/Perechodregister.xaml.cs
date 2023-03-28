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
    /// Логика взаимодействия для Perechodregister.xaml
    /// </summary>
    public partial class Perechodregister : Window
    {
        public Perechodregister()
        {
            InitializeComponent();
        }

        private void auth(object sender, RoutedEventArgs e)
        {
            Auth go = new Auth();
            go.Show();
            this.Close();
        }

        private void register(object sender, RoutedEventArgs e)
        {
            RegisterKart go = new RegisterKart();
            go.Show();
            this.Close();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            MainWindow Back = new MainWindow();
            Back.Show();
            this.Close();
        }
    }
}

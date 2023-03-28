using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;
using WorldSkillsKart.DataSet1TableAdapters;

namespace WorldSkillsKart
{
    /// <summary>
    /// Логика взаимодействия для MySponsor.xaml
    /// </summary>
    public partial class MySponsor : Window
    {
        DataSet1 dataset = new DataSet1();
        RacerTableAdapter racerTA;
        RegistrationTableAdapter registrationTA;
        SponsorshipTableAdapter sponsorTA;
        CharityTableAdapter charityTA;

        public MySponsor()
        {
            InitializeComponent();
            dataset = new DataSet1();
            racerTA = new RacerTableAdapter();
            registrationTA = new RegistrationTableAdapter();
            sponsorTA = new SponsorshipTableAdapter();
            charityTA = new CharityTableAdapter();

            racerTA.Fill(dataset.Racer);
            registrationTA.Fill(dataset.Registration);
            sponsorTA.Fill(dataset.Sponsorship);
            charityTA.Fill(dataset.Charity);
        }

        private void LogoutBTN_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            MenuKart m = new MenuKart();
            m.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Sponsor1.Text = "";
            Sponsor2.Text = "";
            Sponsor3.Text = "";
            Sponsor4.Text = "";
            Sponsor5.Text = "";
            Sponsor6.Text = "";
            Vznos1.Text = "";
            Vznos2.Text = "";
            Vznos3.Text = "";
            Vznos4.Text = "";
            Vznos5.Text = "";
            Vznos6.Text = "";
            //int a = MainWindow.ID;
            for (int i=0;i<dataset.Registration.Rows.Count;i++)
            {
                for (int l=0;l<dataset.Sponsorship.Rows.Count;l++)
                    {
                        if (Convert.ToInt32(dataset.Sponsorship.Rows[l][3].ToString()) == Convert.ToInt32(dataset.Registration.Rows[i][0].ToString()))
                        {
                            if (Sponsor1.Text=="")
                            {
                                Sponsor1.Text = dataset.Sponsorship.Rows[l][1].ToString();
                                Vznos1.Text = dataset.Sponsorship.Rows[l][2].ToString();
                            }
                            else if (Sponsor2.Text == "")
                            {
                                Sponsor2.Text = dataset.Sponsorship.Rows[l][1].ToString();
                                Vznos2.Text = dataset.Sponsorship.Rows[l][2].ToString();
                            }
                            else if (Sponsor3.Text == "")
                            {
                                Sponsor3.Text = dataset.Sponsorship.Rows[l][1].ToString();
                                Vznos3.Text = dataset.Sponsorship.Rows[l][2].ToString();
                            }
                            else if (Sponsor4.Text == "")
                            {
                                Sponsor4.Text = dataset.Sponsorship.Rows[l][1].ToString();
                                Vznos4.Text = dataset.Sponsorship.Rows[l][2].ToString();
                            }
                            else if (Sponsor5.Text == "")
                            {
                                Sponsor5.Text = dataset.Sponsorship.Rows[l][1].ToString();
                                Vznos5.Text = dataset.Sponsorship.Rows[l][2].ToString();
                            }
                            else if (Sponsor6.Text == "")
                            {
                                Sponsor6.Text = dataset.Sponsorship.Rows[l][1].ToString();
                                Vznos6.Text = dataset.Sponsorship.Rows[l][2].ToString();
                            }
                        }
                    }
            }
        }
    }
}

using WorldSkillsKart.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

namespace WorldSkillsKart
{
    /// <summary>
    /// Логика взаимодействия для AllResults.xaml
    /// </summary>
    public partial class AllResults : Window
    {
        DataSet1 dataSet = new DataSet1();
        //View_SobytieTableAdapter SobytieTA;
        //Event_TypeTableAdapter eventtypeTA;
        //View_AllResultsTableAdapter allresultsTA;
        //SqlConnection connection;
        //System.Data.DataTable nameSearch = new System.Data.DataTable("Karting");
        public AllResults()
        {
            InitializeComponent();
            //SobytieTA = new View_SobytieTableAdapter();
            //eventtypeTA = new Event_TypeTableAdapter();
            //allresultsTA = new View_AllResultsTableAdapter();

            //eventtypeTA.Fill(dataset.Event_Type);
            //SobytieTA.Fill(dataset.View_Sobytie);
            //allresultsTA.Fill(dataset.View_AllResults);
        }


        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    EventCB.ItemsSource = dataset.View_Sobytie.DefaultView;
        //    EventCB.SelectedValuePath = "ID_Race";
        //    EventCB.DisplayMemberPath = "Sobytie";

        //    EventTypeCB.ItemsSource = dataset.Event_Type.DefaultView;
        //    EventTypeCB.SelectedValuePath = "ID_Event_type";
        //    EventTypeCB.DisplayMemberPath = "Event_Type_Name";

        //    GenderCB.SelectedIndex = 2;

        //    PilotsDg.ItemsSource = dataset.View_AllResults.DefaultView;
        //    var column = PilotsDg.Columns[7];
        //    ListSortDirection sortDirection = ListSortDirection.Ascending;
        //    PilotsDg.Items.SortDescriptions.Clear();
        //    PilotsDg.Items.SortDescriptions.Add(new SortDescription(column.SortMemberPath, sortDirection));

        //    VsegoPilotovTB.Text = PilotsDg.Items.Count.ToString();
        //    FinishPilotsTB.Text = PilotsDg.Items.Count.ToString();
        //    PilotsDg.SelectedIndex = PilotsDg.Items.Count - 2;
        //    int hours = 0;
        //    int minutes = 0;
        //    int seconds = 0;
        //    for (int i = 0; i < PilotsDg.Items.Count - 1; i++)
        //    {
        //        PilotsDg.SelectedIndex = i;
        //        DataRowView dataRowView = (DataRowView)PilotsDg.SelectedItem;
        //        DateTime date = new DateTime();
        //        date = Convert.ToDateTime(dataRowView.Row.Field<TimeSpan>("RaceTime").ToString());
        //        hours += date.Hour;
        //        minutes += date.Minute;
        //        seconds += date.Second;
        //    }
        //    while (seconds >= 60)
        //    {
        //        minutes += 1;
        //        seconds -= 60;
        //    }
        //    while (minutes >= 60)
        //    {
        //        hours += 1;
        //        minutes -= 60;
        //    }
        //    hours = hours / 2;
        //    minutes = minutes / 2;
        //    seconds = seconds / 2;

        //    string temp = $"{hours}:{minutes}:{seconds}";
        //    AverageTimeTB.Text = temp;
        //}

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            MainWindow k = new MainWindow();
            k.Show();
            this.Close();
        }

        //private void PilotsDg_LoadingRow(object sender, DataGridRowEventArgs e)
        //{
        //    try
        //    {
        //        e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        //        PilotsDg.Columns[0].Visibility = Visibility.Hidden;
        //        PilotsDg.Columns[1].Visibility = Visibility.Hidden;
        //        PilotsDg.Columns[2].Visibility = Visibility.Hidden;
        //        PilotsDg.Columns[3].Visibility = Visibility.Hidden;
        //        PilotsDg.Columns[4].Visibility = Visibility.Hidden;
        //        PilotsDg.Columns[5].Visibility = Visibility.Hidden;
        //        PilotsDg.Columns[6].Visibility = Visibility.Hidden;
        //        PilotsDg.Columns[10].Visibility = Visibility.Hidden;
        //    }
        //    catch { }
        //}

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            ////try
            ////{
            //if (EventCB.SelectedIndex != -1 && EventTypeCB.SelectedIndex != -1)
            //{
            //    nameSearch.Clear();
            //    switch (GenderCB.SelectedIndex)
            //    {
            //        case 0:
            //            switch (KategoriaCB.SelectedIndex)
            //            {
            //                case -1:
            //                    nameSearch = nameFill("SELECT * FROM [dbo].[View_AllResults] WHERE [ID_Race] = '" + (int)EventCB.SelectedValue + "' AND [ID_Event_type] = '" + EventTypeCB.SelectedValue.ToString() + "' AND [Gender] = 'M'");
            //                    break;
            //                case 0:
            //                    nameSearch = nameFill("SELECT * FROM [dbo].[View_AllResults] WHERE [ID_Race] = '" + (int)EventCB.SelectedValue + "' AND [ID_Event_type] = '" + EventTypeCB.SelectedValue.ToString() + "' AND [DateOfBirth] < CONVERT(DATETIME, '2004-01-01 00:00:00', 102) AND [DateOfBirth] > CONVERT(DATETIME, '1993-01-01 00:00:00', 102) AND [Gender] = 'M'");
            //                    break;
            //                case 1:
            //                    nameSearch = nameFill("SELECT * FROM [dbo].[View_AllResults] WHERE [ID_Race] = '" + (int)EventCB.SelectedValue + "' AND [ID_Event_type] = '" + EventTypeCB.SelectedValue.ToString() + "' AND [DateOfBirth] < CONVERT(DATETIME, '1992-01-01 00:00:00', 102) AND [DateOfBirth] > CONVERT(DATETIME, '1967-01-01 00:00:00', 102) AND [Gender] = 'M'");
            //                    break;
            //                case 2:
            //                    nameSearch = nameFill("SELECT * FROM [dbo].[View_AllResults] WHERE [ID_Race] = '" + (int)EventCB.SelectedValue + "' AND [ID_Event_type] = '" + EventTypeCB.SelectedValue.ToString() + "' AND [DateOfBirth] < CONVERT(DATETIME, '1966-01-01 00:00:00', 102) AND [Gender] = 'M'");
            //                    break;
            //            }
            //            break;
            //        case 1:
            //            switch (KategoriaCB.SelectedIndex)
            //            {
            //                case -1:
            //                    nameSearch = nameFill("SELECT * FROM [dbo].[View_AllResults] WHERE [ID_Race] = '" + (int)EventCB.SelectedValue + "' AND [ID_Event_type] = '" + EventTypeCB.SelectedValue.ToString() + "' AND [Gender] = 'F'");
            //                    break;
            //                case 0:
            //                    nameSearch = nameFill("SELECT * FROM [dbo].[View_AllResults] WHERE [ID_Race] = '" + (int)EventCB.SelectedValue + "' AND [ID_Event_type] = '" + EventTypeCB.SelectedValue.ToString() + "' AND [DateOfBirth] < CONVERT(DATETIME, '2004-01-01 00:00:00', 102) AND [DateOfBirth] > CONVERT(DATETIME, '1993-01-01 00:00:00', 102) AND [Gender] = 'F'");
            //                    break;
            //                case 1:
            //                    nameSearch = nameFill("SELECT * FROM [dbo].[View_AllResults] WHERE [ID_Race] = '" + (int)EventCB.SelectedValue + "' AND [ID_Event_type] = '" + EventTypeCB.SelectedValue.ToString() + "' AND [DateOfBirth] < CONVERT(DATETIME, '1992-01-01 00:00:00', 102) AND [DateOfBirth] > CONVERT(DATETIME, '1967-01-01 00:00:00', 102) AND [Gender] = 'F'");
            //                    break;
            //                case 2:
            //                    nameSearch = nameFill("SELECT * FROM [dbo].[View_AllResults] WHERE [ID_Race] = '" + (int)EventCB.SelectedValue + "' AND [ID_Event_type] = '" + EventTypeCB.SelectedValue.ToString() + "' AND [DateOfBirth] < CONVERT(DATETIME, '1966-01-01 00:00:00', 102) AND [Gender] = 'F'");
            //                    break;
            //            }
            //            break;
            //        case 2:
            //            switch (KategoriaCB.SelectedIndex)
            //            {
            //                case -1:
            //                    nameSearch = nameFill("SELECT * FROM [dbo].[View_AllResults] WHERE [ID_Race] = '" + (int)EventCB.SelectedValue + "' AND [ID_Event_type] = '" + EventTypeCB.SelectedValue.ToString() + "'");
            //                    break;
            //                case 0:
            //                    nameSearch = nameFill("SELECT * FROM [dbo].[View_AllResults] WHERE [ID_Race] = '" + (int)EventCB.SelectedValue + "' AND [ID_Event_type] = '" + EventTypeCB.SelectedValue.ToString() + "' AND [DateOfBirth] < CONVERT(DATETIME, '2004-01-01 00:00:00', 102) AND [DateOfBirth] > CONVERT(DATETIME, '1993-01-01 00:00:00', 102)");
            //                    break;
            //                case 1:
            //                    nameSearch = nameFill("SELECT * FROM [dbo].[View_AllResults] WHERE [ID_Race] = '" + (int)EventCB.SelectedValue + "' AND [ID_Event_type] = '" + EventTypeCB.SelectedValue.ToString() + "' AND [DateOfBirth] < CONVERT(DATETIME, '1992-01-01 00:00:00', 102) AND [DateOfBirth] > CONVERT(DATETIME, '1967-01-01 00:00:00', 102)");
            //                    break;
            //                case 2:
            //                    nameSearch = nameFill("SELECT * FROM [dbo].[View_AllResults] WHERE [ID_Race] = '" + (int)EventCB.SelectedValue + "' AND [ID_Event_type] = '" + EventTypeCB.SelectedValue.ToString() + "' AND [DateOfBirth] < CONVERT(DATETIME, '1966-01-01 00:00:00', 102)");
            //                    break;
            //            }
            //            break;
            //    }
            //    if (nameSearch.Rows.Count > 0)
            //    {
            //        PilotsDg.ItemsSource = null;
            //        PilotsDg.ItemsSource = nameSearch.DefaultView;
            //        var column = PilotsDg.Columns[7];
            //        ListSortDirection sortDirection = ListSortDirection.Ascending;
            //        PilotsDg.Items.SortDescriptions.Clear();
            //        PilotsDg.Items.SortDescriptions.Add(new SortDescription(column.SortMemberPath, sortDirection));
            //    }
            //}
            ////}
            ////catch { }
        }
        //public System.Data.DataTable nameFill(string SearchSQL)
        //{
        //    connection.Open();
        //    SqlCommand command = connection.CreateCommand();
        //    command.CommandText = SearchSQL;
        //    SqlDataAdapter adapter = new SqlDataAdapter(command);
        //    adapter.Fill(nameSearch);
        //    connection.Close();
        //    return nameSearch;
        //}

    }
}


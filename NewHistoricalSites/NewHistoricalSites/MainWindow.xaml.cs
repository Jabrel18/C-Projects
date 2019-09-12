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

namespace NewHistoricalSites
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Sites> HistoricalSites;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LongitudeTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AddSiteButton_Click(object sender, RoutedEventArgs e)
        {
            string SiteName = "";
            double Longitude = 0.0D;
            double Latitude = 0.0D;
            string Description = "";
            List<string> Towns = new List<string>();

            SiteName = SiteNameTextbox.Text;//ToString();
            Longitude = double.Parse(LongitudeTextbox.Text);
            Latitude = double.Parse(LatitudeTextbox.Text);
            Description = DescriptionTextbox.Text;

            // Ad Towns from comboBox to Towns<List>
            int NumOfTowns = TownsCombobox.Items.Count;
            if (NumOfTowns > 0)
            {
                for (int i = 0; i < NumOfTowns; i++)
                {
                    //Towns.Add(TownsCombobox.Items.GetItemAt(i).ToString());
                    Towns.Add(TownsCombobox.Items[i].ToString());
                }
            }

            Sites Site = new Sites(SiteName, Latitude, Longitude,
                Description, Towns);

            NumberOfSitesLabel.Content = Sites.NumberOfSites.ToString();

            //Add To HistoricalSites<List>
            List<Sites> HistoricalSites = new List<Sites>();
            HistoricalSites.Add(Site);

            //Add Site to SitesCombobox
            SitesCombobox.Items.Add(Site.SiteName);

            string message = Site.SiteName.ToString() + " was added to the list ";
            MessageBox.Show(message);

            ClearScreen();
        }

        private void AddTownButton_Click(object sender, RoutedEventArgs e)
        {
            if (TownsCombobox.Text != "")
            {
                TownsCombobox.Items.Add(TownsCombobox.Text);
                TownsCombobox.Text = "";
                TownsCombobox.Focus();
            }
            else
            {
                MessageBox.Show("No town entered");
            }
        }
        private void ClearScreen()
        {
            SiteNameTextbox.Clear();
                LatitudeTextbox.Clear();
                LongitudeTextbox.Clear();
                DescriptionTextbox.Clear();
                TownsCombobox.Items.Clear();
        }

        private void SitesCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SiteNameTextbox.Text = HistoricalSites[SitesCombobox.SelectedIndex].SiteName;
            LatitudeTextbox.Text = HistoricalSites[SitesCombobox.SelectedIndex].Latitude.ToString();
            LongitudeTextbox.Text = HistoricalSites[SitesCombobox.SelectedIndex].Longitude.ToString();
            DescriptionTextbox.Text = HistoricalSites[SitesCombobox.SelectedIndex].Description.ToString();

            int NumberOfTowns = HistoricalSites[SitesCombobox.SelectedIndex].Towns.Count;
            for (int count = 0; count < NumberOfTowns; count++)
            {
                TownsCombobox.Items.Add(HistoricalSites[SitesCombobox.SelectedIndex].Towns[count]); 
            }

        }

        private void ClearScreenButton_Click(object sender, RoutedEventArgs e)
        {
            ClearScreen();
        }
    }
}

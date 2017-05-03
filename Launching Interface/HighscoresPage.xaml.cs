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

namespace Launching_Interface
{
    /// <summary>
    /// Interaction logic for HighscoresPage.xaml
    /// </summary>
    public partial class HighscoresPage : Page
    {
        List<string> LanguagesHighscoresPage { get; set; }
        List<Player> ChangingPlayerList { get; set; }

        public HighscoresPage()
        {
            LanguagesHighscoresPage = new List<string>();
            ChangingPlayerList = new List<Player>();
            ChangingPlayerList = GameDataManager.PlayerList.OrderBy(x => x.TotalTime).ToList(); ;

            InitializeComponent();
            ChangeTable(100);

            OrganizeCharacteristicMargins();
            NameButtons();

        }
        void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MainPage());
        }

        void OrganizeCharacteristicMargins()
        {
            switch (GameDataManager.Language)
            {
                case 0:
                    LanguagesHighscoresPage = GameDataManager.FrenchList;
                    HStitle.Margin = new Thickness(-31, 13, 40, 5);
                    BackButtonText.Margin = new Thickness(36, 17, 105, 50);
                    ButLevel1Text.Margin = new Thickness(120, 17, 35, 29);
                    ButLevel5Text.Margin = new Thickness(35, 17, 120, 29);
                    break;
                case 1:
                    LanguagesHighscoresPage = GameDataManager.EnglishList;
                    HStitle.Margin = new Thickness(-31, 13, 40, 5);
                    BackButtonText.Margin = new Thickness(36, 17, 105, 50);
                    ButLevel1Text.Margin = new Thickness(120, 17, 35, 29);
                    ButLevel5Text.Margin = new Thickness(35, 17, 120, 29);
                    break;
                case 2:
                    LanguagesHighscoresPage = GameDataManager.SpanishList;
                    HStitle.Margin = new Thickness(-36, 13, 40, 5);
                    BackButtonText.Margin = new Thickness(33, 17, 107, 52);
                    ButLevel1Text.Margin = new Thickness(120, 17, 35, 29);
                    ButLevel5Text.Margin = new Thickness(35, 17, 120, 29);
                    break;
                case 3:
                    LanguagesHighscoresPage = GameDataManager.JapaneseList;
                    HStitle.Margin = new Thickness(-20, 13, 53, 5);
                    BackButtonText.Margin = new Thickness(36, 17, 105, 52);
                    ButLevel1Text.Margin = new Thickness(120, 17, 35, 29);
                    ButLevel5Text.Margin = new Thickness(35, 17, 120, 29);
                    break;
            }
            ButLevel4Text.Margin = ButLevel3Text.Margin = ButLevel2Text.Margin = ButLevel1Text.Margin;
            ButLevel8Text.Margin = ButLevel7Text.Margin = ButLevel6Text.Margin = ButLevel5Text.Margin;
        }

        void NameButtons()
        {
            HStitle.Text = LanguagesHighscoresPage[28];
            BackButtonText.Text = LanguagesHighscoresPage[0];

            ButLevel1Text.Text = LanguagesHighscoresPage[46];
            ButLevel2Text.Text = LanguagesHighscoresPage[47];
            ButLevel3Text.Text = LanguagesHighscoresPage[48];
            ButLevel4Text.Text = LanguagesHighscoresPage[49];
            ButLevel5Text.Text = LanguagesHighscoresPage[50];
            ButLevel6Text.Text = LanguagesHighscoresPage[51];
            ButLevel7Text.Text = LanguagesHighscoresPage[52];
            ButLevel8Text.Text = LanguagesHighscoresPage[53];

            ButTotalText.Text = LanguagesHighscoresPage[54];
            Rang.Text = LanguagesHighscoresPage[9];
            Names.Text = LanguagesHighscoresPage[45];
            Temps.Text = LanguagesHighscoresPage[10];
        }

        List<Player> SortedListAccordingToLevel(int niveau)
        {
            return GameDataManager.PlayerList.OrderBy(x => x.PlayerTimeList[niveau - 1]).ToList();
        }



        // Buttons Level X
        #region

        private void ButLevel1_Click(object sender, RoutedEventArgs e)
        {
            ChangingPlayerList = SortedListAccordingToLevel(1);
            ChangeTable(1);

        }

        private void ButLevel2_Click(object sender, RoutedEventArgs e)
        {
            ChangingPlayerList = SortedListAccordingToLevel(2);
            ChangeTable(2);
        }

        private void ButLevel3_Click(object sender, RoutedEventArgs e)
        {
            ChangingPlayerList = SortedListAccordingToLevel(3);
            ChangeTable(3);
        }

        private void ButLevel4_Click(object sender, RoutedEventArgs e)
        {
            ChangingPlayerList = SortedListAccordingToLevel(4);
            ChangeTable(4);
        }

        private void ButLevel8_Click(object sender, RoutedEventArgs e)
        {
            ChangingPlayerList = SortedListAccordingToLevel(8);
            ChangeTable(8);
        }

        private void ButLevel7_Click(object sender, RoutedEventArgs e)
        {
            ChangingPlayerList = SortedListAccordingToLevel(7);
            ChangeTable(7);
        }

        private void ButLevel6_Click(object sender, RoutedEventArgs e)
        {
            ChangingPlayerList = SortedListAccordingToLevel(6);
            ChangeTable(6);
        }

        private void ButLevel5_Click(object sender, RoutedEventArgs e)
        {
            ChangingPlayerList = SortedListAccordingToLevel(5);
            ChangeTable(5);
        }

        private void ButTotal_Click(object sender, RoutedEventArgs e)
        {
            //ChangingPlayerList = ChangingPlayerList.OrderBy(x => x.TotalTime).ToList();

            ChangeTable(100);

        }

        #endregion

        void ChangeTable(int niveau)
        {
            niveau -= 1;
            while (ChangingPlayerList.Count < 10)
            {
                ChangingPlayerList.Add(new Player("-------------------", TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero,
                                                                             TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero,
                                                                             TimeSpan.Zero, TimeSpan.Zero));
            }

            name1.Text = ChangingPlayerList[0].Name;
            name2.Text = ChangingPlayerList[1].Name;
            name3.Text = ChangingPlayerList[2].Name;
            name4.Text = ChangingPlayerList[3].Name;
            name5.Text = ChangingPlayerList[4].Name;
            name6.Text = ChangingPlayerList[5].Name;
            name7.Text = ChangingPlayerList[6].Name;
            name8.Text = ChangingPlayerList[7].Name;
            name9.Text = ChangingPlayerList[8].Name;
            name10.Text = ChangingPlayerList[9].Name;

            if (niveau != 99)
            {
                time1.Text = ChangingPlayerList[0].PlayerTimeList[niveau].ToString();
                time2.Text = ChangingPlayerList[1].PlayerTimeList[niveau].ToString();
                time3.Text = ChangingPlayerList[2].PlayerTimeList[niveau].ToString();
                time4.Text = ChangingPlayerList[3].PlayerTimeList[niveau].ToString();
                time5.Text = ChangingPlayerList[4].PlayerTimeList[niveau].ToString();
                time6.Text = ChangingPlayerList[5].PlayerTimeList[niveau].ToString();
                time7.Text = ChangingPlayerList[6].PlayerTimeList[niveau].ToString();
                time8.Text = ChangingPlayerList[7].PlayerTimeList[niveau].ToString();
                time9.Text = ChangingPlayerList[8].PlayerTimeList[niveau].ToString();
                time10.Text = ChangingPlayerList[9].PlayerTimeList[niveau].ToString();
            }
            else
            {
                ChangeTotalTimes();
            }
        }

        void ChangeTotalTimes()
        {


            time1.Text = ChangingPlayerList[0].TotalTime.ToString();
            time2.Text = ChangingPlayerList[1].TotalTime.ToString();
            time3.Text = ChangingPlayerList[2].TotalTime.ToString();
            time4.Text = ChangingPlayerList[3].TotalTime.ToString();
            time5.Text = ChangingPlayerList[4].TotalTime.ToString();
            time6.Text = ChangingPlayerList[5].TotalTime.ToString();
            time7.Text = ChangingPlayerList[6].TotalTime.ToString();
            time8.Text = ChangingPlayerList[7].TotalTime.ToString();
            time9.Text = ChangingPlayerList[8].TotalTime.ToString();
            time10.Text = ChangingPlayerList[9].TotalTime.ToString();

        }
    }
}

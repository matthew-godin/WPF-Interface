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

namespace Launching_Interface
{
    /// <summary>
    /// Interaction logic for LoadGamePage.xaml
    /// </summary>
    public partial class LoadGamePage : Page
    {
      List<string> LanguagesLoadPage { get; set; }
      public LoadGamePage()
        {
         LanguagesLoadPage = new List<string>();
         InitializeComponent();
         if (GameDataManager.Language == 0) { LanguagesLoadPage = GameDataManager.FrenchList; }
         if (GameDataManager.Language == 1) { LanguagesLoadPage = GameDataManager.EnglishList; }
         if (GameDataManager.Language == 2) { LanguagesLoadPage = GameDataManager.SpanishList; }
         if (GameDataManager.Language == 3) { LanguagesLoadPage = GameDataManager.JapaneseList; }

         tbtitle.Text = LanguagesLoadPage[32];
         BackButton.Text = LanguagesLoadPage[0];

         saveA.Text = LanguagesLoadPage[2];
         timeA.Text = LanguagesLoadPage[3];
         doneA.Text = LanguagesLoadPage[4];

         saveB.Text = LanguagesLoadPage[5];
         timeB.Text = LanguagesLoadPage[6];
         doneB.Text = LanguagesLoadPage[7];

         saveC.Text = LanguagesLoadPage[8];
         timeC.Text = LanguagesLoadPage[9];
         doneC.Text = LanguagesLoadPage[10];
      }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MainPage());
        }

      private void Load1Button_Click(object sender, RoutedEventArgs e)
      {

      }

      private void Load2Button_Click(object sender, RoutedEventArgs e)
      {

      }

      private void Load3Button_Click(object sender, RoutedEventArgs e)
      {

      }
   }
}

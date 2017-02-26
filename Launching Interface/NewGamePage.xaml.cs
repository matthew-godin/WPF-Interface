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
   /// Interaction logic for NewGamePage.xaml
   /// </summary>
   public partial class NewGamePage : Page
   {
      List<string> LanguageNewPage { get; set; }
      public NewGamePage()
      {
         LanguageNewPage = new List<string>();
         InitializeComponent();
         if (GameDataManager.Language == 0) { LanguageNewPage = GameDataManager.FrenchList; }
         if (GameDataManager.Language == 1) { LanguageNewPage = GameDataManager.EnglishList; }
         if (GameDataManager.Language == 2) { LanguageNewPage = GameDataManager.SpanishList; }
         if (GameDataManager.Language == 3) { LanguageNewPage = GameDataManager.JapaneseList; }

         tbtitle.Text = LanguageNewPage[1];
         BackButton.Text = LanguageNewPage[0];

         saveA.Text = LanguageNewPage[2];
         timeA.Text = LanguageNewPage[3];
         doneA.Text = LanguageNewPage[4];

         saveB.Text = LanguageNewPage[5];
         timeB.Text = LanguageNewPage[6];
         doneB.Text = LanguageNewPage[7];

         saveC.Text = LanguageNewPage[8];
         timeC.Text = LanguageNewPage[9];
         doneC.Text = LanguageNewPage[10];
      }

      private void BackButton_Click(object sender, RoutedEventArgs e)
      {
         this.NavigationService.Navigate(new MainPage());
      }

      private void Save1Button_Click(object sender, RoutedEventArgs e)
      {
         this.NavigationService.Navigate(new GamePage());
      }
   }
}

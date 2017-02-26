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
   /// Interaction logic for CreditsPage.xaml
   /// </summary>
   public partial class CreditsPage : Page
   {
      List<string> LanguagesCredits { get; set; }
      public CreditsPage()
      {
         LanguagesCredits = new List<string>();
         InitializeComponent();
         ManageLanguages();
         


      }
      private void BackButton_Click(object sender, RoutedEventArgs e)
      {
         this.NavigationService.Navigate(new MainPage());
      }

      void ManageLanguages()
      {
         if (GameDataManager.Language == 0) { LanguagesCredits = GameDataManager.FrenchList; }
         if (GameDataManager.Language == 1) { LanguagesCredits = GameDataManager.EnglishList; }
         if (GameDataManager.Language == 2) { LanguagesCredits = GameDataManager.SpanishList; }
         if (GameDataManager.Language == 3) { LanguagesCredits = GameDataManager.JapaneseList; }

         sim.Text = LanguagesCredits[25];
         clg.Text = LanguagesCredits[26];
         TitleSett.Text = LanguagesCredits[24];
         year.Text = LanguagesCredits[27];
         BackButton.Text = LanguagesCredits[0];
      }
   }
}

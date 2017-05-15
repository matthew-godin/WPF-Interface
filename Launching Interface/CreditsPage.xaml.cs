using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

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
         switch (GameDataManager.Language)
         {
            case GameDataManager.Languages.French:
               LanguagesCredits = GameDataManager.FrenchList;
               BackButton.Margin = new Thickness(35, 19, 101, 88);
               break;
            case GameDataManager.Languages.English:
               LanguagesCredits = GameDataManager.EnglishList;
               BackButton.Margin = new Thickness(36, 19, 104, 88);
               break;
            case GameDataManager.Languages.Spanish:
               LanguagesCredits = GameDataManager.SpanishList;
               BackButton.Margin = new Thickness(31, 19, 109, 88);
               break;
            case GameDataManager.Languages.Japanese:
               LanguagesCredits = GameDataManager.JapaneseList;
               BackButton.Margin = new Thickness(35, 19, 102, 88);
               break;


         }
         sim.Text = LanguagesCredits[25];
         clg.Text = LanguagesCredits[26];
         TitleSett.Text = LanguagesCredits[24];
         year.Text = LanguagesCredits[27];
         BackButton.Text = LanguagesCredits[0];
      }
   }
}

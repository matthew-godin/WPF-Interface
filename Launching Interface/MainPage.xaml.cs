using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;


namespace Launching_Interface
{
   /// <summary>
   /// Interaction logic for MainPage.xaml
   /// </summary>
   public partial class MainPage : Page
   {
      List<string> LanguagesMainPage { get; set; }
      public MainPage()
      {
         LanguagesMainPage = new List<string>();
         InitializeComponent();

         ManageTexts();
         ManageFullscreen();
      }

      void ManageTexts()
      {
         switch (GameDataManager.Language)
         {
            case GameDataManager.Languages.French:
               LanguagesMainPage = GameDataManager.FrenchList;
               lg.Margin = new Thickness(55, 10, 50, 10);
               ng.Margin = new Thickness(55, 10, 55, 10);
               se.Margin = new Thickness(55, 10, 55, 10);
               break;
            case GameDataManager.Languages.English:
               LanguagesMainPage = GameDataManager.EnglishList;
               lg.Margin = new Thickness(57, 10, 46, 10);
               ng.Margin = new Thickness(57, 10, 51, 10);
               se.Margin = new Thickness(55, 10, 55, 10);
               break;
            case GameDataManager.Languages.Spanish:
               LanguagesMainPage = GameDataManager.SpanishList;
               lg.Margin = new Thickness(55, 10, 50, 10);
               ng.Margin = new Thickness(55, 10, 55, 10);
               se.Margin = new Thickness(55, 10, 55, 10);

               break;
            case GameDataManager.Languages.Japanese:
               LanguagesMainPage = GameDataManager.JapaneseList;
               lg.Margin = new Thickness(55, 10, 50, 10);
               ng.Margin = new Thickness(57, 10, 51, 10);
               se.Margin = new Thickness(57, 10, 53, 10);
               break;


         }


         ng.Text = LanguagesMainPage[1];
         lg.Text = LanguagesMainPage[32];
         se.Text = LanguagesMainPage[11];
         cr.Text = LanguagesMainPage[24];
         exit.Text = LanguagesMainPage[34];
      }

      void ManageFullscreen()
      {
         if (GameDataManager.FullscreenMode == GameDataManager.Fullscreen.yes)
         {
            ApplyBackground();
         }
         else
         {
            RemoveBackground();
         }
      }

      void RemoveBackground()
      {
         int screenWidth = 1500;
         int screenHeight = 800;

         Application.Current.MainWindow.Height = screenHeight;
         Application.Current.MainWindow.Width = screenWidth;

         Application.Current.MainWindow.WindowState = WindowState.Normal;
         Application.Current.MainWindow.WindowStyle = WindowStyle.SingleBorderWindow;
         Application.Current.MainWindow.ResizeMode = ResizeMode.CanResize;

      }

      void ApplyBackground()
      {
         Application.Current.MainWindow.WindowState = WindowState.Maximized;
         Application.Current.MainWindow.WindowStyle = WindowStyle.None;
         Application.Current.MainWindow.ResizeMode = ResizeMode.NoResize;

      }

      private void LoadGameButton_Click(object sender, RoutedEventArgs e)
      {
         NavigationService.Navigate(new LoadGamePage());
      }
      private void SettingsButton_Click(object sender, RoutedEventArgs e)
      {
         NavigationService.Navigate(new SettingsPage());
      }
      private void NewGameButton_Click(object sender, RoutedEventArgs e)
      {
         NavigationService.Navigate(new NewGamePage());
      }

      private void CreditsButton_Click(object sender, RoutedEventArgs e)
      {
         NavigationService.Navigate(new CreditsPage());
      }


      private void Quit_Click(object sender, RoutedEventArgs e)
      {
         Application.Current.Shutdown();
      }
   }
}

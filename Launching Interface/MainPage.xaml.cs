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
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


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
         if (GameDataManager.Language == 0) { LanguagesMainPage = GameDataManager.FrenchList; lg.Margin = new Thickness(55, 10, 50, 10); ng.Margin = new Thickness(55, 10, 55, 10); se.Margin = new Thickness(55, 10, 55, 10); }
         if (GameDataManager.Language == 1) { LanguagesMainPage = GameDataManager.EnglishList;  lg.Margin = new Thickness(57, 10, 46, 10); ng.Margin = new Thickness(57, 10, 51, 10); se.Margin = new Thickness(55, 10, 55, 10); }
         if (GameDataManager.Language == 2) { LanguagesMainPage = GameDataManager.SpanishList; lg.Margin = new Thickness(55, 10, 50, 10); ng.Margin = new Thickness(55, 10, 55, 10); se.Margin = new Thickness(55, 10, 55, 10); }
         if (GameDataManager.Language == 3) { LanguagesMainPage = GameDataManager.JapaneseList; lg.Margin = new Thickness(55, 10, 50, 10); ng.Margin = new Thickness(57, 10, 51, 10); se.Margin = new Thickness(57, 10, 53, 10); }

         ng.Text = LanguagesMainPage[1];
         lg.Text = LanguagesMainPage[32];
         se.Text = LanguagesMainPage[11];
         cr.Text = LanguagesMainPage[24];
         hi.Text = LanguagesMainPage[28];
         exit.Text = LanguagesMainPage[34];


         if(GameDataManager.FullscreenMode == 1)
         {
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
            Application.Current.MainWindow.WindowStyle = WindowStyle.None;
            Application.Current.MainWindow.ResizeMode = ResizeMode.NoResize;
         }
         else
         {
            Application.Current.MainWindow.WindowState = WindowState.Normal;
            Application.Current.MainWindow.WindowStyle = WindowStyle.SingleBorderWindow;
            Application.Current.MainWindow.ResizeMode = ResizeMode.CanResize;
         }



      }
      private void LoadGameButton_Click(object sender, RoutedEventArgs e)
      {
            //NavigationService.Navigate(new Uri("LoadGamePage.xaml", UriKind.Relative));
            this.NavigationService.Navigate(new LoadGamePage());
        }
      private void SettingsButton_Click(object sender, RoutedEventArgs e)
      {
            //NavigationService.Navigate(new Uri("SettingsPage.xaml", UriKind.Relative));
            this.NavigationService.Navigate(new SettingsPage());
        }
      private void NewGameButton_Click(object sender, RoutedEventArgs e)
      {
            //NavigationService.Navigate(new Uri("NewGamePage.xaml", UriKind.Relative));
            this.NavigationService.Navigate(new NewGamePage());
        }

      private void CreditsButton_Click(object sender, RoutedEventArgs e)
      {
            //NavigationService.Navigate(new Uri("CreditsPage.xaml", UriKind.Relative));
            this.NavigationService.Navigate(new CreditsPage());
        }

      private void Highscores_Click(object sender, RoutedEventArgs e)
      {
         //NavigationService.Navigate(new Uri("HighscoresPage.xaml", UriKind.Relative));
      }

      private void Quit_Click(object sender, RoutedEventArgs e)
      {
         Application.Current.Shutdown();
      }
   }
}

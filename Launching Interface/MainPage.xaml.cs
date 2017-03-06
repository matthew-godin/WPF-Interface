﻿using System;
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
         if (GameDataManager.Language == 0) { LanguagesMainPage = GameDataManager.FrenchList; }
         if (GameDataManager.Language == 1) { LanguagesMainPage = GameDataManager.EnglishList; }
         if (GameDataManager.Language == 2) { LanguagesMainPage = GameDataManager.SpanishList; }
         if (GameDataManager.Language == 3) { LanguagesMainPage = GameDataManager.JapaneseList; }

         ng.Text = LanguagesMainPage[1];
         lg.Text = LanguagesMainPage[32];
         se.Text = LanguagesMainPage[11];
         cr.Text = LanguagesMainPage[24];
         hi.Text = LanguagesMainPage[28];


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
         NavigationService.Navigate(new Uri("LoadGamePage.xaml", UriKind.Relative));
        
      }
      private void SettingsButton_Click(object sender, RoutedEventArgs e)
      {
         NavigationService.Navigate(new Uri("SettingsPage.xaml", UriKind.Relative));
      }
      private void NewGameButton_Click(object sender, RoutedEventArgs e)
      {
         NavigationService.Navigate(new Uri("NewGamePage.xaml", UriKind.Relative));
      }

      private void CreditsButton_Click(object sender, RoutedEventArgs e)
      {
         NavigationService.Navigate(new Uri("CreditsPage.xaml", UriKind.Relative));
      }

      private void Highscores_Click(object sender, RoutedEventArgs e)
      {
         NavigationService.Navigate(new Uri("HighscoresPage.xaml", UriKind.Relative));
      }


   }
}
